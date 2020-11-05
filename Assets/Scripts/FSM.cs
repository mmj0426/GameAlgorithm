using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public POVGraph graph;
    public POV pov_dijkstra;
    public GameObject cube;

    private Node startNode;
    private Node endNode;

    private Vector3 startPos;
    private float distance;

    private float maxSpeed = 0.5f;

    public int targetNode;
    [SerializeField]
    private float decelerationTweaker = 0.3f;
    public bool is_pop;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        is_pop = false;

        graph.Init();
    }


    private void Start()
    {
        startPos = cube.transform.position;
        distance = float.MaxValue;


        pov_dijkstra = GetComponent<POV>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    
    public void onClick()
    {
        float _distance = float.MaxValue;
        foreach(var v in graph.nodeList)
        {
            float currentDistance = Vector3.Distance(v.transform.position, startPos);
            if(currentDistance < distance)
            {
                distance = currentDistance;
                startNode = v;
            }
        }

        Debug.Log("FSM StartNode : " + startNode);

        foreach(var v in graph.nodeList)
        {
            Debug.Log("FSM foreach : ");
            float currentDistance = Vector3.Distance(v.transform.position, graph.targetPos);
            if(currentDistance < _distance)
            {
                _distance = currentDistance;
                endNode = v;
                Debug.Log("FSM endNode : " + endNode);
            }
        }

        Debug.Log("FSM EndNode : " + endNode);

        targetNode = Convert.ToInt32(startNode.name);
        pov_dijkstra.startNode = startNode;
        pov_dijkstra.endNode = endNode;

        pov_dijkstra.ActiveDijkstra();

        //StartNode로 Seek
        StartCoroutine(Seeking());

        //Dijkstra로 이동

        //EndNode -> pickPos(targetPos)로 이동

    }

    private Vector3 Seek()
    {
        Vector3 desired_velocity = ((startNode.transform.position - cube.transform.position).normalized) * maxSpeed;

        desired_velocity.y = 0.0f;

        return (desired_velocity - velocity);
    }

    private Vector3 Arrive()
    {
        Vector3 desired_velocity = graph.targetPos - cube.transform.position;

        float distance = desired_velocity.magnitude;

        if (distance > 0f)
        {
            float speed = distance / (0.3f * decelerationTweaker);

            // speed가 반환되면 distance가 작아진다는 의미니까 speed가 점점 줄어들어서 멈추고
            // MaxVelocity가 반환되면 Seek()랑 똑같은거 같아요..
            speed = Mathf.Min(speed, maxSpeed);

            desired_velocity.y = 0.0f;
            desired_velocity *= speed / distance;


            return (desired_velocity - velocity);
        }

        return Vector3.zero;
    }

    public IEnumerator Arriving()
    {
        // 조건문 바꿔야하는데 어케 넣어야할지 모르겠음
        while(true)
        {
            velocity = velocity + (Arrive() * Time.deltaTime);

            // 속도를 기반으로 새로운 위치 계산.
            cube.transform.position = cube.transform.position + velocity;
            yield return null;
        }
    }

    public IEnumerator Seeking()
    {
        while(true)
        {
            if (targetNode == Convert.ToInt32(startNode.name.ToString()))
            {
                velocity = velocity + (Seek() * Time.deltaTime);

                cube.transform.position = cube.transform.position + velocity;
            }
            else
            {
                cube.transform.position = Vector3.MoveTowards(cube.transform.position, GameObject.Find(targetNode.ToString()).transform.position, maxSpeed);
            }


            if (Vector3.Distance(GameObject.Find(targetNode.ToString()).transform.position, cube.transform.position) < 20f)
            {
                if(targetNode.ToString() != endNode.name.ToString())
                {
                    Debug.Log("TargetNode : " + targetNode);
                    is_pop = true;
                    yield return null;
                    targetNode = pov_dijkstra.pathNode;
                }


                is_pop = false;

            }

            if(Vector3.Distance(endNode.transform.position, cube.transform.position) < 3f)
            {
                StartCoroutine(Arriving());
            }
            yield return null;

        }      
    }
}
