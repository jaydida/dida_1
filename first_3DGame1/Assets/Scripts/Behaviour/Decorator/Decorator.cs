using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : MyBehaviour
{
    protected MyBehaviour child;

    //���������������ӽڵ㣬������ӵ�ʱ���ӽڵ���������������ӽڵ��ˡ�
    //֮ǰ������ӵ�ʱ��Ҳ����ˡ�
    public override void AddChild(MyBehaviour child, int index)
    {
        this.child = child;
    }
}
