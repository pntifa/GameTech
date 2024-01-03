using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCSystem : MonoBehaviour
{
    bool player_detection = false;
    public GameObject d_template;
    public GameObject canvas;

    // Update is called once per frame
    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.F)){
            canvas.SetActive(true);
            NewDialogue("I am done with this");
            canvas.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void NewDialogue(string text){
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canvas.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    } 

    private void OnTriggerEnter(Collider other){
        player_detection = true;
    }

    private void OnTriggerExit(Collider other){
        player_detection = false;
        canvas.SetActive(false);
    }
}
