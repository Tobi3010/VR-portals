using UnityEngine;

public class OffsetHand : MonoBehaviour
{
    // Add your variables and methods here
    public Transform leftHand;
    public Transform rightHand;
    public float offsetDistance = 5f;

    void Update()
    {
        // Example logic to move hands away from the player
        Vector3 offset = new Vector3(offsetDistance, 0, 0);  // Example offset
        if (leftHand != null)
        {
            leftHand.position = Camera.main.transform.position + offset;
        }
        if (rightHand != null)
        {
            rightHand.position = Camera.main.transform.position + offset;
        }
    }
}
