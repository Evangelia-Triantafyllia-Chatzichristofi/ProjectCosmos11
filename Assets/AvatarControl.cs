using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarControl : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Ensure the Rigidbody2D has a Physics Material 2D for bouncing
        PhysicsMaterial2D bounceMaterial = new PhysicsMaterial2D();
        bounceMaterial.bounciness = 0.8f; // Adjust the bounciness value as needed

        // Apply the Physics Material 2D to the Polygon Collider 2D
        PolygonCollider2D polygonCollider = GetComponent<PolygonCollider2D>();
        if (polygonCollider != null)
        {
            polygonCollider.sharedMaterial = bounceMaterial;
        }
    }

    void Update()
    {
        // Get input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Move the player based on the input and speed
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Get the direction from the player to the cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 direction = mousePosition - transform.position;

        // Calculate the rotation angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the player towards the cursor
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}