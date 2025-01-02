using UnityEngine;

public class BasketScript : MonoBehaviour
{
    // float to keep track of what mode we are on
    public float hits;
    
    private Vector3 original_size;
    private Vector3 start_location;

    private void Start()
    {
        start_location = transform.position;  // we want to store the initial position and size of the basket
        original_size = transform.localScale; // so that we can restore its original size and location
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("object"))
        {
            print("GOAAAL!");   // some sort of console indicator that this works!

            hits++; 
            if(hits == 2){
                transform.position = start_location;    // if we enter mode 2, pulsing, we want to return the basket to its original location
            }
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
        // if the basket is in any specific mode, we want it to keep calling the function of that mode, hence why we are calling them in update
        if (hits == 1)
        {
            MoveBasket();
        }
        if (hits == 2)
        {
            BasketPulse();  
        }

    }

    private void MoveBasket()
    {
        // hard mode, even though it's slow lol
        // move the basket back and forth using the sine wave as it loops between -1 and 1
            float speed = 0.5F;
            float distance = 5.0F;
            float offset = Mathf.Sin(Time.time * speed) * distance / 2;
            transform.position = new Vector3(start_location.x + offset, start_location.y, start_location.z);
    }

    private void BasketPulse()
    {
            // this is supposed to be the easy mode, where the basket keeps sizing itself up from its original size and back down.
            // we only want the basket to grow to 1.5 of its size and then slowly go back down, so we will use the sine wave still
            // but now we get the absolute value so we go from 0 to 1.

            float pulseSpeed = 0.5f;
            float maxGrowth = 0.5f; // Object grows up to 50% larger
            float originalScale = 1.0f; // Original size of the object

            float scale = Mathf.Abs(Mathf.Sin(Time.time * pulseSpeed)) * maxGrowth + originalScale;
            transform.localScale = new Vector3(scale, scale, scale);  // Scale the basket uniformly
    }
    
    public void SetBasketMode(int mode)
    {
        // a function so the button can trigger the mode in the basket
        hits = mode;

        Debug.Log("Basket mode set to: " + mode);
    }
}

