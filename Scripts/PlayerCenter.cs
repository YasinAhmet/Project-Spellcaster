using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCenter : MonoBehaviour
{
    [SerializeField]
    public PlayerMovementScript movementRef;
    [SerializeField]
    public MouseInputManager mouseInputRef;
    [SerializeField]
    public PlayerStats statsRef;
    [SerializeField]
    public TargetDetector detectorRef;
    [SerializeField]
    public TargetDetector sDetectorRef;
    [SerializeField]
    public PlayerAttackHandler attackRef;
    [SerializeField]
    public SkillCaster casterRef;

    [SerializeField]
    public KeyboardInputManager inputManRef;
    [SerializeField]
    public PlayerInteractionHandler interactionRef;
    [SerializeField]
    public LivingScript livingRef;
    [SerializeField]
    public NavMeshAgent nmAgent;
    [SerializeField]
    public Animator animator;

    public int tickSpeed = 60;

    public int gigSpeed = 5;
    int counter = 0;
    int gigCounter = 0;

    public void Update()
    {
        counter++;
        gigCounter++;

        if (counter >= tickSpeed)
        {
            statsRef.Tick();
            counter = 0;
        }

        if (gigCounter >= gigSpeed)
        {
            statsRef.GigTick();
            gigCounter = 0;
        }
    }

    public Vector3 GetCurrentPos()
    {
        return transform.position - new Vector3(0, transform.position.y, 0);
    }

    public void InvokeGiven(List<Action> methods)
    {
        foreach (var item in methods)
        {
            item.Invoke();
        }
    }

    private void Start()
    {
        attackRef.onAttackSuccessfulyEnd.Add(AttackDebug);
    }

    public void AttackDebug()
    {
        Debug.Log("Attack Happened");
    }
}
