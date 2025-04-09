using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{

    #region �������ں���
    
    private void Awake()
    {
        // �������Լ��������󣩱�����ʱ �Ż���ø��������ں���
        // �ú���ֻ�ᱻ����һ��
        // �Լ���������ʱ����ã���Ϊ�̳���MonoBehaviour������ֱ��new���������Թ��ص��������Ͼͽд�����
        // �����ڹ��캯��
    }

    
    private void OnEnable()
    {
        // ����������˵����Ҫ��һ�����󱻼���ʱ ����һЩ�߼�����  �Ϳ���д�����������
        // �������˵���������Gameobject����activeSelfΪtrue
        // �ýű��������ʧ��Ҳ�ᴥ���ú�����
        // �ú����ᱻ���ö��
        Debug.Log("OnEnable");
    }

   
    void Start()
    {
        // ���Լ��������󣬵�һ��֡����֮ǰ����,Awake -> OnEnable -> Start:���OnEnable�������˶�Σ�Startֻ�ᱻ����һ��
        // һ������ֻ�����һ��
        // Start is called before the first frame update
    }

    private void FixedUpdate()
    {
        //����Ҫ�����ڽ���������£���������ĵ���Ƶ���ǹ̶���
        // FixedUpdate��ÿһ֡�����õģ�������֡����Ϸ֡���޹�
        //����ʱ����  �ǿ����� project settings�е� Time�����õ�
        // FixedUpdate is called every fixed framerate frame
        // ����������µ�Ƶ��
        // ����������µ�Ƶ���ǹ̶���
        // 50֡ÿ��
    }

    


    // Update is called once per frame
    void Update()
    {
        // ÿһ֡�������
        // ��Ҫ���ڴ�����Ϸ�����߼����µĺ�����
    }

    private void LateUpdate()
    {
        // ��ÿһ֡��������
        // ��Ҫ���ڴ������������߼�
        // �ú���������Update����֮�󱻵���
        // LateUpdate is called every frame, if the Behaviour is enabled.
        // �����update�������������Ļ������ܻ���ɺ�������Ⱦ�Ĵ���
    }

    private void OnDisable()
    {
        // �����󱻽���ʱ����
        // �ú����ᱻ���ö��
        // �ú���������Update����֮�󱻵���
        Debug.Log("OnDisable");
        //�������ϣ���ڶ��󱻽���ʧ��ʱ����һЩ�߼������Ϳ���д�����������
    }

    private void OnDestroy()
    {
        // ����������ʱ����
        // �ú���ֻ�ᱻ����һ��
        // �ú���������Update����֮�󱻵���
        Debug.Log("OnDestroy");
        // �������ϣ���ڶ�������ʱ����һЩ�߼������Ϳ���д�����������
    }

    #endregion


    #region �������ں��� ֧�ּ̳ж�̬
    //    ��̬��Polymorphism�� ����������̣�OOP���������������֮һ�����������Ƿ�װ�ͼ̳У������ĺ���˼���� ��ͬһ���������ڲ�ͬ���󣬿����в�ͬ��ʵ�ַ�ʽ����
    //    ����˵����̬����ͬ��Ķ����ͬһ��������������ͬ����Ӧ���Ӷ�ʵ�ָ����Ϳ���չ�Ĵ�����ơ�

    //��̬�ĺ���˼��
    //ͬһ���ӿڣ�����ʵ�֣������ӿڶ��巽������ʽ������������ʵ�����ṩ��ͬ�ľ�����Ϊ�����ݣ���
    //��̬�󶨣�����������ʱ�����Ǳ���ʱ�����ݶ����ʵ�����;��������ĸ�������
    //��̬������
    //��̬ͨ����Ϊ������ʽ��

    //1. ����ʱ��̬����̬��̬��
    //�������أ�Overloading����
    //ͬһ���ж�����ͬ�����������������ͻ�������ͬ��

    //csharp
    //����
    public class Calculator
    {
        public int Add(int a, int b) { return a + b; }
        public float Add(float a, float b) { return a + b; } // ����
    }
    //2. ����ʱ��̬����̬��̬��
    //������д��Overriding����
    //����ͨ�� override �ؼ������¶��常����鷽����virtual������󷽷���abstract����

    //csharp
    //����
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
        { // ��д���෽��
            Debug.Log("Woof!");
        }
    }

    public class Cat : Animal
    {
        public override void Speak()
        { // ��д���෽��
            Debug.Log("Meow!");
        }
    }
    //    �ӿڶ�̬��
    //��ͬ��ʵ��ͬһ�ӿڣ�������ʵ�ֽӿڶ���ķ�����

    //csharp
    //����
    public interface IDamageable
    {
        void TakeDamage(int damage);
    }

    public class Player : IDamageable
    {
        public void TakeDamage(int damage) { /* ��������߼� */ }
    }

    public class Enemy : IDamageable
    {
        public void TakeDamage(int damage) { /* ���������߼� */ }
    }

    #endregion

    //

}
