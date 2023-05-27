using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDetector : MonoBehaviour
{
    Timer fireCheckTimer;
    public Effect effect;

    private void Start()
    {
        fireCheckTimer = new Timer();
    }
    void Update()
    {
        if (fireCheckTimer.Tick())
        {
            CheckAll();
        }
    }

    public void CheckAll()
    {
        Collider[] foundColliders = Physics.OverlapBox(transform.position, transform.lossyScale / 2);
        foreach (var item in foundColliders)
        {
            if (item.TryGetComponent<Effect>(out Effect ef))
            {
                bool hasFire = ef.HasGivenEffectTag("fire");

                if (hasFire) effect.OnEvent("fire", new object[] { true });
            }
        }
    }
}
