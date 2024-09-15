using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterfaces;

public class Cube : MonoBehaviour, IColor, IJump
{
   
    MouseKeyPlayerController m_Controller;
    public float frequency = 0.0f;
    public bool isGrounded;
    public float rayLength = 1.0f;
    void Start()
    {
        m_Controller = new MouseKeyPlayerController();      
    }
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, rayLength);
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //isGrounded = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
        }
    }
    bool IsSelected()
    {
        return GetComponent<Renderer>().material.color == Color.red;
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        isGrounded = true;
    //    }
    //}
    void FixedUpdate()
    {
        if (IsSelected())
        {
            Jump();

            Vector3 moveInput = m_Controller.GetMoveInput();

            if (moveInput.z != 0.0f)
            {
                //frequency += 0.05f;
                //float delta = Mathf.Sin(frequency);
                //moveInput.x += delta;
            }
            transform.position += moveInput * Time.fixedDeltaTime * 10.0f;

            
        }
       
    }
    
    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void ResetColor()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
