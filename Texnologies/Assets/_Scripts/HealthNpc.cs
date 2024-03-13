using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthNpc : MonoBehaviour
{

    public int HP = 100;

    public Slider healthbar;

    void Update(){
        healthbar.value=HP;
    }

}

