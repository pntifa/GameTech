using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public int HP = 100;
    public int dmg = 20;
    public Animator animator;

    [SerializeField] bool player=false;
    public GameObject monsterObject;
    public GameObject hpbar;
    public GameObject coll;
    bool isOpen = false;
    [SerializeField] private KeyCode interactKey1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode interactKey2 = KeyCode.Alpha2;

    public Slider healthbar;

    void Update(){
        healthbar.value=HP;
	//Depending on the key you press, you activate a certain animation that deals damage
        if (player==true)
            if (Input.GetKeyDown(interactKey1) || Input.GetKeyDown(interactKey2)){
                isOpen = !isOpen;
                HP-=dmg;
            }
            else if(HP <= 0){
		//if the enemy dies, it stops every animation and "dies"
                animator.SetBool("idleOne",false);
                animator.SetBool("AngryReaction",false);
                animator.SetBool("Dies",true);
               
		//the healthbar disappears after the hp is below or equal to zero
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
