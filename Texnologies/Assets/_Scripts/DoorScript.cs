using UnityEngine;

public class DoorScript : MonoBehaviour
{
 
 Animator animator;

  void Start(){

    animator = this.GetComponent<Animator>();

  }

  void Update(){

    if(Input.GetKeyDown(KeyCode.P)){
      animator.SetBool("character_nearby",true);
    }
    else if (Input.GetKeyDown(KeyCode.C)) {
      animator.SetBool("character_nearby",false);
    }
  }

}