using UnityEngine;
using UnityEngine.Events;

public class buttonAction : MonoBehaviour
{
    public BasketScript basket; // Reference to the BasketScript

    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;
    public int button_mode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPressed = false;
    }
    private void OnTriggerEnter(Collider other){
        if (!isPressed){
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }
    private void OnTriggerExit(Collider other){
        if(other == presser){
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }
    public void SetBasketMode()
    {
        // setting the mode for the basket game
        if (basket != null)
        {
            basket.SetBasketMode(button_mode);
        }
    }

}
