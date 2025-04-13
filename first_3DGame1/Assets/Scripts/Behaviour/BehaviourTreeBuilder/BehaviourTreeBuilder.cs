using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeBuilder 
{
    private readonly Stack<MyBehaviour> nodeStack;//�������ṹ�õ���ջ��ֻ��
    private readonly BehaviourTree behaviourTree;//������

    public BehaviourTreeBuilder()
    {
        nodeStack = new Stack<MyBehaviour>();//��ʼ������ջ
        behaviourTree = new BehaviourTree(null);//����һ��û�и��ڵ������
    }

    private void AddBehaviour(MyBehaviour behaviour)
    {
        if (behaviourTree.HasRoot)//�и��ڵ�ʱ�����빹��ջ
        {
            nodeStack.Peek().AddChild(behaviour, -1);//Ĭ��β�壨ָ��������ģ���TODO
        }
        else//û�и��ڵ�ʱ�������ڵ���Ϊ���ڵ�
        {
            behaviourTree.SetRoot(behaviour);
        }

        //ֻ����Ͻڵ��װ�νڵ���Ҫ��ջ
        if (behaviour is Composite || behaviour is Decorator)
        {
            nodeStack.Push(behaviour);
        }
    }

    public void TreeTick()
    {
        behaviourTree.Tick();
    }

    public BehaviourTreeBuilder Back()
    {
        nodeStack.Pop();
        return this;
    }

    public BehaviourTree End()
    {
        nodeStack.Clear();
        return behaviourTree;
    }
}
