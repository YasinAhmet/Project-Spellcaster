using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAssignment
{
    public string skillName = "null";
    public char onKeyDown = 'n';

    public SkillAssignment(char key, string name)
    {
        skillName = name;
        onKeyDown = key;
    }
}