/// <summary>
/// ö�ٽڵ�����״̬
/// </summary>
public enum EStatus
{
    //���У��ɹ���ʧ�ܣ���Ч���ж�
    Runing, Success, Failure, Invalid, Aborted,
}

public abstract class MyBehaviour 
{
    //bool��Ϊ�ж�״̬�Ƿ�ﵽ��
    protected EStatus status;//�ڵ�״̬
    public bool IsRuning => status == EStatus.Runing;
    public bool IsSuccess => status == EStatus.Success;
    public bool IsFailure => status == EStatus.Failure;
    public bool IsEnd => IsSuccess || IsFailure || IsAborted;
    public bool IsAborted => status == EStatus.Aborted;
    //public bool IsInvalid => status == EStatus.Invalid;
    //public bool IsEnd => IsSuccess || IsFailure || IsInvalid || IsAborted;

    //��ʼ�����캯��
    public MyBehaviour()
    {
        status = EStatus.Invalid;
    }

    //������ýڵ�ʱ���ᴥ��һ�θ�״̬
    protected virtual void OnInitializa(){}

    //���ڵ�����ʱ����һֱ������״̬
    protected abstract EStatus OnUpdate();

    //���ڵ��˳�ʱ(���н���ʱ)���ᴥ��һ�θ�״̬
    protected virtual void OnExit(){}

    //�ڵ�����У�ÿ�����з��ص�������Ҳ�����ӽڵ�״̬��Ϊ���������������׼��
    //��Ϊ���Ǹ��ڵ�����ִ�С�ÿ�ζ��ǴӸ��ڵ㿪ʼִ��


    // ֻ�� status == Invalid ʱ�Ż���� OnInitialize��ȷ����ʼ��ִֻ��һ�Ρ�
    //ֻ���� Running ״̬ʱ�Ż���� OnUpdate
    //��ֹ�߼�����״̬��Ϊ�� Running �ҷ� Invalid ʱ������
    //�Ľ��ؼ���

    

    public EStatus Tick()
    {
        if (status == EStatus.Invalid)
        {
            OnInitializa();
            status = EStatus.Runing;
        }
        if (status == EStatus.Runing)
        {
            status = OnUpdate();
        }
        if (status != EStatus.Runing && status !=EStatus.Invalid)
        {
            OnExit();
            //status = EStatus.Invalid;
        }
        return status;
    }

    public virtual void AddChild(MyBehaviour child, int index){}

    //�ϸ����� Invalid��δ�������ֹ״̬��Success/Failure/Aborted����
    //ȷ�� OnInitialize �� OnTerminate ����ȷ��ʱ��������
    //ͨ�� Reset() ��ʽ���ýڵ�״̬��
    public virtual void Reset()
    {
        if (status == EStatus.Runing)
        {
            OnExit();
        }
        status = EStatus.Invalid;
    }


    //�жϵı��ʣ��жϣ�Abort���� ǿ����ֹһ������ִ�е�����
    //����ڵ���δ��ʼ��Invalid�����Ѿ���ɣ�Success/Failure/Aborted�����ж�û�����塣
    //״̬�����Ͻ��ԣ�ֻ�� Running ״̬��ʾ�ڵ�����ִ���У���ʱ����Ҫ��ֹ��
    public virtual void Abort()
    {
        if (status == EStatus.Runing)
        {
            OnExit();
        }
        status = EStatus.Aborted;
    }
}
