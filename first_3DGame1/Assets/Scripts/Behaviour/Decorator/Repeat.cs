using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : Decorator
{
    private int repeatCount = 0;//重复次数计数
    public int repeatLimt = 0;//重复次数限制

    public Repeat(int repeatLimt)
    {
        this.repeatLimt = repeatLimt;
    }

    public override void OnInitialize()
    {
        status = EStatus.Invalid;
        repeatCount = 0;//初始化时重置重复次数计数
        child.OnInitialize();
    }

    protected override EStatus OnUpdate()
    {

        var childStatus = child.Tick();
        if (childStatus == EStatus.Runing)
        {
            return EStatus.Runing;
        }

        if (childStatus == EStatus.Failure)
        {
            return EStatus.Failure;
        }
        repeatCount++;
        //Debug.Log(repeatCount);
        if (repeatCount >= repeatLimt)
        {
            //只有一直成功的次数达到限制次数，才返回成功
            return EStatus.Success;
        }
        child.OnInitialize(); // 重置子节点状态以便下次执行
        return EStatus.Runing;
        
    }
}
