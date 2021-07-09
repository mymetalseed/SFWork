using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFAction_DataStore : MonoBehaviour
{
    [HideInInspector]
    public GameObject owner;

    [HideInInspector]
    public GameObject target;


    [HideInInspector]
    public SFAction_SkillInfo skillInfo;
    [HideInInspector]
    public SFAction_BuffInfo buffInfo;
}
