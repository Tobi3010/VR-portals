using UnityEngine;

public class BasketScript : MonoBehaviour
{
    // float to keep track of what mode we are on
    public float hits;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("object"))
        {
            print("GOAAAL!");

            // if this is the first hit, the object should be teleported somewhere else, and the basket moves left and right

            // if this is the second, the basket starts pulsing (growing bigger and smaller

            // if third, restart

        } 
    }

}

