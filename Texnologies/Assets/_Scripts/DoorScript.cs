using UnityEngine;

public class DoorScript : MonoBehaviour
{
  Animator animator;
  [SerializeField] bool player=false;
  bool isOpen = false;
  [SerializeField] private KeyCode interactKey = KeyCode.E;

  void Start(){

    animator = this.GetComponent<Animator>();

  }

  void Update(){

    if (player==true)
      if (Input.GetKeyDown(interactKey)){
        isOpen = !isOpen;
        animator.SetBool("character_nearby",isOpen);
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