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
        #region  Time�������
        /* //ʱ��������� ��Ҫ ������Ϸ�в���λ�ƣ���ʱ��ʱ����ͣ��


         //֪ʶ��һ��ʱ�����ű���


         //�������Ϊ��ʱ����ڣ�ʱ�����ű��� * ʱ��
         //Time.timeScale = 1; //�����ٶ�
         Time.timeScale = 0.5f; //������
         //Time.timeScale = 2; //������
         //Time.timeScale = 0; //ʱ��ֹͣ�����徲ֹ�ˡ�

         //֪ʶ�����֡���ʱ��
         //֡���ʱ�䣬�����һ֡ ���˶���ʱ�䣨�룩
         //֡���ʱ�䣬��Ҫ����������λ��
         //·�� = ʱ�� * �ٶ�

         //��sacle��Ӱ��

         print("֡���ʱ��"+Time.deltaTime); //��һ֡����һ֡��ʱ����
         print("����scaleӰ���֡���ʱ��"+Time.unscaledDeltaTime);



         //��Ϸ��ʼ�����ڵ�ʱ�䣬��Ҫ������ʱ��������Ϸ��ʱ��������Ϸһ���Ƿ�������ʱ��
         //��scale��Ӱ�죬Time.time
         //����scale��Ӱ�죬Time.unscaledTime

         //����֡ʱ��
         //Time.fixedDeltaTime,����scaleӰ��
         //Time.unscaledFixedDeltaTime����scaleӰ��

         //֡��
         print("֡��" + Time.frameCount); //����Ϸ��ʼ�����ڵ�֡�������˼���ѭ����

         //��õ�
         //1.֡���ʱ�䣬  ����λ���������
         //2.ʱ�����ű�����������Ϸ��������   ������ͣ���߱����ȵ�
         //3.֡����֡ͬ����

         */
        #endregion


        #region Transform

        //Transform ��Ҫ���������λ�ƣ���ת�����ŵ�
        //Transform �����һ���ǳ���Ҫ��������������е����嶼����������
        //Transform �����Ҫ���������λ�ƣ���ת�����ŵȡ�
        //֪ʶ��һ��Transform ���


        //֪ʶ�����Transform ���������
        //position�������λ��
        //rotation���������ת
        //localScale�����������
        //֪ʶ������Transform ����ķ���
        //Translate��λ��
        //Rotate����ת
        //LookAt������


        //Vector3,��Ҫ������ʾ��ά����ϵ�е�һ���㣬����һ������
        //��������һ���ṹ�塣������new��

        //λ��
        //�����������
        //this.gameObject.transform
        //ͨ��position�õ���λ�� ������� ��������ϵ�� ԭ���λ�á�
        //��������и����壬��ô���λ��������ڸ����������ϵ�ġ����������λ������ԭ��ʱ���Ǻ����һ���ġ�

        //����ڸ���������
        //transform.localPosition,Ҳ�����������ʾ������ֵ

        //transform���ܵ�����һ��ֵ�����粻��transform.position.x = 1; �������ᱨ��
        //transform.position = new Vector3(1, 2, 3); �������ǿ��Եġ�
        //�����Ը�vector3�ĵ���ֵ�����Կ���ȡ����Ȼ���޸ģ��ڸ�ֵ��ȥ��
        //transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z); �������ǿ��Եġ�

        //�����õ�����ǰ�� һ������
        //��ô����ͨ�� transform.������
        //����ǰ�ĸ�����

        //����ǰ���泯�򣬾ֲ�����
        //transform.forward��Z�ᳯ��
        //transform.right��X�ᳯ��
        //transform.up��Y�ᳯ��


        //λ��
        //�������ϵ�µ�λ�Ƽ��㹫ʽ
        //·�� = ���� * �ٶ� * ʱ��

        //��ʽһ  �Լ�����
        //��Ҫ�仯��  ����  position
        //��ǰ��λ�� + �ƶ��ľ��� = �������ڵ�λ��
        //transform.forward �����˵�ǰ����ĳ�����
        //transform.position = transform.position + transform.forward * 1 * Time.deltaTime;

        //�������귽��
        //transform.position = transform.position + Vector3.forward * 1 * Time.deltaTime;


        //��ʽ��  ʹ��transform����ķ��� API
        //����һ����ʾλ�ƶ���  ·�� = ���� * �ٶ� * ʱ�䣬�����Ѿ��з�����
        //����������ʾ �������ϵ  Ĭ�� �ò���  ��������Լ�����ϵ��
        //transform.Translate(Vector3.forward * 1 * Time.deltaTime); //����ھֲ�����ϵλ�ƣ�ʼ���Լ�Z�ᳯ���ƶ�
        //transform.Translate(Vector3.forward * 1 * Time.deltaTime, Space.World); //�������������ϵλ�ƣ�ʼ����������ϵ�� Z�ᳯ���ƶ�
        //transform.Translate(transform.forward * 1 * Time.deltaTime, Space.World); //�������������ϵλ�ƣ�ʼ���Լ��� Z�ᳯ���ƶ�
        //transform.Translate(transform.forward * 1 * Time.deltaTime, Space.Self); //����ھֲ�����ϵλ�ƣ�transform.forward���� �Լ��� Z�ᳯ��Ȼ��ͷ������ˣ������������á�



        #endregion
    }
}
