using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpellDamageScript : MonoBehaviour
{
    public int damage = 5;
    public LayerMask layerMask = new LayerMask();
    List<GameObject> gameObjectsDamaged = new List<GameObject>();
    public Skill skill;
    public bool damageToCaster = false;

    public bool DamagedPreviously(GameObject gm)
    {
        foreach (var item in gameObjectsDamaged)
        {
            if (gm == item)
            {
                return true;
            }
        }

        return false;
    }

    public bool CanDamage(LivingScript target)
    {
        if (skill.IsTargetSameWithCaster(target.gameObject))
        {
            return false;
        }

        return true;
    }
    public void TryDamageLiving(LivingScript livingTarget)
    {
        if (CanDamage(livingTarget))

            Debug.Log(damage + " damage dealt to " + livingTarget.name);
        gameObjectsDamaged.Add(livingTarget.gameObject);
    }
}
