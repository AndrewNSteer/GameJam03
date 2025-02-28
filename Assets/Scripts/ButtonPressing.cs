using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressing : MonoBehaviour
{
    MusicBox musicScript;
    public GameObject musicBox;
    public Light roomLight;

    

    private void Start()
    {
        musicScript = musicBox.GetComponent<MusicBox>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //ray checks if button tag
            if (hit.collider.CompareTag("Button"))
            {                
                if (Input.GetKeyDown(KeyCode.E)) //currently left click but could change to E or smth
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
            case "BlueButton":
                print("Lights go blue");
                roomLight.color = Color.blue;
                break;
            case "RedButton":
                print("Lights go red");
                roomLight.color = Color.red;
                break;
            case "GreenButton":
                print("Lights go Green");
                roomLight.color = Color.green;
                break;

            case "PinkButton":
                print("Lights go Pink");
                roomLight.color = Color.magenta;
                break;    

            case "WhiteButton":
                print("Lights go White");
                roomLight.color = Color.white;
                break;

            case "YellowButton":
                print("Lights go Yellow");
                roomLight.color = Color.yellow;
                break;

            case "RightButton":
                print("next music");
                musicScript.NextSoundRight();
                break;
            case "LeftButton":
                print("previous music");
                musicScript.NextSoundLeft();
                break;
        }
    }
}

