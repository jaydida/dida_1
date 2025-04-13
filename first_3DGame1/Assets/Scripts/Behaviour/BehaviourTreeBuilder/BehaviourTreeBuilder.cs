using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeBuilder 
{
    private readonly Stack<MyBehaviour> nodeStack;//构建树结构用到的栈，只读
    private readonly BehaviourTree behaviourTree;//构建树

    public BehaviourTreeBuilder()
    {
        nodeStack = new Stack<MyBehaviour>();//初始化构建栈
        behaviourTree = new BehaviourTree(null);//构造一个没有根节点的树。
    }

    private void AddBehaviour(MyBehaviour behaviour)
    {
        if (behaviourTree.HasRoot)//有根节点时，加入构建栈
        {
            nodeStack.Peek().AddChild(behaviour, -1);//默认尾插（指的是链表的），TODO
        }
        else//没有根节点时，新增节点作为根节点
        {
            behaviourTree.SetRoot(behaviour);
        }

        //只有组合节点和装饰节点需要进栈
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
