using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{

    #region 生命周期函数
    // 当对象（自己这个类对象）被创建时 才会调用该生命周期函数
    // 该函数只会被调用一次
    // 自己本身被创建时会调用，因为继承了MonoBehaviour，不能直接new出来，所以挂载到物体身上就叫创建。
    // 类似于构造函数
    private void Awake()
    {
        
    }

    // 对于我们来说，想要当一个对象被激活时 进行一些逻辑处理  就可以写在这个函数里
    // 激活就是说这个依附的Gameobject对象activeSelf为true
    // 该脚本激活或者失活也会触发该函数。
    // 该函数会被调用多次
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // 从自己被创建后，第一次帧更新之前调用,Awake -> OnEnable -> Start:如果OnEnable被调用了多次，Start只会被调用一次
    // 一个对象只会调用一次
    // Start is called before the first frame update
    void Start()
    {

    }

    #endregion


    // Update is called once per frame
    void Update()
    {
        
    }
}
