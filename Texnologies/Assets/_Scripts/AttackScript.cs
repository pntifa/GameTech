using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject MainCharacter;

//Attack Animation according to the pressed button
    void Update()
    {
        if(Input.GetButtonDown("Attack")){
            MainCharacter.GetComponent<Animator>().Play("Stable Sword Outward Slash");
        }
        if(Input.GetButtonDown("Attack Combo")){
            MainCharacter.GetComponent<Animator>().Play("One Hand Sword Combo");
        }

    }
}