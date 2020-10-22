using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Transactions;
using UnityEditorInternal;
using UnityEngine;

public class DFS : MonoBehaviour
{
    public UnityEngine.UI.Text pathText;

    private string path;

    public Graph graph;

    private Node startNode;
    private Node endNode;

    private void Start()
    {
        path = "DFS : ";
    }

    public void onClick()
    {
        if (graph.IsRun) { return; }

        graph.IsRun = true;

        startNode = graph.startNode;
        endNode = graph.endNode;
        Debug.Log("DFS - Start : " + startNode + " End : " + endNode);

        //StartCoroutine("Active", startNode);

        path = "DFS : ";

        Active(startNode);

        Invoke("Off", 1f);

        pathText.text = path;
    }
    private void Active(Node _node)
    {
        _node.isVisited = true;

        Debug.Log("DFS : " + _node);
        path = path + _node.name + "    ";

        int current = Convert.ToInt32(_node.name);

        foreach (var v in graph.nodeList[current].nodeDic)
        {
            if (!v.Key.isVisited)
            {
                Active(v.Key);
            }
        }
    }

    private void Off()
    {
        graph.IsRun = false;
    }
}