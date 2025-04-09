using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{

    #region 生命周期函数
    
    private void Awake()
    {
        // 当对象（自己这个类对象）被创建时 才会调用该生命周期函数
        // 该函数只会被调用一次
        // 自己本身被创建时会调用，因为继承了MonoBehaviour，不能直接new出来，所以挂载到物体身上就叫创建。
        // 类似于构造函数
    }

    
    private void OnEnable()
    {
        // 对于我们来说，想要当一个对象被激活时 进行一些逻辑处理  就可以写在这个函数里
        // 激活就是说这个依附的Gameobject对象activeSelf为true
        // 该脚本激活或者失活也会触发该函数。
        // 该函数会被调用多次
        Debug.Log("OnEnable");
    }

   
    void Start()
    {
        // 从自己被创建后，第一次帧更新之前调用,Awake -> OnEnable -> Start:如果OnEnable被调用了多次，Start只会被调用一次
        // 一个对象只会调用一次
        // Start is called before the first frame update
    }

    private void FixedUpdate()
    {
        //它主要是用于进行物理更新，这个函数的调用频率是固定的
        // FixedUpdate是每一帧都调用的，但它的帧跟游戏帧率无关
        //它的时间间隔  是可以在 project settings中的 Time里设置的
        // FixedUpdate is called every fixed framerate frame
        // 物理引擎更新的频率
        // 物理引擎更新的频率是固定的
        // 50帧每秒
    }

    


    // Update is called once per frame
    void Update()
    {
        // 每一帧都会调用
        // 主要用于处理游戏核心逻辑更新的函数。
    }

    private void LateUpdate()
    {
        // 在每一帧的最后调用
        // 主要用于处理相机跟随等逻辑
        // 该函数在所有Update函数之后被调用
        // LateUpdate is called every frame, if the Behaviour is enabled.
        // 如果在update里面更新摄像机的话，可能会造成黑屏，渲染的错误。
    }

    private void OnDisable()
    {
        // 当对象被禁用时调用
        // 该函数会被调用多次
        // 该函数在所有Update函数之后被调用
        Debug.Log("OnDisable");
        //如果我们希望在对象被禁用失活时进行一些逻辑处理，就可以写在这个函数里
    }

    private void OnDestroy()
    {
        // 当对象被销毁时调用
        // 该函数只会被调用一次
        // 该函数在所有Update函数之后被调用
        Debug.Log("OnDestroy");
        // 如果我们希望在对象被销毁时进行一些逻辑处理，就可以写在这个函数里
    }

    #endregion


    #region 生命周期函数 支持继承多态
    //    多态（Polymorphism） 是面向对象编程（OOP）的三大核心特性之一（另外两个是封装和继承），它的核心思想是 “同一操作作用于不同对象，可以有不同的实现方式”。
    //    简单来说，多态允许不同类的对象对同一方法调用做出不同的响应，从而实现更灵活和可扩展的代码设计。

    //多态的核心思想
    //同一个接口，多种实现：父类或接口定义方法（形式），子类或具体实现类提供不同的具体行为（内容）。
    //动态绑定：程序在运行时（而非编译时）根据对象的实际类型决定调用哪个方法。
    //多态的类型
    //多态通常分为两种形式：

    //1. 编译时多态（静态多态）
    //方法重载（Overloading）：
    //同一类中定义多个同名方法，但参数类型或数量不同。

    //csharp
    //复制
    public class Calculator
    {
        public int Add(int a, int b) { return a + b; }
        public float Add(float a, float b) { return a + b; } // 重载
    }
    //2. 运行时多态（动态多态）
    //方法重写（Overriding）：
    //子类通过 override 关键字重新定义父类的虚方法（virtual）或抽象方法（abstract）。

    //csharp
    //复制
    public class Animal
    {
        public virtual void Speak()
        {
            Debug.Log("Animal sound");
        }
    }

    public class Dog : Animal
    {
        public override void Speak()
        { // 重写父类方法
            Debug.Log("Woof!");
        }
    }

    public class Cat : Animal
    {
        public override void Speak()
        { // 重写父类方法
            Debug.Log("Meow!");
        }
    }
    //    接口多态：
    //不同类实现同一接口，并各自实现接口定义的方法。

    //csharp
    //复制
    public interface IDamageable
    {
        void TakeDamage(int damage);
    }

    public class Player : IDamageable
    {
        public void TakeDamage(int damage) { /* 玩家受伤逻辑 */ }
    }

    public class Enemy : IDamageable
    {
        public void TakeDamage(int damage) { /* 敌人受伤逻辑 */ }
    }

    #endregion

    //

}
