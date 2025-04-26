using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAstar : MonoBehaviour
{
    //左上角第一个立方体的位置
    public int beginX = -3;
    public int beginY = 5;
    //之后每一个立方体之间的  偏移位置
    public int offsetX = 2;
    public int offsetY = 2;
    //地图的宽高
    public int mapW = 5;
    public int mapH = 5;

    //开始给他一个副的坐标
    private Vector2 beginPos = Vector2.right * -1;

    //存储立方体的字典
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
                //计算每一个立方体的位置
                Vector3 pos = new Vector3(beginX + i * offsetX, beginY - j * offsetY, 0);
                //创建立方体
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //设置立方体的位置
                cube.transform.position = pos;
                //设置立方体的大小
                cube.transform.localScale = new Vector3(1, 1, 1);
                //设置立方体的名字
                cube.name = i + "_" + j;
                //存储立方体到字典中
                cubeDic.Add(cube.name, cube);

                //得到格子判断他是不是阻挡
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
        //如果鼠标左键按下
        if (Input.GetMouseButtonDown(0))
        {
            //进行射线检测
            RaycastHit info;
            //得到屏幕鼠标位置发出去的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //射线检测,第一个参数是射线，第二个参数是射线检测到的物体的信息返回出去，第三个参数是射线的长度
            if ((Physics.Raycast(ray, out info, 1000)))
            {
                
                if(beginPos == Vector2.right * -1)
                {
                    //清除上一次路径  把绿色的立方体设置为白色
                    //如果不为空 说明上一次有路径找成功了
                    if(listNodePath != null)
                    {
                        for (int i = 0; i < listNodePath.Count; i++)
                        {
                            //得到路径上的节点
                            AStartNode node = listNodePath[i];
                            //得到立方体的名字
                            string name = node.x + "_" + node.y;
                            //得到立方体
                            GameObject cube = cubeDic[name];
                            //设置立方体的颜色
                            cube.GetComponent<MeshRenderer>().material = normal;
                            //cubeDic[node.x + "_" + node.y].GetComponent<MeshRenderer>().material = red;
                        }
                    }
                    //得到点击到的立方体，才能知道是第几行第几列
                    string[] strs = info.collider.gameObject.name.Split('_');
                    beginPos = new Vector2(int.Parse(strs[0]), int.Parse(strs[1]));
                    //设置立方体的颜色
                    info.collider.gameObject.GetComponent<MeshRenderer>().material = yellow;
                }
                else
                {
                    //得到点击到的立方体，才能知道是第几行第几列
                    string[] strs = info.collider.gameObject.name.Split('_');
                    //设置终点
                    Vector2 endPos = new Vector2(int.Parse(strs[0]), int.Parse(strs[1]));
                    //设置立方体的颜色
                    info.collider.gameObject.GetComponent<MeshRenderer>().material = yellow;
                    //开始寻路
                    listNodePath = AStartMgr.Instance.FindPath(beginPos, endPos);
                    //如果不为空，说明找到了路径
                    if (listNodePath != null)
                    {
                        for(int i = 0; i < listNodePath.Count; i++)
                        {
                            //得到路径上的节点
                            AStartNode node = listNodePath[i];
                            //得到立方体的名字
                            string name = node.x + "_" + node.y;
                            //得到立方体
                            GameObject cube = cubeDic[name];
                            //设置立方体的颜色
                            cube.GetComponent<MeshRenderer>().material = green;
                        }
                    }
                    //方便测试，测试完清除
                    //把他设置为初始值
                    beginPos = Vector2.right * -1;
                }
               
            }
        }
    }
}
