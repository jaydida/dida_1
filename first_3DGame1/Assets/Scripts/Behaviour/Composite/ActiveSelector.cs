using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ����ѡ��������֮ǰѡ��Ⱥ�Ļ����ϻ������ȼ��жϣ�Ҳ���������������ִ�е����ȼ�
/// �������ȼ��Ļָ���ִ�е�״̬�ˣ�����ʧ�ܣ����жϵ�ǰ״ִ̬�У������ȼ�״̬��
/// ��Ҫһ���������ȼ���״̬�����жϵ�ǰ״̬�Ƿ�����жϵ�ǰ״̬��
/// ��ʹ�ø�����ѡ����ʱ���������ȼ���״̬����ǰ�棬�����ȼ���״̬���ں��档
/// </summary>
public class ActiveSelector : Selector
{
    //protected LinkedListNode<MyBehaviour> currentChildActive;//��ǰ���е��ӽڵ�,������ѡ�����У���ǰ���е��ӽڵ���ָ��ǰ����ִ�е��ӽڵ㣬�������
    //ÿ��ִ�ж���ͷ��ʼ��������
    protected override EStatus OnUpdate()
    {
        var currentChildActive = currentChild;//ִ�е�ǰ�ӽڵ㣬����ȡ��ǰ�ӽڵ��״̬
        currentChild = children.First;//���õ�ǰ�ӽڵ�Ϊ��һ���ӽڵ�

        //����ִ�е�ʱ�򣬻ὫcurrentChild�ı䡣�����Ѿ����ӽڵ�ִ���ˡ�Ҫô����Ϊ�����ȼ��Ŀ���ִ���ˣ�Ҫô����Ϊ��ǰ�ӽڵ㲻��ִ����
        var currentStatusActive = base.OnUpdate();
        if (currentChild != null && currentChildActive != currentChild)
        {
            //�����ǰ�ӽڵ㲻Ϊ�գ�˵�������ӽڵ�ûִ�С���ֻҪ�����ڵ㲻һ��������ָ�ڼ����ӽڵ㣩���ʹ�ϵ�ǰ�ڵ㡣
            currentChildActive.Value.Abort();//�����ǰ�ӽڵ㲻�ǵ�ǰ����ִ�е��ӽڵ㣬���˳���ǰ����ִ�е��ӽڵ�
        }
        return currentStatusActive;//���ص�ǰ�ӽڵ��״̬
    }

}
