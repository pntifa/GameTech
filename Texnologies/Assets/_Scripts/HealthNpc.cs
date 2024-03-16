using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthNpc : MonoBehaviour
{
    Animator animator;
    public int HP = 100; //defines a certain amount of health to the NPC

    public Slider healthbar;
    [SerializeField] bool player=false;

    void Start(){

    animator = this.GetComponent<Animator>();
    animator.SetBool("wave",true);
    
    }

    void Update(){
        healthbar.value=HP; //updates the NPC's healthbar if it takes damage
    }


     private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            player=true;
            animator.SetBool("wave",false);
        }
    }
    
     private void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player")){
            player=false;
            animator.SetBool("wave",true);
        }
        
    }
}

