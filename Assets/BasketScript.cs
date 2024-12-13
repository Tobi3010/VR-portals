using UnityEngine;

public class BasketScript : MonoBehaviour
{
    // float to keep track of what mode we are on
    public float hits;
    
    private Vector3 original_size;
    private Vector3 start_location;
    private bool isMoving = false;  // to check if the basket is moving
    private bool easyMode = false;  

    private void Start()
    {
        start_location = transform.position;  // Store the initial position and size of the basket
        original_size = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("object"))
        {
            print("GOAAAL!");
            hits++;
            if(hits == 2){
                transform.position = start_location;

            }
            // If third hit, restart 
            if (hits == 3) 
            {
                hits = 0;
                transform.position = start_location;
                transform.localScale = original_size; 
            }

        }
    }

    private void Update()
    {
        // Move the basket continuously if in mode 1 (hits == 1)
        if (hits == 1)
        {
            MoveBasket();
        }
        // Pulsing (scaling) basket behavior when in easy mode
        if (hits == 2)
        {
            BasketPulse();  // Handle pulsing or scaling behavior
        }

    }

    private void MoveBasket()
    {
        // Move the basket back and forth using a sine wave for smooth movement
            float speed = 0.2F;
            float distance = 5.0F;
            float offset = Mathf.Sin(Time.time * speed) * distance / 2;
            transform.position = new Vector3(start_location.x + offset, start_location.y, start_location.z);
    }

    private void BasketPulse()
    {
        // You can add logic here to "pulse" the basket, like changing its scale over time
        // For now, this function is only called in the "easyMode", but could be expanded
            float pulseSpeed = 1.0f;
            float scale = Mathf.PingPong(Time.time * pulseSpeed, 1.5f) + 0.25f;
            transform.localScale = new Vector3(scale, scale, scale);  // Scale the basket uniformly
    }
}
