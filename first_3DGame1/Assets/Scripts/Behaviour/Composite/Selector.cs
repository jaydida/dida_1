using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    protected LinkedListNode<MyBehaviour> currentChild;//当前运行的子节点
    public MyBehaviour CurrentChild => currentChild?.Value;//只读属性，避免外部修改，?空值运算符，为空的话不在报错，返回null

    protected override void OnInitializa()
    {
        currentChild = children.First;
    }


    /*
     * 每次只会选择一个可以运行的子节点来运行。但从代码上来说，选择器的结构和顺序器完全一致，只是运行逻辑变化了： 
     * 按从左到右的顺序执行其子节点。当其中一个子节点执行成功时，就停止执行，也就是说，任一子节点成功运行，就算运行成功。
     * 只有所有子节点运行都失败，选择器才算运行失败。
     */
    protected override EStatus OnUpdate()
    {
        while(true)
        {
            //放到前面就能解决没有子节点的问题
            if (currentChild == null)
            {
                return EStatus.Failure;//如果当前子节点为空，则返回失败
            }

            var currentStatus = currentChild.Value.Tick();//执行当前子节点，并获取当前子节点的状态

            if (currentStatus != EStatus.Failure)
            {
                return currentStatus;
            }
            currentChild = currentChild.Next;//如果当前子节点的状态是失败，则继续执行下一个子节点
            //全部执行完毕，返回失败
            
        }
    }
}
