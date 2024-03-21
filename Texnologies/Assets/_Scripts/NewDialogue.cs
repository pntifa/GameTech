using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class NewDialogue : MonoBehaviour
{
   int index=2; 
   private void Update(){
        if(Input.GetMouseButtonDown(0) && transform.childCount > 1){
           transform.GetChild(index).gameObject.SetActive(true);
           index++;

           if (transform.childCount == index){
                index = 2;
           }
        }
   }
}

