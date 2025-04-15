using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : Decorator
{
    private int repeatCount = 0;//�ظ���������
    public int repeatLimt = 0;//�ظ���������

    public Repeat(int repeatLimt)
    {
        this.repeatLimt = repeatLimt;
    }

    public override void OnInitialize()
    {
        status = EStatus.Invalid;
        repeatCount = 0;//��ʼ��ʱ�����ظ���������
        child.OnInitialize();
    }

    protected override EStatus OnUpdate()
    {

        var childStatus = child.Tick();
        if (childStatus == EStatus.Runing)
        {
            return EStatus.Runing;
        }

        if (childStatus == EStatus.Failure)
        {
            return EStatus.Failure;
        }
        repeatCount++;
        //Debug.Log(repeatCount);
        if (repeatCount >= repeatLimt)
        {
            //ֻ��һֱ�ɹ��Ĵ����ﵽ���ƴ������ŷ��سɹ�
            return EStatus.Success;
        }
        child.OnInitialize(); // �����ӽڵ�״̬�Ա��´�ִ��
        return EStatus.Runing;
        
    }
}
