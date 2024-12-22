using UnityEngine;
using UnityEngine.XR;

public class HandPositionOffset : MonoBehaviour
{
    public Transform leftHand;    // Reference to the left-hand GameObject
    public Transform rightHand;   // Reference to the right-hand GameObject
    public float offsetDistance = 1.5f;  // Distance to offset the hands

    private Transform headTransform;    // Reference to the VR headset/camera

    void Start()
    {
        // Find the head transform (typically the Main Camera in XR Rig)
        headTransform = Camera.main.transform;
    }

    void Update()
    {
        // Apply offset to the left and right hands
        if (leftHand != null)
        {
            OffsetHand(leftHand);
        }
        if (rightHand != null)
        {
            OffsetHand(rightHand);
        }
    }

    void OffsetHand(Transform hand)
    {
        // Offset hand position relative to the head
        Vector3 direction = (hand.position - headTransform.position).normalized; // Direction away from the head
        hand.position = headTransform.position + direction * offsetDistance;    // Move farther in the same direction
    }
}