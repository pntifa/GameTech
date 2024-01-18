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
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    public AudioSource src;
    public AudioClip sfx1;
    public GameObject canvas;
    public GameObject canvas2;
    
    void Update(){
        
        if (player==true)
            if (Input.GetKeyDown(interactKey)){
                src.clip=sfx1;
                src.Play();
                isOpen = !isOpen;
                animator.SetBool("Open",isOpen);
                canvas.SetActive(!isOpen);
                canvas2.SetActive(isOpen);
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
