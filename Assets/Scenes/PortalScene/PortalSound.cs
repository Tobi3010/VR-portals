using UnityEngine;
using System.Collections.Generic;

public class AudioTrackerNoListener : MonoBehaviour
{
    public AudioSource otherPortalAudio;
    private List<AudioSource> audios;
    private List<AudioSource> nearbyPortalAudios;
    public float portalDetectionRange = 1000f; // Range to detect nearby portals

    void Start()
    {
        audios = new List<AudioSource>(FindObjectsOfType<AudioSource>());  // Find all audios in our scene
        GetAllPortals();
    }

    void Update()
    {
        if (otherPortalAudio != null)
        {
            if (audios == null) { return; } // In case there are no audios

            AudioSource domAudio = GetDomAudio(); // Get the loudest audio near this portal
            if (domAudio != null)
            {
                otherPortalAudio.clip = domAudio.clip; // Set the otherPortal to play the found audio

                // Ensure that otherPortalAudio is enabled and has a valid clip before playing
                if (domAudio.isPlaying && !otherPortalAudio.isPlaying && otherPortalAudio.enabled && otherPortalAudio.clip != null)
                {
                    otherPortalAudio.Play(); // Synchronize play
                }
                else if (!domAudio.isPlaying && otherPortalAudio.isPlaying)
                {
                    otherPortalAudio.Stop(); // Synchronize stop
                }
                otherPortalAudio.volume = 1; 
            }
        }
    }

    void GetAllPortals()
    {
        nearbyPortalAudios = new List<AudioSource>();
        AudioTrackerNoListener[] allPortals = FindObjectsOfType<AudioTrackerNoListener>(); // Find all portals in the scene
        foreach (var portal in allPortals)
        {
            nearbyPortalAudios.Add(portal.otherPortalAudio); // Add other portal's audio source
        }
    }

    AudioSource GetDomAudio()
    {
        AudioSource domAudio = null;
        float maxVolume = 0f;

        foreach (AudioSource audio in audios)
        { // Loop through all audios in our scene
            if (nearbyPortalAudios.Contains(audio)) { continue; } // Skip if audio is from portal

            if (audio.isPlaying)
            { // Check if audio is actually playing
                // Very basic attenuation formula, inverse square law
                float dist = Vector3.Distance(transform.position, audio.transform.position);
                if (dist > portalDetectionRange) { continue; }
                float volume = audio.volume / (dist * dist);
                if (volume > maxVolume)
                { // Basic finding max algorithm
                    maxVolume = volume;
                    domAudio = audio;
                }
            }
        }
        return domAudio;
    }
}
