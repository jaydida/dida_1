using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Decorator
{
    public override void OnInitialize()
    {
        status = EStatus.Invalid;
        child.OnInitialize();
    }

    //ֻ�Գɹ���ʧ���������ڵ�״̬����ȡ����
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
