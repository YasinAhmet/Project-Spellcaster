using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float EffectTime = 1;
    public float counter = 0;
    public int effectAmount = 1;
    public int effectCounter = 0;
    public List<string> effectTags = new List<string>();
    public bool passiveEffect = false;

    private void Update()
    {
        if (passiveEffect) return;

        counter += 0.015f;

        if (counter >= EffectTime)
        {
            PreInvokeEffect();
            InvokeEffect();
        }
    }

    public bool HasGivenEffectTag(string tag)
    {
        foreach (var item in effectTags)
        {
            if (item == tag)
            {
                return true;
            }
        }

        return false;
    }


    public LayerMask layerMask = new LayerMask();
    public List<Collider> colliders = new List<Collider>();
    public Transform objectEffectCheckRef;
    public virtual void PreInvokeEffect()
    {
        Collider[] foundColliders = Physics.OverlapBox(objectEffectCheckRef.position, objectEffectCheckRef.lossyScale / 2);
        colliders = new List<Collider>();
        foreach (var item in foundColliders)
        {
            if (layerMask == (layerMask | (1 << item.gameObject.layer)))
            {
                colliders.Add(item);
            }
        }
    }
    public virtual void InvokeEffect()
    {
        effectCounter++;
        counter = 0;

        if (effectAmount <= effectCounter)
        {
            Destroy(gameObject);
        }
    }
    public virtual void OnEvent(string eventName, object[] input)
    {

    }
}
