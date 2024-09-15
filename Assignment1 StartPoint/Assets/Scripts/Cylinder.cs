using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInterfaces;

public class Cylinder : MonoBehaviour, IColor
{
    MouseKeyPlayerController m_Controller;
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
        return GetComponent<Renderer>().material.color == Color.green;
    }

    void FixedUpdate()
    {
        if (IsSelected())
        {
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
