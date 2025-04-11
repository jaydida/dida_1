using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Composite
{
    protected LinkedListNode<MyBehaviour> currentChild;//当前运行的子节点
    public MyBehaviour CurrentChild => currentChild?.Value;//只读属性，避免外部修改，?空值运算符，为空的话不在报错，返回null

    protected override void OnInitializa()
    {
        currentChild = children.First;
    }

    protected override EStatus OnUpdate()
    {
        while (true)
        {
            var currentStatus = currentChild.Value.Tick();//执行当前子节点，并获取当前子节点的状态
            if (currentStatus != EStatus.Success)
            {
                return currentStatus;
            }

            currentChild = currentChild.Next;//如果当前子节点的状态是成功，则继续执行下一个子节点
            //全部执行完毕，返回成功
            if (currentChild == null)
            {
                return EStatus.Success;//如果当前子节点为空，则返回成功
            }

        }
       

    }
}