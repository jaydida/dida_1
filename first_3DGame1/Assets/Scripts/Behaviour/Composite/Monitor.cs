using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 这个监视器很多都没考虑，先做出节点第一步
/// 后面再继续迭代。
/// </summary>
public class Monitor : Parallel
{
    public Monitor(EParallelType parallelSuccess, EParallelType parallelFailure) : base(parallelSuccess, parallelFailure)
    {
    }


    public void SetCondition(MyBehaviour condition)
    {
        if (condition == null)
        {
            Debug.LogError("条件不能为空");
            return;
        }
        //conditionCount++;
        children.AddFirst(condition);
    }

    //添加动作就用尾插。
    public void SetAction(MyBehaviour Action)
    {
        if (Action == null)
        {
            Debug.LogError("行为不能为空");
            return;
        }
        //actionCount++;
        children.AddLast(Action);
    }
}
