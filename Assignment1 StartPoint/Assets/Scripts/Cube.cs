using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterfaces;

public class Cube : MonoBehaviour, IColor
{
    // Start is called before the first frame update
    MouseKeyPlayerController m_Controller;
    public float frequency = 0.0f;
    void Start()
    {
        m_Controller = new MouseKeyPlayerController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool IsSelected()
    {
        return GetComponent<Renderer>().material.color == Color.red;
    }

    void FixedUpdate()
    {
        if (IsSelected())
        {

            Vector3 moveInput = m_Controller.GetMoveInput();

            if (moveInput.z != 0.0f)
            {
                frequency += 0.05f;
                float delta = Mathf.Sin(frequency);
                moveInput.x += delta;

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
