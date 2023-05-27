using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Lightning : Effect
{
    public float damage = 5;
    public override void InvokeEffect()
    {
        foreach (var item in colliders)
        {
            Debug.Log(damage + " damage dealt to " + item.gameObject.name);
        }

        base.InvokeEffect();
    }
}
