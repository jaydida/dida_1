using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{

    #region �������ں���
    // �������Լ��������󣩱�����ʱ �Ż���ø��������ں���
    // �ú���ֻ�ᱻ����һ��
    // �Լ���������ʱ����ã���Ϊ�̳���MonoBehaviour������ֱ��new���������Թ��ص��������Ͼͽд�����
    // �����ڹ��캯��
    private void Awake()
    {
        
    }

    // ����������˵����Ҫ��һ�����󱻼���ʱ ����һЩ�߼�����  �Ϳ���д�����������
    // �������˵���������Gameobject����activeSelfΪtrue
    // �ýű��������ʧ��Ҳ�ᴥ���ú�����
    // �ú����ᱻ���ö��
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // ���Լ��������󣬵�һ��֡����֮ǰ����,Awake -> OnEnable -> Start:���OnEnable�������˶�Σ�Startֻ�ᱻ����һ��
    // һ������ֻ�����һ��
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
