using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHandler : DefPlayerRefs
{
    public bool attacking = false;
    public bool wasAttacking = false;
    public bool ready = true;
    public float distanceTolerance = 0.2f;


    public override void OnStart()
    {
        base.OnStart();
        pc.detectorRef.onNewTarget.Add(CancelAttack);
    }
    public void AttackUpdate()
    {
        wasAttacking = attacking;
        attacking = pc.animator.GetBool("attacking");

        if (wasAttacking && attacking == false)
        {
            OnAttackSuccessfulEnd();
        }
    }

    public GameObject attackTarget = null;
    public List<Action> onAttackSuccessfulyEnd = new List<Action>();
    public void OnAttackSuccessfulEnd()
    {
        foreach (var item in onAttackSuccessfulyEnd)
        {
            item.Invoke();
        }

        ready = true;
        if (attackTarget == pc.interactionRef.focusObj)
        {
            SubmitAttack(attackTarget);
        }
    }

    public void UpdateAttackBy(bool by)
    {
        pc.animator.SetBool("attacking", by);
        attacking = false;
        ready = !by;
    }

    public void CancelAttack()
    {
        UpdateAttackBy(false);
    }
    public void SubmitAttack(GameObject target)
    {
        if (!ready)
        {
            return;
        }

        UpdateAttackBy(true);
        attackTarget = target;
        pc.detectorRef.SetDistanceOfMove(pc.statsRef.HasGivenStat(new Stat("attackDistance", 0)).GetEffect());
    }

}
