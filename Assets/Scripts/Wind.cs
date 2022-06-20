using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private float timeElapsed;
    private float windSpeedMultiplier;
    public float windSpeedMultiplierCoefficient;
    void Update()
    {
        timeElapsed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().timeElapsed;
        windSpeedMultiplier = 1 + (windSpeedMultiplierCoefficient * timeElapsed);

        gameObject.GetComponent<WindZone>().windMain += (windSpeedMultiplier * Time.deltaTime);
    }
}
