using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AStart寻路管理器  单例模式
/// </summary>
public class AStartMgr 
{
    //地图相关的所有的格子对象容器
    public AStartNode[,] nodes;
    //开启列表,就得用new初始化。
    private List<AStartNode> openList = new List<AStartNode>();
    //关闭列表
    private List<AStartNode> closeList = new List<AStartNode>();

    //地图宽高
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

    //初始化地图格子的方法
    public void InitMapInfo(int w, int h)
    {
        //记录宽高
        mapH = h;
        mapW = w;

        //声明容器可以装多少个格子
        nodes = new AStartNode[w, h];
        //根据宽高  创建格子  阻挡的问题  先随机
        //因为现在没有地图相关的数据

        //声明格子   装进去
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                //这里的随机阻挡  只是为了给大家讲逻辑所以这样写
                //以后真正的项目中  这些阻挡信息应该是从地图配置文件中读取出来  不应该是随机的
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

    //寻找路径的方法，返回的是路径，也就是一个个Node,也就可以是一个存Node的List
    //startPos,endPos起点终点。这里使用的是二维平面，所以一个二维坐标就行了。
    public List<AStartNode> FindPath(Vector2 startPos, Vector2 endPos)
    {
        AStartNode start = nodes[(int)startPos.x, (int)startPos.y];
        AStartNode end = nodes[(int)endPos.x, (int)endPos.y];
        //首先判断 传入的两个点  是否合法(实际开发传入的是世界坐标，需要除以格子的宽高，才能得到在第几个格子里)
        //1. 首先要在地图内  
        //2. 要不是格挡
        //如果不合法  应该直接  返回null  意味着不能寻路
        if (startPos.x >= mapW || startPos.x < 0 ||
            startPos.y >= mapH || startPos.y < 0 ||
            endPos.x   >= mapW || endPos.x   < 0 ||
            endPos.y   >= mapH || endPos.y   < 0 
            )
        {
            Debug.Log("开始或者结束点在地图外");
            return null;
        }

        if ((start.type == E_Node_Type.Stop) || (end.type == E_Node_Type.Stop))
        {
            Debug.Log("开始或者结束点为阻挡点");
            return null;
        }

        //清空关闭和开始列表  因为该寻路函数会多次调用，每次调用要将上一次的数据清除
        //避免影响这一次
        closeList.Clear();
        openList.Clear();
        //把开始点放入到关闭列表当中
        start.father = null;
        start.g = 0;
        start.h = 0;
        start.f = 0;
        closeList.Add(start);

        while (true)
        {
            //合法的话
            //应该得到起点和终点对应的格子
            //从起点开始  找周围的点  并放入开启列表中
            //二维的就八个点 九空格中心为自己，包围自己的八个点。
            //判断这些点  是否为边界  是否为阻挡  是否已经在开启列表或者关闭列表当中了  如果都不是  才放入开启列表（说不定也要判断是不是终点，下面判断了）
            //左上 x-1, y-1
            FindNearlyNodeToOpenList(start.x - 1, start.y - 1, 1.4f, start, end);
            //上 x, y-1
            FindNearlyNodeToOpenList(start.x, start.y - 1, 1f, start, end);
            //右上 x+1, y-1
            FindNearlyNodeToOpenList(start.x + 1, start.y - 1, 1.4f, start, end);
            //左 x-1, y
            FindNearlyNodeToOpenList(start.x - 1, start.y, 1f, start, end);
            //右 x+1, y
            FindNearlyNodeToOpenList(start.x + 1, start.y, 1f, start, end);
            //左下 x-1, y+1
            FindNearlyNodeToOpenList(start.x - 1, start.y + 1, 1.4f, start, end);
            //下 x, y+1
            FindNearlyNodeToOpenList(start.x, start.y + 1, 1f, start, end);
            //右下 x+1, y+1
            FindNearlyNodeToOpenList(start.x + 1, start.y + 1, 1.4f, start, end);

            //如果开启列表为空  说明没有路径了  返回null
            if (openList.Count == 0)
            {
                Debug.Log("没有路径了");
                return null;
            }
            //周围的点都做完之后
            //选出开启列表中   寻路消耗最小的点,不需要排序直接找出最小的就行
            openList.Sort((a, b) => a.f.CompareTo(b.f));
            //将其放入关闭列表中  然后再从开启列表中移除
            closeList.Add(openList[0]);
            //找到的这个点又变成新的起点
            start = openList[0];
            openList.RemoveAt(0);
            //如果这个点已经是终点了   那么得到最终结果返回出去
            if (start == end)
            {
                //找完了  找到路径了
                List<AStartNode> path = new List<AStartNode>();
                path.Add(end);
                while(end.father != null)
                {
                    path.Add(end.father);
                    end = end.father;
                }

                //反转一下
                path.Reverse();
                //返回路径
                return path;
            }
            //如果这个点  不是终点   那么继续寻路
        }
    }
    /// <summary>
    /// 排序开启列表的方法
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
        //边界判断
        if (x < 0 || x >= mapW ||
           y < 0 || y >= mapH)
        {
            return;
        }
        //在范围内，再取点
        AStartNode node = nodes[x, y];
        //判断这些点  是否是边界  是否是阻挡   是否在开启或者关闭列表  如果都不是  才放入开启列表
        if (node == null ||
            node.type == E_Node_Type.Stop ||
            closeList.Contains(node) ||
            openList.Contains(node))
        {
            return;
        }
        //计算 f 值
        //记录父对象
        node.father = father;
        //计算 g 值,每一个节点离起点的距离，等于其父节点的g值加上当前节点到父节点的距离
        node.g = father.g + g;
        node.h = Mathf.Abs(end.x - node.x) + Mathf.Abs(end.y - node.y);
        node.f = node.g + node.h;
        //如果通过了上面的合法验证  就存到开启列表当中
        openList.Add(node);
    }
}
