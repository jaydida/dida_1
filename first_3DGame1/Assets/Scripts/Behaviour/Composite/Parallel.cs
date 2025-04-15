using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallel : Composite
{
    public enum EParallelType
    {
        All,One,
    }

    protected EParallelType parallelSuccess;
    protected EParallelType parallelFailure;
    private List<EStatus> childStatus;//��¼�ӽڵ��״̬��ֻ�����ӽڵ㷵��running��ʱ����һ����Щ�ڵ��Tick�Ż�ִ�С����ٲ���Ҫ��Tick����

    //���캯����ʼ����ʱ�򣬸��ݴ���Ĳ������ò��гɹ���ʧ�ܵ�����
    public Parallel(EParallelType parallelSuccess, EParallelType parallelFailure)
    {
        this.parallelSuccess = parallelSuccess;
        this.parallelFailure = parallelFailure;
    }

    public override void OnInitialize()
    {
        //��ʼ���ӽڵ��״̬
        childStatus = new List<EStatus>();
        for (int i = 0; i < children.Count; i++)
        {
            childStatus.Add(EStatus.Runing);
        }
    }

    protected override EStatus OnUpdate()
    {
        int successCount = 0;
        int failureCount = 0;
        int Length = children.Count;
        bool allCompleted = true; // �Ƿ������ӽڵ㶼�����
        if (Length == 0)
        {
            return EStatus.Failure;
        }
        var currentchlid = children.First;
        for (int i = 0; i < Length; i++)
        {
            //��δ���ԣ�������ܴ����߼����⡣

            if (childStatus[i] == EStatus.Runing)
            {
                for (int j = 0; j < i; j++)
                {
                    currentchlid = currentchlid.Next;
                }
                childStatus[i] = currentchlid.Value.Tick();
                currentchlid = children.First;
            }

            if (childStatus[i] == EStatus.Success)
            {
                successCount++;
                //���ֻ��Ҫһ���ɹ�����ɹ�
                if (parallelSuccess == EParallelType.One)
                {
                    return EStatus.Success;
                }
            }
            else if (childStatus[i] == EStatus.Failure)
            {
                failureCount++;
                //ͬ�����ֻ��Ҫһ��ʧ�ܾ���ʧ��
                if (parallelFailure == EParallelType.One)
                {
                    return EStatus.Failure;
                }
            }
            else
            {
                allCompleted = false;
            }

        }
        //�����All���͵Ĳ��У�����Ҫ�ж������ӽڵ��״̬
        if (parallelSuccess == EParallelType.All && successCount == Length)
        {
            return EStatus.Success;
        }

        if (parallelFailure == EParallelType.All && failureCount == Length)
        {
            return EStatus.Failure;
        }
        //�����ӽڵ㶼����ˣ�����û�гɹ�����ʧ�ܣ��ͷ���ʧ�ܡ�û��ɾ���Runing��
        return allCompleted ? EStatus.Failure : EStatus.Runing;

    }


    protected override void OnExit()
    {
        foreach (var child in children)
        {
            if (child.IsRuning)
            {
                child.Abort();
            }
           
        }
    }
}
