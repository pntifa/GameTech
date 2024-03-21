using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float time;
    public float fullDayLength; //Sets day length
    public float startTime = 0f;
    private float timeRate;

    public Vector3 noon;

    [Header("Sun")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;

    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;

    [Header("Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionsIntensityMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        timeRate = 1.0f / fullDayLength;
        time = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        time += timeRate * Time.deltaTime; //time increase

        if(time >= 1.0f) time = 0.0f;

        sun.transform.eulerAngles = (time - 0.25f) * noon * 10.0f;
        sun.transform.eulerAngles = (time - 0.75f) * noon * 10.0f; //light rotation

        sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time); //light intensity

        sun.color = sunColor.Evaluate(time);
        moon.color = moonColor.Evaluate(time); // change colors

        // enabling/disabling sun & moon
        if (sun.intensity == 0 && sun.gameObject.activeInHierarchy) sun.gameObject.SetActive(false);
        else if (sun.intensity > 0 && !sun.gameObject.activeInHierarchy) sun.gameObject.SetActive(true);

        if (moon.intensity == 0 && moon.gameObject.activeInHierarchy) moon.gameObject.SetActive(false);
        else if (moon.intensity > 0 && !moon.gameObject.activeInHierarchy) moon.gameObject.SetActive(true);

        //lighting and reflection
        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionsIntensityMultiplier.Evaluate(time); 
    }
}


