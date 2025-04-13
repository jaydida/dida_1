using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : Decorator
{
    private int repeatCount = 0;//重复次数计数
    public int repeatLimt = 0;//重复次数限制

    protected override void OnInitializa()
    {
        repeatCount = 0;//初始化时重置重复次数计数
    }

    protected override EStatus OnUpdate()
    {
        
        while (repeatCount <= repeatLimt)
        {
            child.Tick();
            if (IsRuning)
            {
                return EStatus.Runing;
            }

            if (IsFailure)
            {
                return EStatus.Failure;
            }
            repeatCount++;
        }
        //只有一直成功的次数达到限制次数，才返回成功
        return EStatus.Success;
    }
}
