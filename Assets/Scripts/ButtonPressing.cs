using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressing : MonoBehaviour
{
    public Light roomLight;
    //Declare buttons here
    public GameObject blueButton;
    

 void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //ray checks if button tag
            if (hit.collider.CompareTag("button"))
            {                
                if (Input.GetMouseButtonDown(0))
                {
                    OnButtonPressed(hit.collider.gameObject);
                }
            }

        }
    }


    void OnButtonPressed(GameObject button)
    {
        //do a switch depending on what button is pressed?
        switch (button.name)
        {
            case "blueButton":
                print("Lights go blue");
                roomLight.color = Color.blue;
                break;
        }
    }
}

