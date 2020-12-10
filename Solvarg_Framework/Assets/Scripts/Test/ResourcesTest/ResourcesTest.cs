using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SingletonManager))]
public class ResourcesTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float time = System.Environment.TickCount;
        for(int i = 1; i < 2000; ++i)
        {
            GameObject go = null;
            //go = Instantiate(Resources.Load<GameObject>("Prefabs/Cube"));
            //go.transform.position = UnityEngine.Random.insideUnitSphere * 10;
            /*ResManager.Instance.LoadAsyncInstance("Prefabs/Cube",(_obj)=> {
                go = _obj as GameObject;
                go.transform.position = UnityEngine.Random.insideUnitSphere * 20;
            });*/
            ResManager.Instance.LoadCorotineInstance("Prefabs/Cube", (_obj) => {
                go = _obj as GameObject;
                go.transform.position = UnityEngine.Random.insideUnitSphere * 20;
            });
        }
        Debuger.Log("Times: " + (System.Environment.TickCount - time) * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
