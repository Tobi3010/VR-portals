using UnityEngine;

public class flowerAppear : MonoBehaviour
{
    public GameObject objectToAppear; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("SUPRISE MOTHER FUCKER!");
            objectToAppear.SetActive(true);
        }
    }

}

