using System.Collections.Generic;
using UnityEngine;

public abstract class Composite : MyBehaviour
{
//结合节点的基类
    protected LinkedList<MyBehaviour> children;
    protected int currentIndex = 0;
    public int CurrentIndex => currentIndex;

    public  Composite()
    {
       children = new LinkedList<MyBehaviour>() ;
    }

    public override void AddChild(MyBehaviour child, int index)
    {
        if (child == null)
        {
            Debug.LogError("子节点不能为空");
            return;
        }
        if (children.Contains(child))
        {
            Debug.LogError("子节点已经存在");
            return;
        }
        if (index < 0 || index >= children.Count)
        {
            ////默认是尾插入
            children.AddLast(child);
        }
        else
        {
            //TODO
            //children.Insert
        }
    }

    public virtual void Remove(MyBehaviour child)
    {
        if (child == null)
        {
            Debug.LogError("子节点不能为空");
            return;
        }
        if (!children.Contains(child))
        {
            Debug.LogError("子节点不存在");
            return;
        }
        if (child.IsRuning)
        {
            //如果子节点正在运行，先中断它
            child.Abort();
        }
        children.Remove(child);
    }

    public virtual void Clear()
    {
        children.Clear();
    }

    protected void ResetIndex()
    {
        currentIndex = 0;
    }
}
