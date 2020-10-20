using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;
using System;
using System.Collections;
using System.Runtime.ExceptionServices;
using System.Xml;
using UnityEditor;
using System.Linq;
using UnityEngine.UIElements;
using System.Net.Http.Headers;

public class Dijkstra : MonoBehaviour
{
    public UnityEngine.UI.Text costText;

    public Graph graph;
    private Node startNode;
    private Node endNode;

    //private FastPriorityQueue<Node> priority_queue;
    private SimplePriorityQueue<Dictionary<Node, int>> priority_queue;

    private int[] d = new int[7];

    //private List<int> path;

    private Stack<int> path;
    private int[] p = new int[7];

    public bool alreadyPush = false;

    int start;
    int end;
    int current;
    int distance;

    bool IsFinished { get; set; }

    private Dictionary<TKey, TValue> Make_pair<TKey, TValue>(TKey key, TValue value)
    {
        var dic = new Dictionary<TKey, TValue>();
        dic.Add(key, value);

        return dic;
    }

    private void Awake()
    {
        graph.Init();
    }

    void Start()
    {
        path = new Stack<int>();
        priority_queue = new SimplePriorityQueue<Dictionary<Node, int>>();

        for (int i = 1; i < 7; i++)
        {
            d[i] = int.MaxValue;
        }

        IsFinished = false;
    }


    public void onClick()
    {
        if(IsFinished) { return; }

        IsFinished = true;

        startNode = graph.startNode;
        endNode = graph.endNode;

        start = Convert.ToInt32(startNode.name);
        end = Convert.ToInt32(endNode.name);

        Debug.Log("Start : " + start + "End : " + end);

        d[start] = 0;

        priority_queue.Enqueue(Make_pair(startNode, 0), 0);

        StartCoroutine(Active());
    }

    private IEnumerator Active()
    {
        while(priority_queue.Count != 0)
        {
            Dictionary<Node, int> dic = priority_queue.First;
            
            foreach (var v in dic)
            {
                current = Convert.ToInt32(v.Key.name);
                distance = -v.Value;
                break;
            }

            priority_queue.Dequeue();

            if (d[current] < distance) continue;

            foreach (var v in graph.nodeList[current].nodeDic)
            {
                int next = Convert.ToInt32(v.Key.name);

                int nextDistance = distance + v.Value;

                if(nextDistance < d[next])
                {
                    d[next] = nextDistance;
                    priority_queue.Enqueue(Make_pair(graph.nodeList[next], -nextDistance), -nextDistance);
                    p[next] = current;
                }
            }
            yield return null;
        }
        DrawPath();
        IsFinished = false;
    }

    public void DrawPath()
    {
        path.Push(end);

        for(int i = p[end]; i != 0;)
        {
            path.Push(i);

            i = p[i];
            
        }

        while (path.Count !=0)
        {
            Debug.Log(path.First());
            if (path.First() != start && path.First() != end)
            {
                GameObject.Find(path.First().ToString()).GetComponent<Renderer>().material.color = Color.green;
            }
                path.Pop();
        }
        costText.text = "Cost : " + d[end].ToString();
        Debug.Log("DIJKSTRA 비용 : " + d[end]);
    }
}
