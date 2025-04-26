using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Node_Type
{
    //�����ߵĵط�
    Walk,
    //�����ߵĵط�
    Stop
}


/// <summary>
/// AStart������
/// </summary>
public class AStartNode 
{
    //���Ӷ�������
    public int x;
    public int y;

    //Ѱ·����
    public float f;
    //�����ľ���
    public float g;
    //���յ�ľ���
    public float h;
    //������
    public AStartNode father;

    //���ӵ�����
    public E_Node_Type type;

    /// <summary>
    /// ���캯���������������
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
