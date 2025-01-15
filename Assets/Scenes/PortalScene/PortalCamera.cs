using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;  // The player's camera
    public Transform portal;       // The portal the player is looking through
    public Transform otherPortal;  // The target portal

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    
    // save the original position and rotation of camera s.t. if the user is too far, we keep the image as is
    void Start(){
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
    void Update()
    {
        float distanceToPortal = Vector3.Distance(playerCamera.position, otherPortal.position);

        if(distanceToPortal <= 15f){
            Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;

            transform.position = portal.position + playerOffsetFromPortal;
            Quaternion portalRotationDifference = Quaternion.Inverse(otherPortal.rotation) * portal.rotation;

            Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }else{
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
    }
}
