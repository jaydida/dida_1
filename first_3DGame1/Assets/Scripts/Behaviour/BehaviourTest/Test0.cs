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
                         .MyDebug("��һ��MyDebug")
                         .MyDebug("�ڶ���MyDebug")
                         .MyDebug("������MyDebug")
                     .Back()
                 .End();

        //builder
        //            .Repeat(3)
        //              .Sequence()
        //                 .MyDebug("��һ��MyDebug")
        //                 .MyDebug("�ڶ���MyDebug")
        //                 .MyDebug("������MyDebug")
        //             .Back()
        //         .End();

    }

    private void Update()
    {
        builder.TreeTick();//�����������ʵ��ÿִֻ֡��һ�Ρ�
    }
}
