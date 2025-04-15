using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryNode : MyBehaviour
{
    private MyBehaviour entryChild;//�û���ӵĵ�һ���ڵ�

    public override void AddChild(MyBehaviour child, int index)
    {
        entryChild = child;
    }

    public override void OnInitialize()
    {
        if (entryChild == null)
        {
            Debug.LogError("û�п�ִ�е��ӽڵ�");
        }
    }

    protected override EStatus OnUpdate()
    {
        var rootNodeStatus = entryChild.Tick();
        //Debug.Log(rootNodeStatus);
        while (rootNodeStatus == EStatus.Runing)
        {
            //Debug.Log(rootNodeStatus);
            rootNodeStatus = entryChild.Tick();
            
        }

        if (rootNodeStatus == EStatus.Success)
        {
            //Debug.Log(rootNodeStatus);
            return EStatus.Success;
        }
        //Debug.Log(rootNodeStatus);
        return EStatus.Failure;

        
    }

}
