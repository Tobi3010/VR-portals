using UnityEngine;

public class Flowerpoint : MonoBehaviour
{

    public GameObject flowerPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Flowerpoint"))
        {
            print("YOU HAVE REACHED FLOWERPOINT, MAYBE YOUR NOT A LOOSER AFTER ALL?!?");
        }
    }
}
