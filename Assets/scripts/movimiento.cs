using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movimiento : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Vector2 inputVector;
    public Rigidbody rigidbody;
    public bool CanJump;
    public float velocityMagnitude;
    public Vector3 velocity;
    public int CollectedItems;

    public TMPro.TextMeshProUGUI scoreText;


    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        CanJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        rigidbody.AddForce (inputVector.x * speed, 0f, inputVector.y * speed, ForceMode.Impulse);

        velocity = rigidbody.velocity;
        velocityMagnitude = velocity.magnitude;

        if (Input.GetKeyDown(KeyCode.Space) && CanJump )
        {
            rigidbody.AddForce(0f, jumpForce, 0f);
            CanJump = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag( "Ground"))
        {
            CanJump = true;
        }

        if (collision.gameObject.CompareTag("Killzone"))
        {
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.CompareTag("goal"))
        {
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            CollectedItems++;
            scoreText.text = CollectedItems.ToString();
        }
    }
}
