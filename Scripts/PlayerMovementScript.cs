using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementScript : DefPlayerRefs
{

    public Transform target;
    public string LivingLayer = "Living";

    public override void OnStart()
    {
        base.OnStart();
    }
    public void SetTargetPos()
    {
        pc.detectorRef.OnMouseTypeOfTarget();
        nmAgent.destination = target.position;
        activelyReaching = true;
    }

    public bool activelyReaching = false;
    public void CheckTarget()
    {
        bool reached = false;

        if (Vector3.Distance(pc.GetCurrentPos(), target.position - new Vector3(0, target.position.y, 0)) <= pc.nmAgent.stoppingDistance + 0.01f)
        {
            reached = true;
        }

        if (reached)
        {
            OnTargetReach();
        }
    }

    public void OnTargetReach()
    {
        activelyReaching = false;
        Debug.Log("Move Target Reach");

        if (pc.detectorRef.HasNullTarget())
        {
            pc.interactionRef.ResetOnNullContact();
            return;
        }

        GameObject target = pc.detectorRef.targettedTransform.gameObject;
        string layer = LayerMask.LayerToName(target.layer);
        if (layer == LivingLayer)
        {
            pc.interactionRef.OnLivingContact(target);
        }
    }

    public void MoveInput()
    {
        SetTargetPos();
    }
}
