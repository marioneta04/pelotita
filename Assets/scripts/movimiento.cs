using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Vector2 inputVector;
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        rigidbody.AddForce (inputVector.x * speed, 0f, inputVector.y * speed, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(0f, jumpForce, 0f);
        }

    }
}
