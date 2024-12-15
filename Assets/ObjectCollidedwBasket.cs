using UnityEngine;

public class ObjectCollidedwBasket : MonoBehaviour

{
    private Vector3 originalPosition; 

    void Start()
    {
        originalPosition = transform.position;  // storing the original position of the object
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket")) 
        {
            transform.position = originalPosition;
        }
    }
}

