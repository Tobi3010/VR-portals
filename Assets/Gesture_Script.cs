using UnityEngine;

public class FingerGestureSummon : MonoBehaviour
{
    public Transform leftHand, rightHand; // Reference to the left and right hand
    public GameObject objectToSummon; // Object to be summoned
    public float pullSpeed = 5f; // Speed at which the object pulls towards you
    public float maxPullDistance = 5f; // Max distance at which the object can be pulled
    private bool isSummoning = false; // To check if summon is active

    private OVRHand ovrLeftHand;
    private OVRHand ovrRightHand;

    private void Start()
    {
        // Set up the Oculus Hand components (if using Oculus)
        ovrLeftHand = leftHand.GetComponent<OVRHand>();
        ovrRightHand = rightHand.GetComponent<OVRHand>();
    }

    void Update()
    {
        // Check if the "come here" gesture is made
        if (IsComeHereGesture())
        {
            isSummoning = true;
        }
        else
        {
            isSummoning = false;
        }

        // If summoning, move the object towards the user
        if (isSummoning)
        {
            PullObjectTowardsUser();
        }
    }

    bool IsComeHereGesture()
    {
        // Detect if both index and middle fingers are bent enough (threshold for "come here" gesture)

        // Check if index and middle fingers are bent (use angles or flex data)
        bool isIndexBend = IsFingerBending(OVRHand.HandFinger.Index);
        bool isMiddleBend = IsFingerBending(OVRHand.HandFinger.Middle);

        return isIndexBend && isMiddleBend;
    }

    bool IsFingerBending(OVRHand.HandFinger finger)
    {
        // Check the bend of the finger using finger curl (flex) value
        // Flex value is between 0 (fully extended) to 1 (fully curled)
        float bendThreshold = 0.5f;  // Threshold for how much bend is required to trigger the action

        float fingerBend = ovrLeftHand.GetFingerCurl(finger); // For left hand; use ovrRightHand for the right hand
        return fingerBend > bendThreshold;
    }

    void PullObjectTowardsUser()
    {
        // Smoothly move the object towards the user's hand
        float step = pullSpeed * Time.deltaTime;
        objectToSummon.transform.position = Vector3.MoveTowards(objectToSummon.transform.position, transform.position, step);

        // Ensure the object doesn't exceed max pull distance
        if (Vector3.Distance(objectToSummon.transform.position, transform.position) < 0.1f)
        {
            objectToSummon.transform.position = transform.position;  // Snap to the final position
        }
    }
}

