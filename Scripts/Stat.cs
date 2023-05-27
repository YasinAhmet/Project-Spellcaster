using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public string statName;
    public float statEffect;
    public float lastEffect;
    public List<StatMod> modifiers;


    public float GetEffect()
    {
        CalculateMods(false);
        return lastEffect;
    }
    public Stat(string name, float effect)
    {
        statName = name;
        statEffect = effect;
        lastEffect = statEffect;
        modifiers = new List<StatMod>();
    }

    public void CalculateAll()
    {
        CalculateMods(true);
    }

    public bool PushNewMod(string name, float effect, int duration)
    {
        modifiers.Add(new StatMod(name, effect, duration));
        return true;
    }

    public void CalculateMods(bool expireInclude)
    {
        if (expireInclude) ClearExpiredModifiers();
        float totalEffectMods = 1;

        foreach (var item in modifiers)
        {
            totalEffectMods += item.bonusEffect;
        }

        lastEffect = statEffect * totalEffectMods;
    }

    public void ClearExpiredModifiers()
    {
        foreach (var item in modifiers.ToArray())
        {
            bool durationOver = item.DurationTick();
            if (durationOver)
            {
                modifiers.Remove(item);
                continue;
            }
        }
    }
}
