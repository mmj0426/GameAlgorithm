using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Graph : MonoBehaviour
{
    private bool _isRun = false;
    public bool IsRun
    {
        set
        {
            if (value == false)
            {
                ResetNodes();
            }

            _isRun = value;
        }
        get
        {
            return _isRun;
        }
    }

    public List<Node> nodeList;
    public Node startNode;
    public Node endNode;

    public void ResetNodes()
    {
        for(int i = 1; i < nodeList.Count; i ++)
        {
            nodeList[i].isVisited = false;
            nodeList[i].GetComponent<Renderer>().material.color = Color.white;
        }
    }

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

    private void Start()
    {
        startNode = null;
        endNode = null;
    }

    private void Update()
    {
        // 마우스 포지션 값을 게임 월드상의 레이로 변환
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<Node>() == null) { return; }

                if(startNode != null)
                {
                    startNode.GetComponent<Renderer>().material.color = Color.white;
                }

                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                Debug.Log(hit.collider.gameObject.name);
                startNode = hit.collider.gameObject.GetComponent<Node>();
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.GetComponent<Node>() == null) { return; }

                if (endNode != null)
                {
                    endNode.GetComponent<Renderer>().material.color = Color.white;
                }

                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                Debug.Log(hit.collider.gameObject.name);
                endNode = hit.collider.gameObject.GetComponent<Node>();
            }
        }
    }
}

