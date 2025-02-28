using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Guests : MonoBehaviour
{
    public GameObject[] music;
    
    GameObject currentMusicRequest; 
    GameObject musicRequest;
    GameObject musicObject;

    AudioClip musicPlaying; 

    public bool canChooseQuest = false;
    public bool hasQuest = false;
    bool hasFoodQuest = false;
    bool hasDrinkQuest = false;
    bool hasMusicQuest = false;
    //bool hasLightingQuest = false;
    bool hasFirstAidQuest = false;

    public GameObject foodText;
    public GameObject drinkText;
    public GameObject musicText;
    public TextMeshProUGUI lightText;
    public GameObject firstAidText;
    public GameObject exclamationMark;

    //Light Variables
    public Light roomLight;
    Color Red = Color.red;
    Color Blue = Color.blue;
    Color Pink = Color.magenta;
    Color Green = Color.green;
    Color Yellow = Color.yellow;
    Color White = Color.white;
    Color currentColour;
    public Color[] colourList;
    public Dictionary<Color, string> colourDict;
            Color requestedColour;
        bool colourRequested = false;
    // Start is called before the first frame update

    void Awake()
    {
        colourList = new Color[] { Color.red, Color.blue, Color.green, Color.yellow, Color.magenta, Color.white };
        colourDict = new Dictionary<Color, string>
        {
            { Color.red, "Red" },
            { Color.blue, "Blue" },
            { Color.green, "Green" },
            { Color.yellow, "Yellow" },
            { Color.magenta, "Pink" },
            { Color.white, "White" }
        };
        
    }
    void Start()
    {
        //MusicChangeQuest();

        roomLight.color = White;
        currentColour = roomLight.color;
        LightingChangeQuest();
    }

    // Update is called once per frame
    void Update()
    {
        currentColour = roomLight.color;
        //musicPlaying = musicObject.GetComponent<AudioSource>().clip; //access audio playing

        if (canChooseQuest && !hasQuest)
        {
            ChooseQuest();
            hasQuest = true;
            canChooseQuest = false;
        }


        if (hasMusicQuest && musicPlaying == musicRequest) //if player has quest, and the music playing is the same as the quest music request
        {
            print("music is served");

            //musicText.enabled = false; //SetActive(false);
            exclamationMark.SetActive(false);

            hasMusicQuest = false;
            hasQuest = false;
            canChooseQuest = true;
        }
        
        if (colourRequested && requestedColour == currentColour)
        {
            Debug.Log("Colour match");
            lightText.gameObject.SetActive(false);
            exclamationMark.SetActive(false);
            colourRequested = false;  // Reset the request status after completing the action
        }
        
    }

    void ChooseQuest()
    {
        int amountOfQuests = 5;
        int l = Random.Range(0, amountOfQuests);

        switch (l)
        {
            case 0:
                print("Quest" + l); //food
                FoodQuest();
                break;
            case 1:
                print("Quest" + l); //drink 
                DrinkQuest();
                break;
            case 2:
                print("Quest" + l); //music change
                MusicChangeQuest();
                break;
            case 3:
                print("Quest" + l); //lighting
                LightingChangeQuest();
                break;
            case 4:
                print("Quest" + l); //first aid
                FirstAidQuest();
                break;
            default:
                print("out of range");
                break;
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Food" && hasFoodQuest)
        {
            print("food is served");

            foodText.SetActive(false);
            exclamationMark.SetActive(false); 
            Destroy(collision.gameObject);

            hasFoodQuest = false;
            hasQuest = false;
            canChooseQuest = true;
        }

        else if(collision.collider.tag == "Drinks" && hasDrinkQuest)
        {
            print("drink is served");

            drinkText.SetActive(false);
            exclamationMark.SetActive(false);
            Destroy(collision.gameObject);
            
            hasDrinkQuest = false;
            hasQuest = false;
            canChooseQuest = true;
        }

        else if (collision.collider.tag == "FirstAid" && hasFirstAidQuest)
        {
            print("First aid is given");

            firstAidText.SetActive(false);
            exclamationMark.SetActive(false);
            Destroy(collision.gameObject);

            hasFirstAidQuest = false;
            hasQuest = false;
            canChooseQuest = true;
        }
    }

    private void FoodQuest()
    {  
        foodText.SetActive(true); //set active visual reference in scene, so player knows
        exclamationMark.SetActive(true);

        hasFoodQuest = true;
    }

    private void DrinkQuest()
    {
        drinkText.SetActive(true); //set active visual reference in scene, so player knows
        exclamationMark.SetActive(true);

        hasDrinkQuest = true;
    }


    private void MusicChangeQuest()
    {
        int i = Random.Range(0, music.Length);
        //print("Method is being called"); //it works, but if statement doesn't
        if (music[i] != currentMusicRequest) //if the music chosen is different to the music playing
        {
            musicRequest = music[i];
            //print("Please change the music to " + musicRequest);
            musicText.GetComponent<TextMeshProUGUI>().text = "Please change the music to " + musicRequest.ToString();
        }
        else if (music[i] == currentMusicRequest) //if the music chosen is the same as the music playing
        {
            MusicChangeQuest(); //resets method, so new number can be chosen
            print("change random range");
        }

        exclamationMark.SetActive(true);
        hasMusicQuest = true;
    }

    public void LightingChangeQuest()
    {
        //similar to music have a current light colour variable and have an array of colours
        //Buttons on wall or a remote that can press to change light colour
        //wants lighting changed (colour or brightness)
        //identify when colour changed changed

        int i = Random.Range(0, colourList.Length);
        requestedColour = colourList[i];

        if (requestedColour == currentColour && !colourRequested)
        {
            i = Random.Range(0, colourList.Length);
            requestedColour = colourList[i];
        }

        else if (requestedColour != currentColour && !colourRequested)
        {
            colourRequested = true;
            lightText.gameObject.SetActive(true);
            exclamationMark.SetActive(true);
            string colourName = colourDict[colourList[i]];
            lightText.text = "I want the lights to be " + colourName;
        }


            if (colourRequested && requestedColour == currentColour)
            {
                print("Colour match");
                lightText.gameObject.SetActive(false);
                exclamationMark.SetActive(false);
                colourRequested = false;
            } 


    }
    
    private void FirstAidQuest()
    {
        firstAidText.SetActive(true); //set active visual reference in scene, so player knows
        exclamationMark.SetActive(true);

        hasFirstAidQuest = true;
    }
}
