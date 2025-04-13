using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : MyBehaviour
{
    protected MyBehaviour child;

    //这个函数就是添加子节点，而在添加的时候将子节点存下来，不就有子节点了。
    //之前链表添加的时候也是如此。
    public override void AddChild(MyBehaviour child, int index)
    {
        this.child = child;
    }
}
