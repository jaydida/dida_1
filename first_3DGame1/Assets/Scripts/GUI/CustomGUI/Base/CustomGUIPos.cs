using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���뷽ʽö��
/// </summary>
public enum E_Alignment_Type
{
    Up, Down, Left, Right, Center, LeftUp, RightUp, LeftDown, RightDown
}

/// <summary>
/// ����  ��������ʾλ��  ����λ�������Ϣ��  ����Ҫ�̳�monobehaviour
/// </summary>
public class CustomGUIPos 
{
    //����ؼ�λ����ص�����
    //��ɷֱ�������Ӧ����ؼ���

    //��λ����Ϣ  ���������ظ��ⲿ  ���ڻ��ƿؼ�
    //��Ҫ��������  ����  �����Ǹ��Ź���
    //�ؼ�������㹫ʽ  =  �����Ļλ��  +  ���ĵ�ƫ��λ��  +  ƫ��λ��
    private Rect pos = new Rect(0, 0, 100, 100);

    //��Ļ�Ź�����뷽ʽ
    public E_Alignment_Type screen_Alignment_Type;
    //�ؼ����Ķ��뷽ʽ
    public E_Alignment_Type control_Center_Alignment_Type;
    //ƫ��λ��
    public Vector2 offestPos;
    //���
    public float width = 100;
    public float height = 50;

    //���ڼ����  ���ĵ�  ��Ա����
    private Vector2 centerPos;

    public Rect Pos 
    {
        get 
        { 
            //���м���
            //�������ĵ�ƫ��
            CalcCenterPos();
            //���������Ļ�����
            CalcPos();
            //���ֱ�Ӹ�ֵ   ���ظ��ⲿ   ����ֱ��ʹ�������ƿؼ�
            pos.width = width;
            pos.height = height;

            return pos; 
        } 
    }
    /// <summary>
    /// �������ĵ�ƫ�Ƶķ�����ÿһ���ؼ���
    /// </summary>
    private void CalcCenterPos()
    {
        switch (control_Center_Alignment_Type)
        {
            case E_Alignment_Type.Left:
                centerPos.x = 0;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Right:
                centerPos.x = -width;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Center:
                centerPos.x = -width / 2;
                centerPos.y = -height / 2 ;
                break;
            case E_Alignment_Type.LeftUp:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.RightUp:
                centerPos.x = -width;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Up:
                centerPos.x = -width / 2;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Down:
                centerPos.x = -width / 2;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.LeftDown:
                centerPos.x = 0;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.RightDown:
                centerPos.x = -width;
                centerPos.y = -height;
                break;
        }
    }

    /// <summary>
    /// ���������������λ�õķ���
    /// </summary>
    private void CalcPos()
    {
        switch (screen_Alignment_Type)
        {
            case E_Alignment_Type.Left:
                pos.x = centerPos.x + offestPos.x;
                pos.y = Screen.height / 2 + centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.Right:
                pos.x = Screen.width + centerPos.x - offestPos.x;
                pos.y = Screen.height / 2 + centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.Center:
                pos.x = Screen.width / 2 + centerPos.x + offestPos.x;
                pos.y = Screen.height / 2 + centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.LeftUp:
                pos.x = centerPos.x + offestPos.x;
                pos.y = centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.RightUp:
                pos.x = Screen.width + centerPos.x - offestPos.x;
                pos.y = centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.Up:
                pos.x = Screen.width / 2 + centerPos.x + offestPos.x;
                pos.y = 0 + centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.Down:
                pos.x = Screen.width / 2 + centerPos.x + offestPos.x;
                pos.y = Screen.height + centerPos.y - offestPos.y;
                break;
            case E_Alignment_Type.LeftDown:
                pos.x = centerPos.x + offestPos.x;
                pos.y = Screen.height + centerPos.y - offestPos.y;
                break;
            case E_Alignment_Type.RightDown:
                pos.x = Screen.width + centerPos.x - offestPos.x;
                pos.y = Screen.height + centerPos.y - offestPos.y;
                break;

        }
    }
}
