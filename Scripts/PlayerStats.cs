using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : DefPlayerRefs
{
    public List<Stat> stats;

    public override void OnStart()
    {
        base.OnStart();

        stats = new List<Stat>();
        stats.Add(new Stat("attackDistance", 2f));
        stats.Add(new Stat("moveSpeed", 5f));
        stats.Add(new Stat("attackSpeed", 0.5f));
    }

    public Stat HasGivenStat(Stat stat)
    {
        foreach (var item in stats)
        {
            if (stat.statName == item.statName)
            {
                return item;
            }
        }

        return null;
    }
    public Stat HasGivenStat(string stat)
    {
        foreach (var item in stats)
        {
            if (stat == item.statName)
            {
                return item;
            }
        }

        return null;
    }
    public void Tick()
    {
        foreach (var item in stats)
        {
            item.CalculateAll();
        }
    }

    public void GigTick()
    {
        foreach (var item in stats)
        {
            if (pc.movementRef.activelyReaching) pc.movementRef.CheckTarget();
            pc.attackRef.AttackUpdate();
        }
    }
}
