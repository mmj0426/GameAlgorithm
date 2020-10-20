using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BFS : MonoBehaviour
{
    public Graph graph;
    private Queue<Node> nodeQueue;

    private Node startNode;
    private Node endNode;

    // Start is called before the first frame update
    void Start()
    {
        nodeQueue = new Queue<Node>();
    }

    public void onClick()
    {
        if (graph.IsRun) { return; }

        nodeQueue.Clear();

        graph.IsRun = true;

        startNode = graph.startNode;
        endNode = graph.endNode;

        startNode.isVisited = true;

        nodeQueue.Enqueue(startNode);

        Debug.Log("BFS 클릭 -> Start : " + startNode.name + " End : " + endNode.name);

        StartCoroutine(Active());
    }
    private IEnumerator Active()
    {
        while (nodeQueue.Count != 0)
        {
            Node rootNode = nodeQueue.First();
            int current = Convert.ToInt32(rootNode.name);

            Debug.Log("BFS : " + rootNode);

            if (endNode == rootNode)
            {
                endNode.GetComponent<Renderer>().material.color = Color.blue;
                break;
            }

            nodeQueue.Dequeue();
            foreach (var v in graph.nodeList[current].nodeDic)
            {
                if(!v.Key.isVisited)
                {
                    v.Key.isVisited = true;
                    nodeQueue.Enqueue(graph.nodeList[Convert.ToInt32(v.Key.name)]);
                    v.Key.GetComponent<Renderer>().material.color = Color.green;

                    yield return new WaitForSeconds(1f);
                }
            }
        yield return null;
        }

        yield return new WaitForSeconds(1f);

        graph.IsRun = false;
    }
}
