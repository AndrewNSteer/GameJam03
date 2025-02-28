using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Guests : MonoBehaviour
{

    QuestManager qmScript;
    public GameObject qm;
    public bool canChooseQuest = false;
    public bool hasQuest = false;
    bool hasFoodQuest = false;
    bool hasDrinkQuest = false;
    bool hasMusicQuest = false;
    bool hasLightQuest = false;
    bool hasFirstAidQuest = false;
    
    //Icons
    public GameObject foodText;
    public GameObject drinkText;
    public GameObject musicText;
    public TextMeshProUGUI lightText;
    public GameObject firstAidText;
    public GameObject exclamationMark;
    
    //Music Variables
    public GameObject musicObject;
    public AudioClip[] music;
    AudioClip musicRequest;
    AudioClip musicPlaying;
    bool isMusicRequested = false;

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
    bool isColourRequested = false;
    // Start is called before the first frame update

    void Awake()
    {
        qmScript = qm.GetComponent<QuestManager>();
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
        //LightingChangeQuest();

    }

    // Update is called once per frame
    void Update()
    {
        currentColour = roomLight.color;
        musicPlaying = musicObject.GetComponent<AudioSource>().clip; //access audio playing

        if (canChooseQuest && !hasQuest)
        {
            ChooseQuest();
            hasQuest = true;
            canChooseQuest = false;
        }


        if (isMusicRequested && musicRequest == musicPlaying) //if player has quest, and the music playing is the same as the quest music request
        {
            print("music is served");

            musicText.SetActive(false);
            exclamationMark.SetActive(false);

            isMusicRequested = false;
            hasMusicQuest = false;
            hasQuest = false;
            canChooseQuest = true;
            qmScript.happiness += 20;
        }

        if (isColourRequested && requestedColour == currentColour)
        {
            Debug.Log("Colour match");
            lightText.gameObject.SetActive(false);
            exclamationMark.SetActive(false);
            isColourRequested = false;  // Reset the request status after completing the action
            hasLightQuest = false;
            hasQuest = false;
            canChooseQuest = true;
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

    
    public void OnCollisionEnter(Collision collision)
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
            qmScript.happiness += 20;
        }

        else if (collision.collider.tag == "Drinks" && hasDrinkQuest)
        {
            print("drink is served");

            drinkText.SetActive(false);
            exclamationMark.SetActive(false);
            Destroy(collision.gameObject);

            hasDrinkQuest = false;
            hasQuest = false;
            canChooseQuest = true;
            qmScript.happiness += 20;
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
            qmScript.happiness += 20;
        }
    }

    public void FoodQuest()
    {  
        foodText.SetActive(true); //set active visual reference in scene, so player knows
        exclamationMark.SetActive(true);
        qmScript.happiness -= 20;
        hasFoodQuest = true;
    }

    public void DrinkQuest()
    {
        drinkText.SetActive(true); //set active visual reference in scene, so player knows
        exclamationMark.SetActive(true);
        qmScript.happiness -= 20;
        hasDrinkQuest = true;
    }


    public void MusicChangeQuest()
    {
        int i = Random.Range(0, music.Length);
        musicRequest = music[i];

        if (musicRequest == musicPlaying) //if the music chosen is the same as to the music playing
        {
            i = Random.Range(0, music.Length);
            musicRequest = music[i];
            //print("Please change the music to " + musicRequest);
            print("change random range");
        }
        else if (musicRequest != musicPlaying) //if the music chosen is different the music playing
        {
            isMusicRequested = true;
            exclamationMark.SetActive(true);
            musicText.SetActive(true);
            musicText.GetComponent<TextMeshProUGUI>().text = "Please change the music to " + musicRequest.ToString();
        }

        
    }

    public void LightingChangeQuest()
    {
        qmScript.happiness -= 20;
        hasLightQuest = true;
        //similar to music have a current light colour variable and have an array of colours
        //Buttons on wall or a remote that can press to change light colour
        //wants lighting changed (colour or brightness)
        //identify when colour changed changed

        int i = Random.Range(0, colourList.Length);
        requestedColour = colourList[i];

        if (requestedColour == currentColour && !isColourRequested)
        {
            i = Random.Range(0, colourList.Length);
            requestedColour = colourList[i];
        }

        else if (requestedColour != currentColour && !isColourRequested)
        {
            isColourRequested = true;
            lightText.gameObject.SetActive(true);
            exclamationMark.SetActive(true);
            string colourName = colourDict[colourList[i]];
            lightText.text = "I want the lights to be " + colourName;
        }
    }
    
    public void FirstAidQuest()
    {
        qmScript.happiness -= 20;
        firstAidText.SetActive(true); //set active visual reference in scene, so player knows
        exclamationMark.SetActive(true);
        hasFirstAidQuest = true;
    }
}
