using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public AstarGraph graph;
    public Astar pov_dijkstra;
    public GameObject leaderCube;


    public Node endNode;
    public Node startNode;

    private Vector3 startPos;
    private float distance;

    private float maxSpeed = 0.5f;

    public int targetNode;
    [SerializeField]
    private float decelerationTweaker = 0.3f;
    public bool is_pop;

    public Vector3 velocity = Vector3.zero;

    public Queue<int> targetNode_queue;

    private void Awake()
    {
        is_pop = false;

        graph.Init();
    }


    private void Start()
    {
        startPos = leaderCube.transform.position;
        distance = float.MaxValue;
        targetNode_queue = new Queue<int>();


        pov_dijkstra = GetComponent<Astar>();
    }
    // Update is called once per frame
    void Update()
    {

    }


    public void onClick()
    {
        float _distance = float.MaxValue;
        foreach (var v in graph.nodeList)
        {
            float currentDistance = Vector3.Distance(v.transform.position, startPos);
            if (currentDistance < distance)
            {
                distance = currentDistance;
                startNode = v;
            }
        }

        Debug.Log("FSM StartNode : " + startNode);

        foreach (var v in graph.nodeList)
        {
            float currentDistance = Vector3.Distance(v.transform.position, graph.targetPos);
            if (currentDistance < _distance)
            {
                _distance = currentDistance;
                endNode = v;
            }
        }

        Debug.Log("FSM EndNode : " + endNode);

        targetNode = Convert.ToInt32(startNode.name);
        pov_dijkstra.startNode = startNode;
        pov_dijkstra.endNode = endNode;

        pov_dijkstra.ActiveDijkstra();

        //StartNode로 Seek
        StartCoroutine(Seeking());



    }

    private Vector3 Seek()
    {
        Vector3 desired_velocity = ((startNode.transform.position - leaderCube.transform.position).normalized) * maxSpeed;

        desired_velocity.y = 0.0f;

        return (desired_velocity - velocity);
    }

    public bool canfollow;
    public IEnumerator Seeking()
    {
        while (true)
        {
            if (targetNode == Convert.ToInt32(startNode.name.ToString()))
            {
                velocity = velocity + (Seek() * Time.deltaTime);

                leaderCube.transform.position = leaderCube.transform.position + velocity;
                targetNode_queue.Enqueue(targetNode);
                
            }
            else
            {
                leaderCube.transform.position = Vector3.MoveTowards(leaderCube.transform.position, GameObject.Find(targetNode.ToString()).transform.position, maxSpeed);
            }


            if (Vector3.Distance(GameObject.Find(targetNode.ToString()).transform.position, leaderCube.transform.position) < 20f && targetNode.ToString() != endNode.name.ToString())
            {
                Debug.Log("TargetNode : " + targetNode);
                targetNode_queue.Enqueue(targetNode);
                is_pop = true;
                canfollow = true;
                yield return null;
                targetNode = pov_dijkstra.pathNode;
            }

            is_pop = false;

            if (Vector3.Distance(endNode.transform.position, leaderCube.transform.position) < 30f)
            {
                targetNode_queue.Enqueue(Convert.ToInt32(endNode.name));
                StartCoroutine(Arriving());
            }
            yield return null;
        }
    }

    private Vector3 Arrive()
    {
        Vector3 desired_velocity = graph.targetPos - leaderCube.transform.position;

        float distance = desired_velocity.magnitude;

        if (distance > 0f)
        {
            float speed = distance / (0.3f * decelerationTweaker);

            speed = Mathf.Min(speed, maxSpeed);

            desired_velocity.y = 0.0f;
            desired_velocity *= speed / distance;


            return (desired_velocity - velocity);
        }

        return Vector3.zero;
    }

    public IEnumerator Arriving()
    {
        while (true)
        {
            velocity = velocity + (Arrive() * Time.deltaTime);

            // 속도를 기반으로 새로운 위치 계산.
            leaderCube.transform.position = leaderCube.transform.position + velocity;
            yield return null;
        }
    }
}
