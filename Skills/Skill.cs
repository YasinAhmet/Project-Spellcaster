using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float CastingTime = 1;
    public float CastingRange = 2;
    public int duration = 10;
    public string SkillName = "NullTypeSkill";
    public GameObject skill;
    public List<GameObject> effects = new List<GameObject>();
    public Transform target;
    public Vector3 targetPos;
    public Vector3 targetPosOrg;
    public LivingScript caster;
    public float orgY;
    public bool fixedMove = false;
    public float travelSpeed;
    public bool castableWhileMoving = true;

    public bool IsTargetSameWithCaster(GameObject targetObj)
    {
        bool isSame = false;
        if (targetObj.TryGetComponent(out LivingScript livingScript))
        {
            isSame = livingScript == caster;
        }

        return isSame;
    }

    private void Start()
    {
        transform.LookAt(target);
        transform.eulerAngles -= new Vector3(transform.eulerAngles.x, 0, 0);

        targetPos = target.transform.position;
        targetPosOrg = targetPos;
        orgY = targetPosOrg.y;

        durationCounter = new Timer();
        durationCounter.perTick = duration;
    }

    Timer durationCounter;

    private void Update()
    {
        if (fixedMove)
        {
            FixedProtocol();
        }
        else
        {
            CheckOnSamePosWTarget();
        }


        transform.position = Vector3.Lerp(transform.position, targetPos, travelSpeed);
    }

    public void FixedProtocol()
    {
        targetPos = transform.position + (transform.forward * 5);
        bool result = durationCounter.Tick();

        if (result)
        {
            Trigger();
        }
    }

    public void CheckOnSamePosWTarget()
    {
        if (Vector3.Distance(transform.position, targetPos) <= 0.15)
        {
            Trigger();
        }
    }

    public void Trigger()
    {
        transform.position = targetPos + new Vector3(0, orgY - targetPos.y, 0);
        foreach (var item in effects)
        {
            GameObject gm = Instantiate(item);
            gm.transform.position = transform.position;
        }

        Destroy(gameObject);
    }
}
