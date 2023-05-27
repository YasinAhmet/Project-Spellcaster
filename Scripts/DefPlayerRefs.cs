using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class DefPlayerRefs : MonoBehaviour
{
    public PlayerCenter pc;
    public NavMeshAgent nmAgent;
    public void Start()
    {
        OnStart();
    }

    public virtual void OnStart()
    {
        pc = transform.parent.GetComponent<PlayerCenter>();
        nmAgent = transform.parent.GetComponent<NavMeshAgent>();
    }
}
