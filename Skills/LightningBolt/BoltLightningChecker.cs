using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltLightningChecker : BasicSpellDamageScript
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject gm = other.gameObject;
        if (!DamagedPreviously(gm))
        {
            bool isLiving = gm.TryGetComponent<LivingScript>(out LivingScript living);
            if (isLiving)
            {
                TryDamageLiving(living);
            }
        }
    }
}
