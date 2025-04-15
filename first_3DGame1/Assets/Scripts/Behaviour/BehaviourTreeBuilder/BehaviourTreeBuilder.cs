using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BehaviourTreeBuilder 
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
            //通过调用AddChild函数，将传入的behaviour与该节点内部定义的子节点联系起来。
            nodeStack.Peek().AddChild(behaviour, -1);//默认尾插（指的是链表的），TODO
        }
        else//没有根节点时，新增节点作为根节点
        {
            behaviourTree.SetRoot(behaviour);
        }

        //只有组合节点和装饰节点需要进栈和第一个入口根节点
        //对于行为节点来说，虽然没加入到栈了里，但是也执行了，AddChild函数，也就将子节点与本身存放的子节点的变量关联起来了（即赋值）。
        if (behaviour is Composite || behaviour is Decorator || behaviour is EntryNode)
        {
            nodeStack.Push(behaviour);//将新节点成为当前节点，也就是下一个节点的父节点
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
    //对节点进行封装，通过方法的链式调用进行调用。
    //该封装不断简化了执行，使用了方法的链式调用
    //也通过实例化，加上本身调用树管理类（BehaviourTreeBuilder）的AddBehaviour，实现了
    //将自身添加为前一个父类的子类。


    public BehaviourTreeBuilder Sequence()
    {
        var temp = new Sequence();//这个是实例化对象
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder Selector()
    {
        var temp = new Selector();//这个是实例化对象
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder Parallel(Parallel.EParallelType succes, Parallel.EParallelType failure)
    {
        var temp = new Parallel(succes, failure);//这个是实例化对象
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder Monitor(Parallel.EParallelType succes, Parallel.EParallelType failure)
    {
        var temp = new Monitor(succes, failure);//这个是实例化对象
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder ActiveSelector()
    {
        var temp = new ActiveSelector();//这个是实例化对象
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder Repeat(int repeatLimt)
    {
        var temp = new Repeat(repeatLimt);//这个是实例化对象
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder Inverter()
    {
        var temp = new Inverter();//这个是实例化对象
        AddBehaviour(temp);
        return this;
    }

    public BehaviourTreeBuilder EntryNode()
    {
        var temp = new EntryNode();//这个是实例化对象
        AddBehaviour(temp);
        return this;
    }
}
