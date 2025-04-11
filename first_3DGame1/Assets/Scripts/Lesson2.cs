using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    #region  让私有和保护的也可以在Inspector面板上显示
    //加上强制序列化字段
    //[SerializeField]
    //所谓序列化就是把一个对象保存到一个文件或数据库中去。
    #endregion
    #region 公共的也不让其显示编辑
    //在变量前加上特性
    //[HideInInspector]
    //这些事unity使用反射和特性来实现的
    #endregion

    #region 自定义类型不能在Inspector面板上显示
    //例如字典，自定义结构体
    //加上序列化特性就能让自定义类型显示在Inspector面板上。[System.Serializable]
    //字典怎么都不行
    #endregion

    #region 一些辅助特性
    //[Header("xyz")]
    //分组说明特性Header
    //为成员分组

    //[Tooltip("xyz")]
    //悬停注释特性

    //[Space()]
    //间隔特性
    //让两个字段之间有间隔

    //[Range(min, max)]
    //修饰数值滑条范围Range
    //通过滑动条拖动来设置数值

    //[Multiline()]
    //多行文本特性

    //[TextArea(minLines, maxLines)]
    //文本区域特性
    //让文本区域可以多行显示
    #endregion
}
