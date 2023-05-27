using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMod
{
    public string statName;
    public float bonusEffect;
    public int durationInSecond = 5;

    public StatMod(string name, float effect, int duration)
    {
        statName = name;
        bonusEffect = effect;
        durationInSecond = duration;
    }

    public bool DurationTick()
    {
        durationInSecond--;
        if (durationInSecond < 1)
        {
            return true;
        }
        else return false;
    }
}
