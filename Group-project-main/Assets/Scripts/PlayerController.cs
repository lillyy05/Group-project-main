using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public float horizontalInput;

    public GameManager gameManager; // Reference to GameManager for scoring

    private Rigidbody playerRb; // Reference to Rigidbody

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Initialize Rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        // Move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // Horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
    

        // Handle collision with obstacles
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Dog collided with an obstacle!");
            Destroy(gameObject); // Destroy the dog
            gameManager.GameOver(); // Trigger game over logic
        }
    }
}
