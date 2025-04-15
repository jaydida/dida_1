using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Filter��ͨ��ֻ��һ��������һ���������൱��һ��װ�νڵ�
public class Filter : Composite
{
    protected LinkedListNode<MyBehaviour> currentChild;//��ǰ���е��ӽڵ�
    public MyBehaviour CurrentChild => currentChild?.Value;//ֻ�����ԣ������ⲿ�޸ģ�?��ֵ�������Ϊ�յĻ����ڱ�������null
    private int conditionCount = 0;//�������������жϵ�ǰ�ڵ��Ƿ��������ڵ�
    private int actionCount = 0;//�������������жϵ�ǰ�ڵ��Ƿ��Ƕ����ڵ�
    //private int currentIndex = 0;//��ǰ��������¼��ǰ�ڵ���children�е�����λ��,�̳е��и�ֵ��

    //��������Ҳ���Ǹ��������������Ƿ�ִ���ӽڵ�
    //�൱����ִ�����������������������ִ���ӽڵ�
    public void SetCondition(MyBehaviour condition)
    {
        if (condition == null)
        {
            Debug.LogError("��������Ϊ��");
            return;
        }
        conditionCount++;
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
        actionCount++;
        children.AddLast(Action);
    }

    public override void OnInitialize()
    {
        status = EStatus.Invalid;
        currentChild = children.First;
        for (int i = 0; i < children.Count; i++)
        {
            currentChild.Value.OnInitialize();
            currentChild = currentChild.Next;
        }
        currentChild = children.First;
    }

    protected override EStatus OnUpdate()
    {
        if(conditionCount == 0 || actionCount == 0)
        {
            Debug.LogWarning("Filter�ڵ�������Ҫһ��������һ������");
            return EStatus.Failure;
        }

        for (int i = currentIndex; i < conditionCount; i++)
        {
            if (currentChild.Value.Tick() == EStatus.Failure)
            {
                currentIndex = 0;//����ʧ�ܣ���������
                currentChild = children.First;
                return EStatus.Failure;
            }
            else if (currentChild.Value.Tick() == EStatus.Runing)
            {
                currentIndex = i;//��¼��ǰ������ͨ���ľͱ���ִ����
                return EStatus.Runing;
            }
            else
            {
                currentChild = currentChild.Next;
            }
        }

        for (int i = 0; i < actionCount; i++)
        {
            if(currentChild.Value.Tick() == EStatus.Failure)
            {
                currentIndex = 0;//����ʧ�ܣ���������
                currentChild = children.First;
                return EStatus.Failure;
            }
            else if (currentChild.Value.Tick() == EStatus.Runing)
            {
                currentIndex = i;//��¼��ǰ������ͨ���ľͱ���ִ����
                return EStatus.Runing;
            }
            else
            {
                currentChild = currentChild.Next;
            }
        }

        return EStatus.Success;

    }
}
