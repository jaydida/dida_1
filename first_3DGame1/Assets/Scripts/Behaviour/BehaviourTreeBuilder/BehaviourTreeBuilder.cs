using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BehaviourTreeBuilder 
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
            //ͨ������AddChild�������������behaviour��ýڵ��ڲ�������ӽڵ���ϵ������
            nodeStack.Peek().AddChild(behaviour, -1);//Ĭ��β�壨ָ��������ģ���TODO
        }
        else//û�и��ڵ�ʱ�������ڵ���Ϊ���ڵ�
        {
            behaviourTree.SetRoot(behaviour);
        }

        //ֻ����Ͻڵ��װ�νڵ���Ҫ��ջ�͵�һ����ڸ��ڵ�
        //������Ϊ�ڵ���˵����Ȼû���뵽ջ�������Ҳִ���ˣ�AddChild������Ҳ�ͽ��ӽڵ��뱾���ŵ��ӽڵ�ı������������ˣ�����ֵ����
        if (behaviour is Composite || behaviour is Decorator || behaviour is EntryNode)
        {
            nodeStack.Push(behaviour);//���½ڵ��Ϊ��ǰ�ڵ㣬Ҳ������һ���ڵ�ĸ��ڵ�
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


    /**************************************************************************/
    //�Խڵ���з�װ��ͨ����������ʽ���ý��е��á�
    //�÷�װ���ϼ���ִ�У�ʹ���˷�������ʽ����
    //Ҳͨ��ʵ���������ϱ�������������ࣨBehaviourTreeBuilder����AddBehaviour��ʵ����
    //���������Ϊǰһ����������ࡣ


    public BehaviourTreeBuilder Sequence()
    {
        var temp = new Sequence();//�����ʵ��������
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder Selector()
    {
        var temp = new Selector();//�����ʵ��������
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder Parallel(Parallel.EParallelType succes, Parallel.EParallelType failure)
    {
        var temp = new Parallel(succes, failure);//�����ʵ��������
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder Monitor(Parallel.EParallelType succes, Parallel.EParallelType failure)
    {
        var temp = new Monitor(succes, failure);//�����ʵ��������
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder ActiveSelector()
    {
        var temp = new ActiveSelector();//�����ʵ��������
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder Repeat(int repeatLimt)
    {
        var temp = new Repeat(repeatLimt);//�����ʵ��������
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder Inverter()
    {
        var temp = new Inverter();//�����ʵ��������
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder EntryNode()
    {
        var temp = new EntryNode();//�����ʵ��������
        AddBehaviour(temp);
        return this;
    }
}
