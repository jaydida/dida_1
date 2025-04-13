using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// ����������ܶ඼û���ǣ��������ڵ��һ��
/// �����ټ���������
/// </summary>
public class Monitor : Parallel
{
    public Monitor(EParallelType parallelSuccess, EParallelType parallelFailure) : base(parallelSuccess, parallelFailure)
    {
    }


    public void SetCondition(MyBehaviour condition)
    {
        if (condition == null)
        {
            Debug.LogError("��������Ϊ��");
            return;
        }
        //conditionCount++;
        children.AddFirst(condition);
    }

    //��Ӷ�������β�塣
    public void SetAction(MyBehaviour Action)
    {
        if (Action == null)
        {
            Debug.LogError("��Ϊ����Ϊ��");
            return;
        }
        //actionCount++;
        children.AddLast(Action);
    }
}
