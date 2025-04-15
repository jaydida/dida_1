using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDebug : Action
{
    private string word;

    public MyDebug(string word)
    {
        this.word = word;
    }

    public override void OnInitialize()
    {
        status = EStatus.Invalid;
    }

    protected override EStatus OnUpdate()
    {
        Debug.Log(word);
        return EStatus.Success;
    }
}


//Ϊʲô�����Ҫд������,����������Ϥ partial�ؼ��ֵ��÷���
public partial class BehaviourTreeBuilder
{
    public BehaviourTreeBuilder MyDebug(string word)
    {
        var temp = new MyDebug(word);
        AddBehaviour(temp);
        return this;
    }
}
