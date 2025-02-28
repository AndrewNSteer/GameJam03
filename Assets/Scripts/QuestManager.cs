using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public GameObject[] guests;
    public int timeBetweenQuests = 20;
    public float happiness;
    public float maxHappiness = 100;
    public int partyTime = 5;
    public TextMeshProUGUI clockTime;
    //public GameObject[] food; 
    //public GameObject[] drinks;


    // Start is called before the first frame update
    void Start()
    {
        partyTime = 5;
        StartCoroutine(QuestTimer());
        StartCoroutine(Clock());
        happiness = maxHappiness;
        clockTime.text = partyTime.ToString() + "pm";
    }

    // Update is called once per frame
    void Update()
    {
        clockTime.text = partyTime.ToString() + "pm";

        if (happiness <= 0 && partyTime < 11)
        {
            print("Game Over");
            //Add loss thing here
        }

        if (partyTime >= 11 && happiness > 0)
        {
            print("Win");
            //Add win thing here
        }
    }

    IEnumerator QuestTimer()
    {
        print(happiness);
        yield return new WaitForSeconds(timeBetweenQuests);
        SetQuest();
        StartCoroutine(QuestTimer());
    }

    IEnumerator Clock()
    {
            yield return new WaitForSeconds(60);
            partyTime++;
            StartCoroutine(Clock());
    }

    void SetQuest()
    {
        GameObject chosenGuest;
        //Generates a 50/50 chance to trigger a quest spawning
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            if (guests.Length > 0)
            {
                //picks a random guest to give a quest to
                int j = Random.Range(0, guests.Length);
                //will add logic to check if guest already has a quest active
                chosenGuest = guests[j];
                print(j);
                if (!chosenGuest.GetComponent<Guests>().hasQuest)
                {
                    chosenGuest.GetComponent<Guests>().canChooseQuest = true;
                }
                
            }
        }
        else if (i == 1)
        {
            print("No Quest this time");
            return;
        }
    }

    


}
