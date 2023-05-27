using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    public LayerMask TargetLayers = new LayerMask();
    public PlayerCenter pc;
    public Transform flare;
    public Collider[] DetectAll()
    {
        Collider[] foundColliders = Physics.OverlapBox(flare.transform.position, flare.transform.lossyScale / 2);
        return foundColliders;
    }

    public Transform targettedTransform = null;
    public Transform lastTarget = null;
    public Vector3 returnT = Vector3.zero;
    public Vector3 GetNearestObjAsTarget()
    {

        Debug.Log("Nearest Obj Check " + transform.parent.name);
        lastTarget = targettedTransform;
        targettedTransform = null;
        foreach (var item in DetectAll())
        {
            if (NotInTargets(item.gameObject))
            {
                continue;
            }

            if (targettedTransform == null)
            {
                targettedTransform = item.transform;
                continue;
            }

            if (Vector3.Distance(item.transform.position, transform.position) < Vector3.Distance(targettedTransform.position, transform.position))
            {
                targettedTransform = item.transform;
            }
        }

        OnNewTargetDesignated();

        returnT = Vector3.zero;
        if (targettedTransform != null)
        {
            returnT = targettedTransform.position;
            transform.parent.position = targettedTransform.position + new Vector3(0, transform.position.y - targettedTransform.position.y, 0);
        }
        else
        {
            GetStandardTarget();
        }

        return returnT;
    }

    public void GetStandardTarget()
    {
        returnT = transform.position;
        targettedTransform = transform;
        SetDistanceOfMove(0);
    }

    public void OnMouseTypeOfTarget()
    {
        transform.parent.position = pc.mouseInputRef.GetPosOfMouseInWorld();
        GetNearestObjAsTarget();
    }

    public bool HasNullTarget()
    {
        return targettedTransform == transform;
    }

    public void MoveTargetToMouse()
    {

    }

    public List<Action> onNewTarget = new List<Action>();
    public void OnNewTargetDesignated()
    {
        pc.InvokeGiven(onNewTarget);
    }

    public bool NotInTargets(GameObject target)
    {
        return TargetLayers != (TargetLayers | (1 << target.layer));
    }

    public void SetDistanceOfMove(float range)
    {
        pc.nmAgent.stoppingDistance = range;
    }
}
