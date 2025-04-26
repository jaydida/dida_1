using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Node_Type
{
    //可以走的地方
    Walk,
    //不能走的地方
    Stop
}


/// <summary>
/// AStart格子类
/// </summary>
public class AStartNode 
{
    //格子对象坐标
    public int x;
    public int y;

    //寻路消耗
    public float f;
    //离起点的距离
    public float g;
    //离终点的距离
    public float h;
    //父对象
    public AStartNode father;

    //格子的类型
    public E_Node_Type type;

    /// <summary>
    /// 构造函数传入坐标和类型
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="type"></param>
    public AStartNode(int x, int y, E_Node_Type type)
    {
        this.x = x; 
        this.y = y;
        this.type = type;
    }

}
