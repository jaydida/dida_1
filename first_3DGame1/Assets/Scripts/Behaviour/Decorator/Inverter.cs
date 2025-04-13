using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Decorator
{
    //只对成功与失败者两个节点状态进行取反。
    protected override EStatus OnUpdate()
    {
        var childStatus = child.Tick();
        if (childStatus == EStatus.Success)
        {
            childStatus = EStatus.Failure;
        }

        if (childStatus == EStatus.Failure) 
        {
            childStatus = EStatus.Success;
        }

        return childStatus;
    }
}
