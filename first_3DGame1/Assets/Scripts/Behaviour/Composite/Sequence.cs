using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Composite
{
    protected LinkedListNode<MyBehaviour> currentChild;//��ǰ���е��ӽڵ�
    public MyBehaviour CurrentChild => currentChild?.Value;//ֻ�����ԣ������ⲿ�޸ģ�?��ֵ�������Ϊ�յĻ����ڱ�������null

    protected override void OnInitializa()
    {
        currentChild = children.First;
    }

    protected override EStatus OnUpdate()
    {
        while (true)
        {
            var currentStatus = currentChild.Value.Tick();//ִ�е�ǰ�ӽڵ㣬����ȡ��ǰ�ӽڵ��״̬
            if (currentStatus != EStatus.Success)
            {
                return currentStatus;
            }

            currentChild = currentChild.Next;//�����ǰ�ӽڵ��״̬�ǳɹ��������ִ����һ���ӽڵ�
            //ȫ��ִ����ϣ����سɹ�
            if (currentChild == null)
            {
                return EStatus.Success;//�����ǰ�ӽڵ�Ϊ�գ��򷵻سɹ�
            }

        }
       

    }
}