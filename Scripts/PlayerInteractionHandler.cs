using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : DefPlayerRefs
{

    public GameObject focusObj;
    public void OnFriendlyContact()
    {

    }
    public void OnEnemyContact()
    {
        pc.attackRef.SubmitAttack(focusObj);
    }
    public void OnNeutralContact()
    {

    }

    public void OnLivingContact(GameObject gm)
    {
        focusObj = gm;
        int targetTeam = CheckFriendOrEnemy();

        if (targetTeam == 99)
        {
            OnNeutralContact();
        }
        else if (targetTeam == 1)
        {
            OnEnemyContact();
        }
        else if (targetTeam == 2)
        {
            OnFriendlyContact();
        }
    }

    public void ResetOnNullContact()
    {
        focusObj = null;
    }

    public int CheckFriendOrEnemy()
    {
        int objTeam = focusObj.GetComponent<LivingScript>().Team;

        if (objTeam == 99)
        {
            return 0;
        }
        else if (objTeam != pc.livingRef.Team)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
}
