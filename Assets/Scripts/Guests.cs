using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guests : MonoBehaviour
{
    public bool canChooseQuest = false;
    public bool hasQuest = false;
    bool hasFoodQuest = false;
    bool hasDrinkQuest = false;
    //bool hasMusicQuest = false;
    //bool hasLightingQuest = false;
    bool hasFirstAidQuest = false;

    public GameObject foodText;
    public GameObject drinkText;
    //public GameObject musicText;
    //public GameObject lightingText;
    public GameObject firstAidText;

    public GameObject exclamationMark;
    
    // Start is called before the first frame update
    void Start()
    {
        //DrinkQuest();
    }

    // Update is called once per frame
    void Update()
    {
        if (canChooseQuest && !hasQuest)
        {
            ChooseQuest();
            hasQuest = true;
            canChooseQuest = false;
        }
    }

    void ChooseQuest()
    {
        int amountOfQuests = 3;
        int l = Random.Range(0, amountOfQuests);

         //need to test if the switch case statement works
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
        //wants music changed
        //identify when music changed
    }

    private void LightingChangeQuest()
    {
        //wants lighting changed (colour or brightness)
        //identify when colour changed changed
    }
    
    private void FirstAidQuest()
    {
        firstAidText.SetActive(true); //set active visual reference in scene, so player knows
        exclamationMark.SetActive(true);

        hasFirstAidQuest = true;
    }
}
