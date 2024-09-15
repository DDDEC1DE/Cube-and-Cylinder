using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterfaces;

public class Cylinder : MonoBehaviour, IColor, IJump
{
    MouseKeyPlayerController m_Controller;
    private Rigidbody rb;
    public float jumpVelocity = 10f; 
    public float rayLength = 1.1f;
    private bool isGrounded = false;
    void Start()
    {
        m_Controller = new MouseKeyPlayerController();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, rayLength);
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
        }
    }
    bool IsSelected()
    {
        return GetComponent<Renderer>().material.color == Color.green;
    }

    void FixedUpdate()
    {
        if (IsSelected())
        {
            Jump();

            transform.position += m_Controller.GetMoveInput() * Time.fixedDeltaTime * 10.0f;
        }

    }

    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void ResetColor()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
