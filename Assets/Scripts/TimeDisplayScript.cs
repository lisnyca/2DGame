using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TimeDisplayScript : MonoBehaviour
{
    [SerializeField]
    private WorldTime wordTime;
    private TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        wordTime.WorldTimeChanged += WordTime_WorldTimeChanged;
    }
    private void OnDestroy()
    {
        wordTime.WorldTimeChanged -= WordTime_WorldTimeChanged;
    }
    private void WordTime_WorldTimeChanged(object sender, System.TimeSpan e)
    {
        text.SetText(e.ToString(@"hh\:mm"));
    }
}
