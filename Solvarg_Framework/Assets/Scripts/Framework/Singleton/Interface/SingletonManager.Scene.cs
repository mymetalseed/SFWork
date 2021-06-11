using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Defines;

public partial class SingletonManager
{
    public async Task EnterScene(EnumSceneName scName)
    {
        await sceneManager.EnterScene(scName);
    }

    public void LeaveScene()
    {

    }

}
