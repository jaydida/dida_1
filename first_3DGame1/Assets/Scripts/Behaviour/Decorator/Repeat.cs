using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : Decorator
{
    private int repeatCount = 0;//�ظ���������
    public int repeatLimt = 0;//�ظ���������

    protected override void OnInitializa()
    {
        repeatCount = 0;//��ʼ��ʱ�����ظ���������
    }

    protected override EStatus OnUpdate()
    {
        
        while (repeatCount <= repeatLimt)
        {
            child.Tick();
            if (IsRuning)
            {
                return EStatus.Runing;
            }

            if (IsFailure)
            {
                return EStatus.Failure;
            }
            repeatCount++;
        }
        //ֻ��һֱ�ɹ��Ĵ����ﵽ���ƴ������ŷ��سɹ�
        return EStatus.Success;
    }
}
