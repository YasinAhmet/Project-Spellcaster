using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputManager : DefPlayerRefs
{

    public List<SkillAssignment> skillsOfChar = new List<SkillAssignment>();

    public override void OnStart()
    {
        base.OnStart();
        GetBasicSpells();
    }

    public void GetBasicSpells()
    {
        skillsOfChar.Add(new SkillAssignment('Q', "fireball"));
        skillsOfChar.Add(new SkillAssignment('W', "lightning"));
        skillsOfChar.Add(new SkillAssignment('E', "grease"));
    }
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            for (int i = 0; i < skillsOfChar.Count; i++)
            {
                if (e.keyCode.ToString() == skillsOfChar[i].onKeyDown.ToString())
                {
                    pc.casterRef.CastGiven(skillsOfChar[i].skillName);
                }
            }
        }

    }

    public void QAction()
    {
        pc.casterRef.CastGiven("fireball");
    }

    public void WAction()
    {
        pc.casterRef.CastGiven("lightning");
    }

    public void EAction()
    {
        pc.casterRef.CastGiven("grease");
    }
}
