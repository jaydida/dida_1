using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Filter，通常只有一个条件和一个动作，相当于一个装饰节点
public class Filter : Composite
{
    protected LinkedListNode<MyBehaviour> currentChild;//当前运行的子节点
    public MyBehaviour CurrentChild => currentChild?.Value;//只读属性，避免外部修改，?空值运算符，为空的话不在报错，返回null
    private int conditionCount = 0;//条件计数器，判断当前节点是否是条件节点
    private int actionCount = 0;//动作计数器，判断当前节点是否是动作节点
    //private int currentIndex = 0;//当前索引，记录当前节点在children中的索引位置,继承的有该值。

    //过滤器，也就是根据条件来决定是否执行子节点
    //相当于先执行条件，如果条件成立，则执行子节点
    public void SetCondition(MyBehaviour condition)
    {
        if (condition == null)
        {
            Debug.LogError("条件不能为空");
            return;
        }
        conditionCount++;
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
        actionCount++;
        children.AddLast(Action);
    }

    public override void OnInitialize()
    {
        status = EStatus.Invalid;
        currentChild = children.First;
        for (int i = 0; i < children.Count; i++)
        {
            currentChild.Value.OnInitialize();
            currentChild = currentChild.Next;
        }
        currentChild = children.First;
    }

    protected override EStatus OnUpdate()
    {
        if(conditionCount == 0 || actionCount == 0)
        {
            Debug.LogWarning("Filter节点至少需要一个条件和一个动作");
            return EStatus.Failure;
        }

        for (int i = currentIndex; i < conditionCount; i++)
        {
            if (currentChild.Value.Tick() == EStatus.Failure)
            {
                currentIndex = 0;//条件失败，重置索引
                currentChild = children.First;
                return EStatus.Failure;
            }
            else if (currentChild.Value.Tick() == EStatus.Runing)
            {
                currentIndex = i;//记录当前索引，通过的就别在执行了
                return EStatus.Runing;
            }
            else
            {
                currentChild = currentChild.Next;
            }
        }

        for (int i = 0; i < actionCount; i++)
        {
            if(currentChild.Value.Tick() == EStatus.Failure)
            {
                currentIndex = 0;//条件失败，重置索引
                currentChild = children.First;
                return EStatus.Failure;
            }
            else if (currentChild.Value.Tick() == EStatus.Runing)
            {
                currentIndex = i;//记录当前索引，通过的就别在执行了
                return EStatus.Runing;
            }
            else
            {
                currentChild = currentChild.Next;
            }
        }

        return EStatus.Success;

    }
}
