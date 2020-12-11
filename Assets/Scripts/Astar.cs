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

public class Astar : MonoBehaviour
{
    public UnityEngine.UI.Text costText;

    public AstarGraph graph;
    public FSM fsm;
    public Node startNode;
    public Node endNode;

    //private FastPriorityQueue<Node> priority_queue;
    private SimplePriorityQueue<Dictionary<Node, float>> priority_queue;

    private float[] d = new float[30];

    //private List<int> path;

    public Stack<int> path;
    private int[] p = new int[30];

    public bool alreadyPush = false;

    int start;
    int end;
    int current;
    float distance;

    float heuristic;

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
        priority_queue = new SimplePriorityQueue<Dictionary<Node, float>>();
        fsm = GetComponent<FSM>();

        for (int i = 1; i < 30; i++)
        {
            d[i] = float.MaxValue;
        }
    }

    public void ActiveDijkstra()
    {
        start = Convert.ToInt32(startNode.name);
        end = Convert.ToInt32(endNode.name);

        Debug.Log("Start : " + start + "End : " + end);

        d[start] = 0;

        priority_queue.Enqueue(Make_pair(startNode, 0f), 0f);

        StartCoroutine(Active());
    }

    public void onClick()
    {
        startNode = graph.startNode;
        endNode = graph.endNode;

        ActiveDijkstra();
    }

    private IEnumerator Active()
    {
        while (priority_queue.Count != 0)
        {
            Dictionary<Node, float> dic = priority_queue.First;

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
                heuristic = Vector3.Distance(GameObject.Find(v.Key.name.ToString()).transform.position, endNode.transform.position);

                int next = Convert.ToInt32(v.Key.name);

                float nextDistance = distance + v.Value + heuristic;

                if (nextDistance < d[next])
                {
                    d[next] = nextDistance + heuristic;
                    priority_queue.Enqueue(Make_pair(graph.nodeList[next], -nextDistance), -nextDistance);
                    p[next] = current;
                }
            }
            yield return null;
        }

        StartCoroutine(DrawPath());
    }

    public int pathNode;


    public IEnumerator DrawPath()
    {
        path.Push(end);

        for (int i = p[end]; i != 0;)
        {
            path.Push(i);

            i = p[i];

        }

        while (path.Count != 0)
        {
            Debug.Log(path.First());
            if (path.First() != start || path.First() != end)
            {
                GameObject.Find(path.First().ToString()).GetComponent<Renderer>().material.color = Color.green;
  
                yield return null;
            }

            pathNode = path.Pop();
            yield return new WaitUntil(() => fsm.is_pop == true);
        }

        
    }
}
