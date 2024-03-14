using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crate1 : MonoBehaviour
{
    public Animator animator;
    [SerializeField] bool player=false;
    bool isOpen = false;
    [SerializeField] private KeyCode interactKey = KeyCode.E; //Interact with a certain key

    public AudioSource src;
    public AudioClip sfx1;
    public GameObject canvas;
    public GameObject canvas2;

    void Update(){

        if (player==true)
            if (Input.GetKeyDown(interactKey)){
                src.clip=sfx1; //set the sound for the Crate
                src.Play(); //play the sound of the Crate
                isOpen = !isOpen;
                animator.SetBool("Open",isOpen);
                canvas.SetActive(!isOpen); //remove the current message
                canvas2.SetActive(isOpen); //make the new message appear
            }


    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            player=true;
        }
    }

     private void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player")){
            player=false;
        }
    }

}