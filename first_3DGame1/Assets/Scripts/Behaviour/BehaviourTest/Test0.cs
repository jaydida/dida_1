using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test0 : MonoBehaviour
{
    private BehaviourTreeBuilder builder;

    private void Awake()
    {
        builder = new BehaviourTreeBuilder();
    }

    private void Start()
    {
        builder.EntryNode()
                    .Repeat(3)
                      //.Sequence()
                      .Selector()
                         .MyDebug("第一次MyDebug")
                         .MyDebug("第二次MyDebug")
                         .MyDebug("第三次MyDebug")
                     .Back()
                 .End();

        //builder
        //            .Repeat(3)
        //              .Sequence()
        //                 .MyDebug("第一次MyDebug")
        //                 .MyDebug("第二次MyDebug")
        //                 .MyDebug("第三次MyDebug")
        //             .Back()
        //         .End();

    }

    private void Update()
    {
        builder.TreeTick();//放在这里就能实现每帧只执行一次。
    }
}
