using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAstar : MonoBehaviour
{
    //���Ͻǵ�һ���������λ��
    public int beginX = -3;
    public int beginY = 5;
    //֮��ÿһ��������֮���  ƫ��λ��
    public int offsetX = 2;
    public int offsetY = 2;
    //��ͼ�Ŀ��
    public int mapW = 5;
    public int mapH = 5;

    //��ʼ����һ����������
    private Vector2 beginPos = Vector2.right * -1;

    //�洢��������ֵ�
    private Dictionary<string, GameObject> cubeDic = new Dictionary<string, GameObject>();

    List<AStartNode> listNodePath;

    public Material red;
    public Material yellow;
    public Material green;
    public Material normal;


    // Start is called before the first frame update
    void Start()
    {
        AStartMgr.Instance.InitMapInfo(mapW, mapH);
        for (int i = 0; i < mapW; i++)
        {
            for (int j = 0; j < mapH; j++)
            {
                //����ÿһ���������λ��
                Vector3 pos = new Vector3(beginX + i * offsetX, beginY - j * offsetY, 0);
                //����������
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //�����������λ��
                cube.transform.position = pos;
                //����������Ĵ�С
                cube.transform.localScale = new Vector3(1, 1, 1);
                //���������������
                cube.name = i + "_" + j;
                //�洢�����嵽�ֵ���
                cubeDic.Add(cube.name, cube);

                //�õ������ж����ǲ����赲
                AStartNode node = AStartMgr.Instance.nodes[i, j];
                if (node.type == E_Node_Type.Stop)
                {
                    cube.GetComponent<MeshRenderer>().material = red;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�������������
        if (Input.GetMouseButtonDown(0))
        {
            //�������߼��
            RaycastHit info;
            //�õ���Ļ���λ�÷���ȥ������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //���߼��,��һ�����������ߣ��ڶ������������߼�⵽���������Ϣ���س�ȥ�����������������ߵĳ���
            if ((Physics.Raycast(ray, out info, 1000)))
            {
                
                if(beginPos == Vector2.right * -1)
                {
                    //�����һ��·��  ����ɫ������������Ϊ��ɫ
                    //�����Ϊ�� ˵����һ����·���ҳɹ���
                    if(listNodePath != null)
                    {
                        for (int i = 0; i < listNodePath.Count; i++)
                        {
                            //�õ�·���ϵĽڵ�
                            AStartNode node = listNodePath[i];
                            //�õ������������
                            string name = node.x + "_" + node.y;
                            //�õ�������
                            GameObject cube = cubeDic[name];
                            //�������������ɫ
                            cube.GetComponent<MeshRenderer>().material = normal;
                            //cubeDic[node.x + "_" + node.y].GetComponent<MeshRenderer>().material = red;
                        }
                    }
                    //�õ�������������壬����֪���ǵڼ��еڼ���
                    string[] strs = info.collider.gameObject.name.Split('_');
                    beginPos = new Vector2(int.Parse(strs[0]), int.Parse(strs[1]));
                    //�������������ɫ
                    info.collider.gameObject.GetComponent<MeshRenderer>().material = yellow;
                }
                else
                {
                    //�õ�������������壬����֪���ǵڼ��еڼ���
                    string[] strs = info.collider.gameObject.name.Split('_');
                    //�����յ�
                    Vector2 endPos = new Vector2(int.Parse(strs[0]), int.Parse(strs[1]));
                    //�������������ɫ
                    info.collider.gameObject.GetComponent<MeshRenderer>().material = yellow;
                    //��ʼѰ·
                    listNodePath = AStartMgr.Instance.FindPath(beginPos, endPos);
                    //�����Ϊ�գ�˵���ҵ���·��
                    if (listNodePath != null)
                    {
                        for(int i = 0; i < listNodePath.Count; i++)
                        {
                            //�õ�·���ϵĽڵ�
                            AStartNode node = listNodePath[i];
                            //�õ������������
                            string name = node.x + "_" + node.y;
                            //�õ�������
                            GameObject cube = cubeDic[name];
                            //�������������ɫ
                            cube.GetComponent<MeshRenderer>().material = green;
                        }
                    }
                    //������ԣ����������
                    //��������Ϊ��ʼֵ
                    beginPos = Vector2.right * -1;
                }
               
            }
        }
    }
}
