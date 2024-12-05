using UnityEngine;

public class Controller_Colision : MonoBehaviour
{
    public float force;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().position = Vector3.zero;
            print("SLAP ME");
        }
    }

}

