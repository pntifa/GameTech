using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthFlyingInsect : MonoBehaviour
{
     public int HP = 100;
    public int dmg = 20;

    Animator animator;

    [SerializeField] bool player=false;
    public GameObject monsterObject;
    public GameObject hpbar;
    public GameObject coll;
    bool isOpen = false;
    [SerializeField] private KeyCode interactKey1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode interactKey2 = KeyCode.Alpha2;

    public Slider healthbar;

    void Start(){

    animator = this.GetComponent<Animator>();
    animator.SetBool("Fly",true);
    
    }

    void Update(){
        healthbar.value=HP;

        if (player==true)
            if (Input.GetKeyDown(interactKey1) || Input.GetKeyDown(interactKey2)){
                isOpen = !isOpen;
                HP-=dmg;
            }
            else if(HP <= 0){

                animator.SetBool("Fly",false); //if character is nearby, open the door
                hpbar.SetActive(false);
                
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
        if (HP <= 0){
            monsterObject.SetActive(false);
            coll.SetActive(false);
        }
    }

}
