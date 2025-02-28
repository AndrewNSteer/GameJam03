using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBox : MonoBehaviour
{
    public AudioClip[] music;
    int currentAudio = 0; //what's playing currently
    int totalAudio = 4;
    AudioSource audioSource;
    //Guests guests;

    public GameObject rightSound;
    public GameObject leftSound;

    Collider leftCol;
    Collider rightCol;


    void Start()
    {
        //collider components
        leftCol = leftSound.GetComponent<BoxCollider>(); 
        rightCol = rightSound.GetComponent<BoxCollider>();
        //audio source component
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music[currentAudio];
        
    }


    void Update()
    {

    }


    public void NextSoundRight() //goes to next sound
    {

            


        if (currentAudio < totalAudio)
        {
            currentAudio = (currentAudio + 1) % music.Length; //next audio lined up and seeing if int is in line with the length of the music array
            audioSource.clip = music[currentAudio];
            audioSource.Play(); //play sound
        }

        else if (currentAudio > totalAudio)
        {
            audioSource.Play();

            /*

            switch (currentAudio)
            {
                case 0:

                    print("Audio" + currentAudio); //Funky
                    
                    break;
                case 1:
                    print("Audio" + currentAudio); //Pixel 
                    
                    break;
                case 2:
                    print("Audio" + currentAudio); //Trance
                    ;
                    break;
                case 3:
                    print("Audio" + currentAudio); //Rock
                    
                    break;
            }
            */
        }
    }

    public void NextSoundLeft() //goes to previous sound
    {
        
            currentAudio = (currentAudio - 1) % music.Length; //next audio lined up and seeing if int is in line with the length of the music array
            audioSource.clip = music[currentAudio];
            audioSource.Play(); //play sound
    }
}
