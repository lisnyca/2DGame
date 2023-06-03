using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTime : MonoBehaviour
{
    public event EventHandler<TimeSpan> WorldTimeChanged;
    [SerializeField]
    private float _dayLenght;
    private TimeSpan _currentTime;
    private float _minuteLenght => _dayLenght / WorldTimeConstans.MinutesInDay;
    private void Start()
    {
        StartCoroutine(AddMinute()); 
    }
    private IEnumerator AddMinute()
    {
        _currentTime += TimeSpan.FromMinutes(1);
        WorldTimeChanged?.Invoke(this, _currentTime);
        yield return _currentTime;
        StartCoroutine(AddMinute());
    }
}