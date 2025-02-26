using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameObject[] guests;
    public int timeBetweenQuests = 20;
    //public GameObject[] food; 
    //public GameObject[] drinks;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(QuestTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator QuestTimer()
    {
        print("Repeated");
        yield return new WaitForSeconds(timeBetweenQuests);
        //SetQuest();
        StartCoroutine(QuestTimer());
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
                chosenGuest.GetComponent<Guests>().canChooseQuest = true;
            }
        }
        else if (i == 1)
        {
            return;
        }
    }

    


}
