using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBox : MonoBehaviour
{
    public AudioClip[] music;
    int currentAudio = 0; //what's playing currently
    AudioSource audioSource;

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
    }


    void Update()
    {
        if (rightCol && GameObject.FindGameObjectWithTag("Player") && Input.GetKeyDown(KeyCode.E)) //find a way to do it so the player isn't accidentally in the other collider than the one they want
        {
            NextSoundRight();
        }
        else if (leftCol && GameObject.FindGameObjectWithTag("Player") && Input.GetKeyDown(KeyCode.E)) //find a way to do it so the player isn't accidentally in the other collider than the one they want
        {
            NextSoundLeft();
        }
    }


    void NextSoundRight() //goes to next sound
    {

            currentAudio = (currentAudio + 1) % music.Length; //next audio lined up and seeing if the int is in line with the length of the music array
            audioSource.clip = music[currentAudio];
            audioSource.Play(); //play sound
    }

    void NextSoundLeft() //goes to previous sound
    {
            currentAudio = (currentAudio - 1) % music.Length; //next audio lined up and seeing if the int is in line with the length of the music array
            audioSource.clip = music[currentAudio];
            audioSource.Play(); //play sound
    }
}
