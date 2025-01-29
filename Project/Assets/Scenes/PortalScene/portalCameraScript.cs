using UnityEngine;

public class PortalRenderer : MonoBehaviour
{
    public Transform mainCamera;       // Reference to the player's main camera (in VR/XR, typically the center eye anchor)
    public Transform portal;           // The portal this camera belongs to
    public Transform otherPortal;      // The portal this camera is rendering the view through
    public Renderer portalScreen;      // The mesh renderer for the portal's surface

    private RenderTexture portalTexture;

    void Start()
    {
        // Create a render texture for this portal camera
        portalTexture = new RenderTexture(Screen.width, Screen.height, 24);
        GetComponent<Camera>().targetTexture = portalTexture;

        // Assign the render texture to the portal screen's material
        portalScreen.material.mainTexture = portalTexture;
    }

    void LateUpdate()
    {
        // Step 1: Match this portal camera's position to simulate looking through the portal
        // Calculate the player's position relative to this portal
        Vector3 playerOffsetFromPortal = mainCamera.position - portal.position;

        // Set this camera's position relative to the other portal
        transform.position = otherPortal.position + playerOffsetFromPortal;

        // Step 2: Match this portal camera's rotation to the player's relative to the portal
        // Calculate the rotation difference between this portal and the player's camera
        Quaternion rotationDifference = Quaternion.Inverse(portal.rotation) * mainCamera.rotation;

        // Apply the rotation difference to the other portal's rotation
        transform.rotation = otherPortal.rotation * rotationDifference;

        // Step 3: Render this camera's view (this happens automatically if it's enabled in Unity)
        // Note: Since this script is attached to the portal camera, it will render whenever Unity renders this camera.
    }
}
