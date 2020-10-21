using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Transactions;
using UnityEditorInternal;
using UnityEngine;

public class DFS : MonoBehaviour
{
    public Graph graph;

    private Node startNode;
    private Node endNode;


    public void onClick()
    {
        if (graph.IsRun) { return; }

        graph.IsRun = true;

        startNode = graph.startNode;
        endNode = graph.endNode;
        Debug.Log("DFS - Start : " + startNode + " End : " + endNode);

        //StartCoroutine("Active", startNode);

        Active(startNode);

        //graph.IsRun = false;
    }

    private void Active(Node _node)
    {
        _node.isVisited = true;

        Debug.Log("DFS : " + _node);

        _node.GetComponent<Renderer>().material.color = Color.green;

        int current = Convert.ToInt32(_node.name);

        if (endNode == _node)
        {
            _node.GetComponent<Renderer>().material.color = Color.blue;
            
        }

        foreach (var v in graph.nodeList[current].nodeDic)
        {
            if (!v.Key.isVisited)
            {
                Active(v.Key);
            }
        }
        
    }
}