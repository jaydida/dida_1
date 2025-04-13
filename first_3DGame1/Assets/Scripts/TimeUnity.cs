using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUnity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region  Time相关内容
        /* //时间相关内容 主要 用于游戏中参与位移，记时，时间暂停等


         //知识点一，时间缩放比例


         //可以理解为。时间等于，时间缩放比例 * 时间
         //Time.timeScale = 1; //正常速度
         Time.timeScale = 0.5f; //慢半拍
         //Time.timeScale = 2; //快两倍
         //Time.timeScale = 0; //时间停止，物体静止了。

         //知识点二，帧间隔时间
         //帧间隔时间，最近的一帧 用了多少时间（秒）
         //帧间隔时间，主要是用来计算位移
         //路程 = 时间 * 速度

         //受sacle的影响

         print("帧间隔时间"+Time.deltaTime); //上一帧到这一帧的时间间隔
         print("不受scale影响的帧间隔时间"+Time.unscaledDeltaTime);



         //游戏开始到现在的时间，主要用来记时，单机游戏记时，网络游戏一般是服务器记时。
         //受scale的影响，Time.time
         //不受scale的影响，Time.unscaledTime

         //物理帧时间
         //Time.fixedDeltaTime,不受scale影响
         //Time.unscaledFixedDeltaTime，受scale影响

         //帧数
         print("帧数" + Time.frameCount); //从游戏开始到现在的帧数，跑了几次循环。

         //最常用的
         //1.帧间隔时间，  计算位移相关内容
         //2.时间缩放比例，单机游戏这样做，   用来暂停或者倍数等等
         //3.帧数（帧同步）

         */
        #endregion


        #region Transform

        //Transform 主要用于物体的位移，旋转，缩放等
        //Transform 组件是一个非常重要的组件，几乎所有的物体都有这个组件。
        //Transform 组件主要用于物体的位移，旋转，缩放等。
        //知识点一，Transform 组件


        //知识点二，Transform 组件的属性
        //position：物体的位置
        //rotation：物体的旋转
        //localScale：物体的缩放
        //知识点三，Transform 组件的方法
        //Translate：位移
        //Rotate：旋转
        //LookAt：朝向


        //Vector3,主要用来表示三维坐标系中的一个点，或者一个向量
        //这玩意是一个结构体。可以用new。

        //位置
        //相对世界坐标
        //this.gameObject.transform
        //通过position得到的位置 是相对于 世界坐标系的 原点的位置。
        //如果对象有父物体，那么这个位置是相对于父物体的坐标系的。当父对象的位置是在原点时，是和面板一样的。

        //相对于父对象坐标
        //transform.localPosition,也就是面板上显示的坐标值

        //transform不能单独改一个值。例如不能transform.position.x = 1; 这样做会报错。
        //transform.position = new Vector3(1, 2, 3); 这样做是可以的。
        //但可以改vector3的单独值。所以可以取出，然后修改，在赋值回去。
        //transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z); 这样做是可以的。

        //如果想得到对象当前的 一个朝向
        //那么就是通过 transform.出来的
        //对象当前的各朝向

        //对象当前的面朝向，局部坐标
        //transform.forward，Z轴朝向
        //transform.right，X轴朝向
        //transform.up，Y轴朝向


        //位移
        //理解坐标系下的位移计算公式
        //路程 = 方向 * 速度 * 时间

        //方式一  自己计算
        //想要变化的  就是  position
        //当前的位置 + 移动的距离 = 最终所在的位置
        //transform.forward 代表了当前物体的朝向方向
        //transform.position = transform.position + transform.forward * 1 * Time.deltaTime;

        //世界坐标方向
        //transform.position = transform.position + Vector3.forward * 1 * Time.deltaTime;


        //方式二  使用transform组件的方法 API
        //参数一：表示位移多少  路程 = 方向 * 速度 * 时间，这里已经有方向了
        //参数二：表示 相对坐标系  默认 该参数  是相对于自己坐标系的
        //transform.Translate(Vector3.forward * 1 * Time.deltaTime); //相对于局部坐标系位移，始终自己Z轴朝向移动
        //transform.Translate(Vector3.forward * 1 * Time.deltaTime, Space.World); //相对于世界坐标系位移，始终世界坐标系的 Z轴朝向移动
        //transform.Translate(transform.forward * 1 * Time.deltaTime, Space.World); //相对于世界坐标系位移，始终自己的 Z轴朝向移动
        //transform.Translate(transform.forward * 1 * Time.deltaTime, Space.Self); //相对于局部坐标系位移，transform.forward又是 自己的 Z轴朝向，然后就方向乱了，不建议这样用。



        #endregion
    }
}
