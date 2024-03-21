using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class TimeManager : MonoBehaviour
{

    [SerializeField] private Texture2D skyboxNight;
    [SerializeField] private Texture2D skyboxSunrise;
    [SerializeField] private Texture2D skyboxDay;
    [SerializeField] private Texture2D skyboxSunset;

    [SerializeField] private Gradient gradientNightToSunrise;
    [SerializeField] private Gradient gradientSunriseToDay;
    [SerializeField] private Gradient gradientDayToSunset;
    [SerializeField] private Gradient gradientSunsetToNight;

    [SerializeField] private Light globalLight;
    private int minutes; 
    public int Minutes { get { return minutes; } set { minutes = value; OnMinuteChange(value); } }
    private int hours;
    public int Hours { get { return hours; } set { hours = value; OnHourChange(value); } }
    private int days;
    public int Days { get { return days; } set { days = value; } }

    private float tempSecond;


    public void Update(){
        tempSecond+= Time.deltaTime; // reading current minutes and seconds
        if (tempSecond >= 1){
            minutes +=100;
            tempSecond = 0;
        }
    }

    private void OnMinuteChange(int value){
        globalLight.transform.Rotate(Vector3.up, (1f / (1440f / 4f)) * 360f, Space.World);
        if(value >= 60){
            Hours++;
            minutes = 0;
        }
        if(Hours >= 24){ //day changing when minutes are 24
            Hours = 0;
            Days++;
        }
    }

    private void OnHourChange(int value){ //smooth transition between sky blocks
        if(value == 6){
            StartCoroutine(LerpSkybox(skyboxNight, skyboxSunrise, 10f));
            StartCoroutine(LerpLight(gradientNightToSunrise, 10f));
        }
        else if(value == 8){
            StartCoroutine(LerpSkybox(skyboxSunrise, skyboxDay, 10f));
            StartCoroutine(LerpLight(gradientSunriseToDay, 10f));
        }
        else if(value == 18){
            StartCoroutine(LerpSkybox(skyboxDay, skyboxSunset, 10f));
            StartCoroutine(LerpLight(gradientDayToSunset, 10f));
        }
        else if (value == 22){
            StartCoroutine(LerpSkybox(skyboxSunset, skyboxNight, 10f));
            StartCoroutine(LerpLight(gradientSunsetToNight, 10f));
        }
    }

    private IEnumerator LerpSkybox(Texture2D a, Texture2D b, float time){

        RenderSettings.skybox.SetTexture("_Texture1", a);
        RenderSettings.skybox.SetTexture("_Texture2", b);
        RenderSettings.skybox.SetFloat("_Blend", 0);
        for(float i = 0; i < time; i += Time.deltaTime){
            RenderSettings.skybox.SetFloat("_Blend", i / time);
            yield return null;
        }
        RenderSettings.skybox.SetTexture("_Texture1", b);
    }

    private IEnumerator LerpLight(Gradient lightGradient, float time){

        for(float i = 0; i < time; i += Time.deltaTime){
            globalLight.color = lightGradient.Evaluate(i / time);
            RenderSettings.fogColor = globalLight.color;
            yield return null;
        }
    }
}
