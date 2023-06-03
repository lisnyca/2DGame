using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class WorldLight : MonoBehaviour
{
    private Light2D light;
    [SerializeField]
    private WorldTime worldTime;
    [SerializeField]
    private Gradient gradient;
    private void Awake()
    {
        light = GetComponent<Light2D>();
        worldTime.WorldTimeChanged += WorldTime_WorldTimeChanged;
    }
    private void nDestroy()
    {
        worldTime.WorldTimeChanged -= WorldTime_WorldTimeChanged;
    }
    private void WorldTime_WorldTimeChanged(object sender, System.TimeSpan e)
    {
        light.color = gradient.Evaluate(PercentOfDay(e));
    }
    private float PercentOfDay(TimeSpan time)
    {
        return (float)time.TotalMinutes % WorldTimeConstans.MinutesInDay / WorldTimeConstans.MinutesInDay;
    }
}
