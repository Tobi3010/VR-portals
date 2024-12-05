using UnityEngine;
using System.Collections;

public class FlowerPortal : MonoBehaviour
{
    public Transform targetPortal; // Reference to the paired portal
    public float teleportCooldown = 1f; // Cooldown after teleporting
    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (canTeleport && other.CompareTag("Player")) // Ensure it's the player or another target object
        {
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
