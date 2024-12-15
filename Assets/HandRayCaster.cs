// using UnityEngine;

// public class HandRaycaster : MonoBehaviour
// {
//     public Transform handOrigin; // Where the ray originates (e.g., palm or index tip)
//     public float maxDistance = 10f; // Max distance of the ray
//     private GameObject selectedObject;

//     void Update()
//     {
//         Ray ray = new Ray(handOrigin.position, handOrigin.forward);
//         RaycastHit hit;

//         // Cast the ray to detect objects
//         if (Physics.Raycast(ray, out hit, maxDistance))
//         {
//             if (hit.collider.CompareTag("Manipulable"))
//             {
//                 HighlightObject(hit.collider.gameObject);

//                 // Check for a selection gesture (e.g., pinch gesture)
//                 if (IsPinching()) // Implement IsPinching() based on hand tracking
//                 {
//                     selectedObject = hit.collider.gameObject;
//                     AttachToHand(selectedObject);
//                 }
//             }
//         }
//         else
//         {
//             ClearHighlight();
//         }

//         // Release the object on un-pinch
//         if (selectedObject != null && !IsPinching())
//         {
//             ReleaseObject();
//         }
//     }

//     void HighlightObject(GameObject obj) { /* Add glow or outline effect */ }
//     void ClearHighlight() { /* Remove highlight */ }
//     void AttachToHand(GameObject obj) { /* Attach object to hand's position */ }
//     void ReleaseObject() { /* Detach object and apply physics */ }
// }
