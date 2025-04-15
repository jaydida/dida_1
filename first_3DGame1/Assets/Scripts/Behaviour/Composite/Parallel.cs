using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallel : Composite
{
    public enum EParallelType
    {
        All,One,
    }

    protected EParallelType parallelSuccess;
    protected EParallelType parallelFailure;
    private List<EStatus> childStatus;//记录子节点的状态，只有在子节点返回running的时候，下一次这些节点的Tick才会执行。减少不必要的Tick调用

    //构造函数初始化的时候，根据传入的参数设置并行成功和失败的类型
    public Parallel(EParallelType parallelSuccess, EParallelType parallelFailure)
    {
        this.parallelSuccess = parallelSuccess;
        this.parallelFailure = parallelFailure;
    }

    public override void OnInitialize()
    {
        //初始化子节点的状态
        childStatus = new List<EStatus>();
        for (int i = 0; i < children.Count; i++)
        {
            childStatus.Add(EStatus.Runing);
        }
    }

    protected override EStatus OnUpdate()
    {
        int successCount = 0;
        int failureCount = 0;
        int Length = children.Count;
        bool allCompleted = true; // 是否所有子节点都已完成
        if (Length == 0)
        {
            return EStatus.Failure;
        }
        var currentchlid = children.First;
        for (int i = 0; i < Length; i++)
        {
            //还未测试，这里可能存在逻辑问题。

            if (childStatus[i] == EStatus.Runing)
            {
                for (int j = 0; j < i; j++)
                {
                    currentchlid = currentchlid.Next;
                }
                childStatus[i] = currentchlid.Value.Tick();
                currentchlid = children.First;
            }

            if (childStatus[i] == EStatus.Success)
            {
                successCount++;
                //如果只需要一个成功就算成功
                if (parallelSuccess == EParallelType.One)
                {
                    return EStatus.Success;
                }
            }
            else if (childStatus[i] == EStatus.Failure)
            {
                failureCount++;
                //同理，如果只需要一个失败就算失败
                if (parallelFailure == EParallelType.One)
                {
                    return EStatus.Failure;
                }
            }
            else
            {
                allCompleted = false;
            }

        }
        //如果是All类型的并行，则需要判断所有子节点的状态
        if (parallelSuccess == EParallelType.All && successCount == Length)
        {
            return EStatus.Success;
        }

        if (parallelFailure == EParallelType.All && failureCount == Length)
        {
            return EStatus.Failure;
        }
        //所有子节点都完成了，但是没有成功或者失败，就返回失败。没完成就是Runing。
        return allCompleted ? EStatus.Failure : EStatus.Runing;

    }


    protected override void OnExit()
    {
        foreach (var child in children)
        {
            if (child.IsRuning)
            {
                child.Abort();
            }
           
        }
    }
}
