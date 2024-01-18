using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class NpcDialogueStory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text_dialogue;
    [SerializeField] string[] lines;
    [SerializeField] float text_speed;
    public GameObject canvas;
    bool player=false;
    bool isOpen = false;
    private int index;

    internal object currentSentence;

    void Start(){
        text_dialogue.text = string.Empty;
        canvas.SetActive(isOpen);
    }

    void Update(){
        if(player == true){
            if(Input.GetKeyDown(KeyCode.E)){
                if (text_dialogue.text == lines[index]){
                    NextLine2();
                }else{
                    StopAllCoroutines();
                    text_dialogue.text = lines[index];
                }
            }
            
        }
    }

    void StartDialogue2(){
        index = 0;
        StartCoroutine(TypeLine2(index));
    }

    IEnumerator TypeLine2(int _index){

        foreach (char c in lines[_index].ToCharArray()){
            text_dialogue.text +=c;
            yield return new WaitForSeconds(text_speed);
        }
    }

    void NextLine2(){
        if ( index < lines.Length - 1 ){
            index++;
            text_dialogue.text = string.Empty;
            StartCoroutine(TypeLine2(index));
        }
    }

     private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            player=true;
            text_dialogue.text = string.Empty;
            canvas.SetActive(true);
            StartDialogue2();
        }
    }
    
     private void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Player")){
            player=false;
            text_dialogue.text = string.Empty;
            canvas.SetActive(false);
        }
    }
}
