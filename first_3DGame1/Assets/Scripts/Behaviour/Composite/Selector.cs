using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    protected LinkedListNode<MyBehaviour> currentChild;//��ǰ���е��ӽڵ�
    public MyBehaviour CurrentChild => currentChild?.Value;//ֻ�����ԣ������ⲿ�޸ģ�?��ֵ�������Ϊ�յĻ����ڱ�������null

    protected override void OnInitializa()
    {
        currentChild = children.First;
    }

    protected override EStatus OnUpdate()
    {
        while(true)
        {
            var currentStatus = currentChild.Value.Tick();//ִ�е�ǰ�ӽڵ㣬����ȡ��ǰ�ӽڵ��״̬

            if (currentStatus != EStatus.Failure)
            {
                return currentStatus;
            }
            currentChild = currentChild.Next;//�����ǰ�ӽڵ��״̬��ʧ�ܣ������ִ����һ���ӽڵ�
            //ȫ��ִ����ϣ�����ʧ��
            if (currentChild == null)
            {
                return EStatus.Failure;//�����ǰ�ӽڵ�Ϊ�գ��򷵻�ʧ��
            }
        }
    }
}
