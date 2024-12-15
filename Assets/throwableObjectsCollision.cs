using UnityEngine;

public class throwableObjectsCollided : MonoBehaviour
{
    private Vector3 originalPosition; 

    void Start()
    {
        // storing the original position of the object
        originalPosition = transform.position;
    }

    // if the object collided with the basket, then return it to its original position
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket")) // Replace "Player" with your desired tag
        {
            transform.position = originalPosition;
        }
    }
}
