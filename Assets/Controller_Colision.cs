using UnityEngine;

public class Controller_Colision : MonoBehaviour
{
    public float force;
    // Reference to the Renderer component for changing color
    private Renderer cubeRenderer;

    // Define some fun colors to randomly pick from
    private Color[] colors = new Color[]
    {
        Color.red, Color.blue, Color.green, Color.yellow, Color.cyan, Color.magenta, Color.white, Color.black
    };
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("DONT PUSH ME PLZ T_T");

            Rigidbody rigid_b = GetComponent<Rigidbody>();

            // Ensure the Rigidbody exists
            if (rigid_b != null)
            {
                // Calculate the direction of the force
                Vector3 forceDirection = (transform.position - other.transform.position).normalized;

                // Apply the force to the Rigidbody
                rigid_b.AddForce(forceDirection * force, ForceMode.Impulse);
            }
            ChangeColor();
        }
    }
    
    private void ChangeColor()
    {
        // Get the Renderer component if not already cached
        if (cubeRenderer == null)
        {
            cubeRenderer = GetComponent<Renderer>();
        }

        // Pick a random color from the array
        Color randomColor = colors[Random.Range(0, colors.Length)];

        // Apply the color to the cube's material
        cubeRenderer.material.color = randomColor;
    }

}

