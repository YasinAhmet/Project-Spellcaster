using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCaster : DefPlayerRefs
{
    public Skill casting = null;
    public List<Skill> skills = new List<Skill>();
    public float castingCounter = 0;

    public bool CastGiven(string skillName)
    {
        if (!CanCast()) return false;
        foreach (var item in skills)
        {
            if (item.SkillName == skillName)
            {
                Cast(item);
                return true;
            }
        }

        return false;
    }

    public bool CanCast()
    {
        if (casting != null) return false;
        return true;
    }

    public void Cast(Skill skill)
    {
        pc.attackRef.CancelAttack();
        CancelCasting();

        casting = skill;
        pc.sDetectorRef.OnMouseTypeOfTarget();
        casting.target = pc.sDetectorRef.targettedTransform;
    }

    private void Update()
    {
        if (casting != null)
        {
            if (pc.movementRef.activelyReaching && !casting.castableWhileMoving)
            {
                CancelCasting();
                return;
            }

            if (Vector3.Distance(casting.target.position, transform.position) > casting.CastingRange)
            {
                CancelCasting();
                return;
            }

            castingCounter += 0.015f;

            if (castingCounter >= casting.CastingTime)
            {
                FinishCasting();
            }
        }
    }

    public void CancelCasting()
    {
        if (casting != null) Debug.Log("Cast Canceled");
        ResetCastData();
    }

    public void ResetCastData()
    {
        castingCounter = 0;
        casting = null;
    }

    public Transform targeted = null;
    public void FinishCasting()
    {
        GameObject castedSkill = Instantiate(casting.skill);
        castedSkill.transform.position = pc.transform.position;

        Skill casted = castedSkill.GetComponent<Skill>();
        casted.target = pc.sDetectorRef.transform;
        casted.caster = pc.livingRef;

        casting = null;
        OnCastFinish();
    }

    public List<Action> OnCastingFinished = new List<Action>();

    public void OnCastFinish()
    {
        foreach (var item in OnCastingFinished)
        {
            item.Invoke();
        }

        Debug.Log("Cast Finished");
        ResetCastData();
    }
}
