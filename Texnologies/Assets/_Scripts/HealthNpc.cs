using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthNpc : MonoBehaviour
{

    public int HP = 100; //defines a certain amount of health to the NPC

    public Slider healthbar;

    void Update(){
        healthbar.value=HP; //updates the NPC's healthbar if it takes damage
    }

}

