using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;  // The player's camera
    public Transform portal;       // The portal the player is looking through
    public Transform otherPortal;  // The target portal

    void Update()
    {
        // 1. Calculate position offset
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;

        // Translate the camera position to the new portal
        transform.position = portal.position + playerOffsetFromPortal;

        // 2. Calculate rotation offset
        // Find the relative rotation difference between the two portals
        Quaternion portalRotationDifference = Quaternion.Inverse(otherPortal.rotation) * portal.rotation;

        // Apply the rotation difference to the player's forward direction
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;

        // Set the camera's rotation, maintaining yaw alignment
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
