using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if XR_HANDS_1_1_OR_NEWER
using UnityEngine.XR.Hands;
#endif

namespace UnityEngine.XR.Interaction.Toolkit.Samples.Hands
{
    public class PokeGesturePush : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Force to apply when the finger touches an object.")]
        private float pushForce = 10f;

        [SerializeField]
        [Tooltip("The index finger tip GameObject (should have a Collider).")]
        private Transform indexFingerTip;

        private void OnEnable()
        {
            // Ensure the finger tip collider is set to trigger
            if (indexFingerTip != null)
            {
                var collider = indexFingerTip.GetComponent<Collider>();
                if (collider != null)
                    collider.isTrigger = true;
            }
        }

        private void OnDisable()
        {
            // Optional cleanup or state reset
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody != null)
            {
                // Calculate push direction (away from the finger tip)
                Vector3 pushDirection = (other.transform.position - indexFingerTip.position).normalized;

                // Apply push force to the object
                other.attachedRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }

        private void OnDrawGizmos()
        {
            if (indexFingerTip != null)
            {
                // Draw the interaction point for debugging
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(indexFingerTip.position, 0.01f);
            }
        }
    }
}
