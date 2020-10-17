using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public List<Node> nodeList;
    public void Init()
    {
        nodeList[1].nodeDic[nodeList[2]] = 2;
        nodeList[1].nodeDic[nodeList[3]] = 5;
        nodeList[1].nodeDic[nodeList[4]] = 1;

        nodeList[2].nodeDic[nodeList[1]] = 2;
        nodeList[2].nodeDic[nodeList[3]] = 3;
        nodeList[2].nodeDic[nodeList[4]] = 2;

        nodeList[3].nodeDic[nodeList[1]] = 5;
        nodeList[3].nodeDic[nodeList[2]] = 3;
        nodeList[3].nodeDic[nodeList[4]] = 3;
        nodeList[3].nodeDic[nodeList[5]] = 1;
        nodeList[3].nodeDic[nodeList[6]] = 5;

        nodeList[4].nodeDic[nodeList[1]] = 1;
        nodeList[4].nodeDic[nodeList[2]] = 2;
        nodeList[4].nodeDic[nodeList[3]] = 3;
        nodeList[4].nodeDic[nodeList[5]] = 1;

        nodeList[5].nodeDic[nodeList[3]] = 1;
        nodeList[5].nodeDic[nodeList[4]] = 1;
        nodeList[5].nodeDic[nodeList[6]] = 2;

        nodeList[6].nodeDic[nodeList[3]] = 5;
        nodeList[6].nodeDic[nodeList[5]] = 2;

    }
}

