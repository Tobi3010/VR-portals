using UnityEngine;
using System.Collections;

public class PortalTeleport : MonoBehaviour
{
    public Transform targetPortal; // Reference to the paired portal
    public float teleportCooldown = 1f; // Cooldown after teleporting
    private bool canTeleport = true;
    
    public bool canblock = false;
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;

    void Start(){
        if(canblock){
            frame1.SetActive(false);
            frame2.SetActive(false);
            frame3.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canTeleport && other.CompareTag("Player")) // Ensure it's the player or another target object
        {
            if(canblock){
                frame1.SetActive(true);
                frame2.SetActive(true);
                frame3.SetActive(true);
            }
            StartCoroutine(Teleport(other));
            
        }
    }

    private IEnumerator Teleport(Collider other)
    {
        canTeleport = false;

        // Teleport to the target portal position
        other.transform.position = targetPortal.position;

        // Optional: Add a slight delay or cooldown
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }
}
