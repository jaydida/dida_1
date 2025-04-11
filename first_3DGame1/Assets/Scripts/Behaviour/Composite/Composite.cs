using System.Collections.Generic;
using UnityEngine;

public abstract class Composite : MyBehaviour
{
//��Ͻڵ�Ļ���
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
            Debug.LogError("�ӽڵ㲻��Ϊ��");
            return;
        }
        if (children.Contains(child))
        {
            Debug.LogError("�ӽڵ��Ѿ�����");
            return;
        }
        if (index < 0 || index >= children.Count)
        {
            ////Ĭ����β����
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
            Debug.LogError("�ӽڵ㲻��Ϊ��");
            return;
        }
        if (!children.Contains(child))
        {
            Debug.LogError("�ӽڵ㲻����");
            return;
        }
        if (child.IsRuning)
        {
            //����ӽڵ��������У����ж���
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
