using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 主动选择器，在之前选这群的基础上机上优先级判断，也就是如果发生了在执行低优先级
/// 但高优先级的恢复能执行的状态了，不是失败，就中断当前状态执行，高优先级状态。
/// 需要一个检测高优先级的状态，来判断当前状态是否可以中断当前状态。
/// 在使用该主动选择器时，将高优先级的状态放在前面，低优先级的状态放在后面。
/// </summary>
public class ActiveSelector : Selector
{
    //protected LinkedListNode<MyBehaviour> currentChildActive;//当前运行的子节点,在主动选择器中，当前运行的子节点是指当前正在执行的子节点，避免混乱
    //每次执行都从头开始不就行了
    protected override EStatus OnUpdate()
    {
        var currentChildActive = currentChild;//执行当前子节点，并获取当前子节点的状态
        currentChild = children.First;//重置当前子节点为第一个子节点

        //这里执行的时候，会将currentChild改变。这里已经将子节点执行了。要么是因为高优先级的可以执行了，要么是因为当前子节点不能执行了
        var currentStatusActive = base.OnUpdate();
        if (currentChild != null && currentChildActive != currentChild)
        {
            //如果当前子节点不为空，说明还有子节点没执行。那只要两个节点不一样（这里指第几个子节点），就打断当前节点。
            currentChildActive.Value.Abort();//如果当前子节点不是当前正在执行的子节点，则退出当前正在执行的子节点
        }
        return currentStatusActive;//返回当前子节点的状态
    }

}
