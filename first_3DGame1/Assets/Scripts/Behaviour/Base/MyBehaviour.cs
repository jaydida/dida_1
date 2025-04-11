/// <summary>
/// 枚举节点运行状态
/// </summary>
public enum EStatus
{
    //运行，成功，失败，无效，中断
    Runing, Success, Failure, Invalid, Aborted,
}

public abstract class MyBehaviour 
{
    //bool作为判断状态是否达到。
    protected EStatus status;//节点状态
    public bool IsRuning => status == EStatus.Runing;
    public bool IsSuccess => status == EStatus.Success;
    public bool IsFailure => status == EStatus.Failure;
    public bool IsEnd => IsSuccess || IsFailure || IsAborted;
    public bool IsAborted => status == EStatus.Aborted;
    //public bool IsInvalid => status == EStatus.Invalid;
    //public bool IsEnd => IsSuccess || IsFailure || IsInvalid || IsAborted;

    //初始化构造函数
    public MyBehaviour()
    {
        status = EStatus.Invalid;
    }

    //当进入该节点时，会触发一次该状态
    protected virtual void OnInitializa(){}

    //当节点运行时，会一直触发该状态
    protected abstract EStatus OnUpdate();

    //当节点退出时(运行结束时)，会触发一次该状态
    protected virtual void OnExit(){}

    //节点的运行，每次运行返回调查结果，也就是子节点状态，为其接下来的运行做准备
    //行为树是根节点驱动执行。每次都是从根节点开始执行


    // 只有 status == Invalid 时才会调用 OnInitialize，确保初始化只执行一次。
    //只有在 Running 状态时才会调用 OnUpdate
    //终止逻辑仅在状态变为非 Running 且非 Invalid 时触发。
    //改进关键：

    

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

    //严格区分 Invalid（未激活）和终止状态（Success/Failure/Aborted）。
    //确保 OnInitialize 和 OnTerminate 在正确的时机触发。
    //通过 Reset() 显式重置节点状态。
    public virtual void Reset()
    {
        if (status == EStatus.Runing)
        {
            OnExit();
        }
        status = EStatus.Invalid;
    }


    //中断的本质：中断（Abort）是 强制终止一个正在执行的任务。
    //如果节点尚未开始（Invalid）或已经完成（Success/Failure/Aborted），中断没有意义。
    //状态机的严谨性：只有 Running 状态表示节点正在执行中，此时才需要终止。
    public virtual void Abort()
    {
        if (status == EStatus.Runing)
        {
            OnExit();
        }
        status = EStatus.Aborted;
    }
}
