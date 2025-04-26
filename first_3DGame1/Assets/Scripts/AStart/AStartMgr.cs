using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AStartѰ·������  ����ģʽ
/// </summary>
public class AStartMgr 
{
    //��ͼ��ص����еĸ��Ӷ�������
    public AStartNode[,] nodes;
    //�����б�,�͵���new��ʼ����
    private List<AStartNode> openList = new List<AStartNode>();
    //�ر��б�
    private List<AStartNode> closeList = new List<AStartNode>();

    //��ͼ���
    private int mapW;
    private int mapH;

    private static AStartMgr instance;
    public static AStartMgr Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = new AStartMgr();
            }
            return instance;
        }
    }
    private AStartMgr()
    {
        instance = this;
    }

    //��ʼ����ͼ���ӵķ���
    public void InitMapInfo(int w, int h)
    {
        //��¼���
        mapH = h;
        mapW = w;

        //������������װ���ٸ�����
        nodes = new AStartNode[w, h];
        //���ݿ��  ��������  �赲������  �����
        //��Ϊ����û�е�ͼ��ص�����

        //��������   װ��ȥ
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                //���������赲  ֻ��Ϊ�˸���ҽ��߼���������д
                //�Ժ���������Ŀ��  ��Щ�赲��ϢӦ���Ǵӵ�ͼ�����ļ��ж�ȡ����  ��Ӧ���������
                //randomValue = Random.Range(0, 101);
                //AStartNode node;
                //if (randomValue < 5)
                //{
                //     node = new AStartNode(i, j, E_Node_Type.Stop);
                //}
                //else 
                //{
                //     node = new AStartNode(i, j, E_Node_Type.Walk);
                //}
                AStartNode node = new AStartNode(i, j, UnityEngine.Random.Range(1, 101) < 20 ? E_Node_Type.Stop : E_Node_Type.Walk);
                nodes[i, j] = node;
            }
        }
    }

    //Ѱ��·���ķ��������ص���·����Ҳ����һ����Node,Ҳ�Ϳ�����һ����Node��List
    //startPos,endPos����յ㡣����ʹ�õ��Ƕ�άƽ�棬����һ����ά��������ˡ�
    public List<AStartNode> FindPath(Vector2 startPos, Vector2 endPos)
    {
        AStartNode start = nodes[(int)startPos.x, (int)startPos.y];
        AStartNode end = nodes[(int)endPos.x, (int)endPos.y];
        //�����ж� �����������  �Ƿ�Ϸ�(ʵ�ʿ�����������������꣬��Ҫ���Ը��ӵĿ�ߣ����ܵõ��ڵڼ���������)
        //1. ����Ҫ�ڵ�ͼ��  
        //2. Ҫ���Ǹ�
        //������Ϸ�  Ӧ��ֱ��  ����null  ��ζ�Ų���Ѱ·
        if (startPos.x >= mapW || startPos.x < 0 ||
            startPos.y >= mapH || startPos.y < 0 ||
            endPos.x   >= mapW || endPos.x   < 0 ||
            endPos.y   >= mapH || endPos.y   < 0 
            )
        {
            Debug.Log("��ʼ���߽������ڵ�ͼ��");
            return null;
        }

        if ((start.type == E_Node_Type.Stop) || (end.type == E_Node_Type.Stop))
        {
            Debug.Log("��ʼ���߽�����Ϊ�赲��");
            return null;
        }

        //��չرպͿ�ʼ�б�  ��Ϊ��Ѱ·�������ε��ã�ÿ�ε���Ҫ����һ�ε��������
        //����Ӱ����һ��
        closeList.Clear();
        openList.Clear();
        //�ѿ�ʼ����뵽�ر��б���
        start.father = null;
        start.g = 0;
        start.h = 0;
        start.f = 0;
        closeList.Add(start);

        while (true)
        {
            //�Ϸ��Ļ�
            //Ӧ�õõ������յ��Ӧ�ĸ���
            //����㿪ʼ  ����Χ�ĵ�  �����뿪���б���
            //��ά�ľͰ˸��� �ſո�����Ϊ�Լ�����Χ�Լ��İ˸��㡣
            //�ж���Щ��  �Ƿ�Ϊ�߽�  �Ƿ�Ϊ�赲  �Ƿ��Ѿ��ڿ����б���߹ر��б�����  ���������  �ŷ��뿪���б�˵����ҲҪ�ж��ǲ����յ㣬�����ж��ˣ�
            //���� x-1, y-1
            FindNearlyNodeToOpenList(start.x - 1, start.y - 1, 1.4f, start, end);
            //�� x, y-1
            FindNearlyNodeToOpenList(start.x, start.y - 1, 1f, start, end);
            //���� x+1, y-1
            FindNearlyNodeToOpenList(start.x + 1, start.y - 1, 1.4f, start, end);
            //�� x-1, y
            FindNearlyNodeToOpenList(start.x - 1, start.y, 1f, start, end);
            //�� x+1, y
            FindNearlyNodeToOpenList(start.x + 1, start.y, 1f, start, end);
            //���� x-1, y+1
            FindNearlyNodeToOpenList(start.x - 1, start.y + 1, 1.4f, start, end);
            //�� x, y+1
            FindNearlyNodeToOpenList(start.x, start.y + 1, 1f, start, end);
            //���� x+1, y+1
            FindNearlyNodeToOpenList(start.x + 1, start.y + 1, 1.4f, start, end);

            //��������б�Ϊ��  ˵��û��·����  ����null
            if (openList.Count == 0)
            {
                Debug.Log("û��·����");
                return null;
            }
            //��Χ�ĵ㶼����֮��
            //ѡ�������б���   Ѱ·������С�ĵ�,����Ҫ����ֱ���ҳ���С�ľ���
            openList.Sort((a, b) => a.f.CompareTo(b.f));
            //�������ر��б���  Ȼ���ٴӿ����б����Ƴ�
            closeList.Add(openList[0]);
            //�ҵ���������ֱ���µ����
            start = openList[0];
            openList.RemoveAt(0);
            //���������Ѿ����յ���   ��ô�õ����ս�����س�ȥ
            if (start == end)
            {
                //������  �ҵ�·����
                List<AStartNode> path = new List<AStartNode>();
                path.Add(end);
                while(end.father != null)
                {
                    path.Add(end.father);
                    end = end.father;
                }

                //��תһ��
                path.Reverse();
                //����·��
                return path;
            }
            //��������  �����յ�   ��ô����Ѱ·
        }
    }
    /// <summary>
    /// �������б�ķ���
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private int SortOpenList(AStartNode a, AStartNode b)
    {
        if (a.f < b.f)
        {
            return -1;
        }
        else if (a.f > b.f)
        {
            return 1;
        }
        return 0;
    }

    private void FindNearlyNodeToOpenList(int x, int y, float g, AStartNode father, AStartNode end)
    {
        //�߽��ж�
        if (x < 0 || x >= mapW ||
           y < 0 || y >= mapH)
        {
            return;
        }
        //�ڷ�Χ�ڣ���ȡ��
        AStartNode node = nodes[x, y];
        //�ж���Щ��  �Ƿ��Ǳ߽�  �Ƿ����赲   �Ƿ��ڿ������߹ر��б�  ���������  �ŷ��뿪���б�
        if (node == null ||
            node.type == E_Node_Type.Stop ||
            closeList.Contains(node) ||
            openList.Contains(node))
        {
            return;
        }
        //���� f ֵ
        //��¼������
        node.father = father;
        //���� g ֵ,ÿһ���ڵ������ľ��룬�����丸�ڵ��gֵ���ϵ�ǰ�ڵ㵽���ڵ�ľ���
        node.g = father.g + g;
        node.h = Mathf.Abs(end.x - node.x) + Mathf.Abs(end.y - node.y);
        node.f = node.g + node.h;
        //���ͨ��������ĺϷ���֤  �ʹ浽�����б���
        openList.Add(node);
    }
}
