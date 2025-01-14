using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;
        
        // float angularDifferenceBetweenPortalRotation = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        // Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotation, Vector3.up);
        // Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        // transform.rotation.x = Quaternion.LookRotation(newCameraDirection, Vector3.up).x;

        float angularDifferenceBetweenPortalRotation = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotation, Vector3.up);

        // Calculate the new camera direction while ignoring pitch and roll
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;

        // Create a rotation that only considers yaw (ignore x and z components)
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

        // Apply the yaw-only rotation to the transform
        //transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

    }
}