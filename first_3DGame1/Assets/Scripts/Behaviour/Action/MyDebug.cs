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

    protected override EStatus OnUpdate()
    {
        Debug.Log(word);
        return EStatus.Success;
    }
}
