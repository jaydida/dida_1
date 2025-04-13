using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class BehaviourTree 
{
    public bool HasRoot => root != null;
    private MyBehaviour root;

    public BehaviourTree (MyBehaviour root)
    {
        this.root = root;
    }

    public void Tick()
    {
        root.Tick();
    }

    public void SetRoot(MyBehaviour root)
    {
        this.root = root;
    }
}
