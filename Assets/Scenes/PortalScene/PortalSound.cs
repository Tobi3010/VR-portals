using UnityEngine;
using System.Collections.Generic;

public class AudioTrackerNoListener : MonoBehaviour
{
    public AudioSource otherPortalAudio; 
    private List<AudioSource> audios;

    void Start() {
        audios = new List<AudioSource>(FindObjectsOfType<AudioSource>());  // Find all audios in our scene
    }


    void Update() {
        if (audios == null) { return; }                                     // In case theres no audios

        AudioSource domAudio = GetDomAudio();                               // Get the loudest audio near this portal.
        if (domAudio != null) {
            otherPortalAudio.clip = domAudio.clip;                          // Set the otherPortal to play the found audio
            if (domAudio.isPlaying && !otherPortalAudio.isPlaying) {        // Synchronize play
                otherPortalAudio.Play();
            } 
            else if (!domAudio.isPlaying && otherPortalAudio.isPlaying) {   // synchronize stop
                otherPortalAudio.Stop();
            }
            otherPortalAudio.volume = domAudio.volume;               // Copy the volume from source but lower it abit
        }
    }


    AudioSource GetDomAudio() {
        AudioSource domAudio = null;
        float maxVolume = 0f;

        foreach (AudioSource audio in audios) {                        // Loop through all audios in our scene
            if (audio == GetComponent<AudioSource>()) { continue; }    // Skip if its this portal's audio

            if (audio.isPlaying) {                                     // Check if audio is actually playing

                // Very basic attenuation formula, inverse square law (https://www.sciencedirect.com/topics/engineering/inverse-square-law)
                float dist = Vector3.Distance(transform.position, audio.transform.position);
                float volume = audio.volume / (dist * dist);          
                if (volume > maxVolume) {                               // Just baisc finding max algorithm           
                    maxVolume = volume;
                    domAudio = audio;
                }
            }
        }
        return domAudio;
    }
}
