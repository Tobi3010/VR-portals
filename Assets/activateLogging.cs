using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem;


public class CustomButtonAction : MonoBehaviour
{
    // Reference to the InputActionReference for "Custom button action"
    public InputActionReference customButtonActionReference;
    public DataLogger logger;
 

    private void OnEnable()
    {
        if (customButtonActionReference != null && customButtonActionReference.action != null)
        {
            // Subscribe to the action's performed event
            customButtonActionReference.action.performed += OnCustomButtonActionPerformed;
            // Enable the action
            customButtonActionReference.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (customButtonActionReference != null && customButtonActionReference.action != null)
        {
            // Unsubscribe from the action's performed event
            customButtonActionReference.action.performed -= OnCustomButtonActionPerformed;
            // Disable the action
            customButtonActionReference.action.Disable();
        }
    }

    private void OnCustomButtonActionPerformed(InputAction.CallbackContext context)
    {
        if (logger == null)
        {
            Debug.LogError("Logger is null! Ensure the logger is assigned in the Inspector.");
            return;
        }
        logger.StartLogging();

    }
}   