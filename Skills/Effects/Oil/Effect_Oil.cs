using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Oil : Effect
{
    public float damage = 5;
    public bool burning = false;
    public GameObject burningEffect;
    public override void InvokeEffect()
    {
        if (burning)
        {
            foreach (var item in colliders)
            {
                Debug.Log(damage + " damage dealt to " + item.gameObject.name);
            }
        }
        base.InvokeEffect();
    }

    public override void OnEvent(string eventName, object[] input)
    {
        if (eventName == "fire")
        {
            if ((bool)input[0])
            {
                OilBurningProcedures();
            }
        }
    }

    public void OilBurningProcedures()
    {
        burning = true;
        burningEffect.SetActive(true);
    }
}
