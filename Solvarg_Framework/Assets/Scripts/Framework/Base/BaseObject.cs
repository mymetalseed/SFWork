using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Defines;

public class BaseObject
{
    private EnumObjectState state = EnumObjectState.Initial;
    public EnumObjectState CurState => (state);
    
    public BaseObject()
    {
        state = EnumObjectState.Initial;
    }

}
