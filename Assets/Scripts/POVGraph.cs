using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POVGraph : MonoBehaviour
{
    public Vector3 targetPos = Vector3.zero;

    public List<Node> nodeList;
    public Node startNode;
    public Node endNode;

    public void ResetNodes()
    {
        for (int i = 1; i < nodeList.Count; i++)
        {
            nodeList[i].isVisited = false;
            nodeList[i].GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void Init()
    {
        nodeList[1].nodeDic[nodeList[2]] = Vector3.Distance(nodeList[1].transform.position, nodeList[2].transform.position);
        nodeList[1].nodeDic[nodeList[3]] = Vector3.Distance(nodeList[1].transform.position, nodeList[3].transform.position);
        nodeList[1].nodeDic[nodeList[4]] = Vector3.Distance(nodeList[1].transform.position, nodeList[4].transform.position);

        nodeList[2].nodeDic[nodeList[1]] = Vector3.Distance(nodeList[2].transform.position, nodeList[1].transform.position);
        nodeList[2].nodeDic[nodeList[3]] = Vector3.Distance(nodeList[2].transform.position, nodeList[3].transform.position);
        nodeList[2].nodeDic[nodeList[5]] = Vector3.Distance(nodeList[2].transform.position, nodeList[5].transform.position);

        nodeList[3].nodeDic[nodeList[1]] = Vector3.Distance(nodeList[3].transform.position, nodeList[1].transform.position);
        nodeList[3].nodeDic[nodeList[2]] = Vector3.Distance(nodeList[3].transform.position, nodeList[2].transform.position);
        nodeList[3].nodeDic[nodeList[6]] = Vector3.Distance(nodeList[3].transform.position, nodeList[6].transform.position);

        nodeList[4].nodeDic[nodeList[1]] = Vector3.Distance(nodeList[4].transform.position, nodeList[1].transform.position);
        nodeList[4].nodeDic[nodeList[7]] = Vector3.Distance(nodeList[4].transform.position, nodeList[7].transform.position);
        nodeList[4].nodeDic[nodeList[11]] = Vector3.Distance(nodeList[4].transform.position, nodeList[11].transform.position);

        nodeList[5].nodeDic[nodeList[2]] = Vector3.Distance(nodeList[5].transform.position, nodeList[2].transform.position);
        nodeList[5].nodeDic[nodeList[8]] = Vector3.Distance(nodeList[5].transform.position, nodeList[8].transform.position);
        nodeList[5].nodeDic[nodeList[14]] = Vector3.Distance(nodeList[5].transform.position, nodeList[14].transform.position);

        nodeList[6].nodeDic[nodeList[3]] = Vector3.Distance(nodeList[6].transform.position, nodeList[3].transform.position);
        nodeList[6].nodeDic[nodeList[8]] = Vector3.Distance(nodeList[6].transform.position, nodeList[8].transform.position);
        nodeList[6].nodeDic[nodeList[9]] = Vector3.Distance(nodeList[6].transform.position, nodeList[9].transform.position);

        nodeList[7].nodeDic[nodeList[4]] = Vector3.Distance(nodeList[7].transform.position, nodeList[4].transform.position);
        nodeList[7].nodeDic[nodeList[9]] = Vector3.Distance(nodeList[7].transform.position, nodeList[9].transform.position);

        nodeList[8].nodeDic[nodeList[5]] = Vector3.Distance(nodeList[8].transform.position, nodeList[5].transform.position);
        nodeList[8].nodeDic[nodeList[6]] = Vector3.Distance(nodeList[8].transform.position, nodeList[6].transform.position);
        nodeList[8].nodeDic[nodeList[15]] = Vector3.Distance(nodeList[8].transform.position, nodeList[15].transform.position);

        nodeList[9].nodeDic[nodeList[6]] = Vector3.Distance(nodeList[9].transform.position, nodeList[6].transform.position);
        nodeList[9].nodeDic[nodeList[7]] = Vector3.Distance(nodeList[9].transform.position, nodeList[7].transform.position);
        nodeList[9].nodeDic[nodeList[12]] = Vector3.Distance(nodeList[9].transform.position, nodeList[12].transform.position);

        nodeList[10].nodeDic[nodeList[7]] = Vector3.Distance(nodeList[10].transform.position, nodeList[7].transform.position);
        nodeList[10].nodeDic[nodeList[13]] = Vector3.Distance(nodeList[10].transform.position, nodeList[13].transform.position);
        nodeList[10].nodeDic[nodeList[19]] = Vector3.Distance(nodeList[10].transform.position, nodeList[19].transform.position);

        nodeList[11].nodeDic[nodeList[4]] = Vector3.Distance(nodeList[11].transform.position, nodeList[4].transform.position);
        nodeList[11].nodeDic[nodeList[13]] = Vector3.Distance(nodeList[11].transform.position, nodeList[13].transform.position);

        nodeList[12].nodeDic[nodeList[9]] = Vector3.Distance(nodeList[12].transform.position, nodeList[9].transform.position);
        nodeList[12].nodeDic[nodeList[15]] = Vector3.Distance(nodeList[12].transform.position, nodeList[15].transform.position);

        nodeList[13].nodeDic[nodeList[11]] = Vector3.Distance(nodeList[13].transform.position, nodeList[11].transform.position);
        nodeList[13].nodeDic[nodeList[23]] = Vector3.Distance(nodeList[13].transform.position, nodeList[23].transform.position);

        nodeList[14].nodeDic[nodeList[5]] = Vector3.Distance(nodeList[14].transform.position, nodeList[5].transform.position);
        nodeList[14].nodeDic[nodeList[16]] = Vector3.Distance(nodeList[14].transform.position, nodeList[16].transform.position);
        nodeList[14].nodeDic[nodeList[17]] = Vector3.Distance(nodeList[14].transform.position, nodeList[17].transform.position);

        nodeList[15].nodeDic[nodeList[8]] = Vector3.Distance(nodeList[15].transform.position, nodeList[8].transform.position);
        nodeList[15].nodeDic[nodeList[12]] = Vector3.Distance(nodeList[15].transform.position, nodeList[12].transform.position);
        nodeList[15].nodeDic[nodeList[18]] = Vector3.Distance(nodeList[15].transform.position, nodeList[18].transform.position);
        nodeList[15].nodeDic[nodeList[19]] = Vector3.Distance(nodeList[15].transform.position, nodeList[19].transform.position);

        nodeList[16].nodeDic[nodeList[14]] = Vector3.Distance(nodeList[16].transform.position, nodeList[14].transform.position);
        nodeList[16].nodeDic[nodeList[27]] = Vector3.Distance(nodeList[16].transform.position, nodeList[27].transform.position);

        nodeList[17].nodeDic[nodeList[14]] = Vector3.Distance(nodeList[17].transform.position, nodeList[14].transform.position);
        nodeList[17].nodeDic[nodeList[18]] = Vector3.Distance(nodeList[17].transform.position, nodeList[18].transform.position);
        nodeList[17].nodeDic[nodeList[20]] =Vector3.Distance(nodeList[17].transform.position, nodeList[20].transform.position);
        nodeList[17].nodeDic[nodeList[22]] = Vector3.Distance(nodeList[17].transform.position, nodeList[22].transform.position);
        nodeList[17].nodeDic[nodeList[27]] = Vector3.Distance(nodeList[17].transform.position, nodeList[27].transform.position);

        nodeList[18].nodeDic[nodeList[15]] = Vector3.Distance(nodeList[18].transform.position, nodeList[15].transform.position);
        nodeList[18].nodeDic[nodeList[17]] = Vector3.Distance(nodeList[18].transform.position, nodeList[17].transform.position);
        nodeList[18].nodeDic[nodeList[20]] =Vector3.Distance(nodeList[18].transform.position, nodeList[20].transform.position);
        nodeList[18].nodeDic[nodeList[21]] = Vector3.Distance(nodeList[18].transform.position, nodeList[21].transform.position);

        nodeList[19].nodeDic[nodeList[10]] = Vector3.Distance(nodeList[19].transform.position, nodeList[10].transform.position);
        nodeList[19].nodeDic[nodeList[15]] = Vector3.Distance(nodeList[19].transform.position, nodeList[15].transform.position);
        nodeList[19].nodeDic[nodeList[21]] = Vector3.Distance(nodeList[19].transform.position, nodeList[21].transform.position);

        nodeList[20].nodeDic[nodeList[17]] = Vector3.Distance(nodeList[20].transform.position, nodeList[17].transform.position);
        nodeList[20].nodeDic[nodeList[18]] = Vector3.Distance(nodeList[20].transform.position, nodeList[18].transform.position);
        nodeList[20].nodeDic[nodeList[24]] =Vector3.Distance(nodeList[20].transform.position, nodeList[24].transform.position);

        nodeList[21].nodeDic[nodeList[18]] = Vector3.Distance(nodeList[21].transform.position, nodeList[18].transform.position);
        nodeList[21].nodeDic[nodeList[19]] = Vector3.Distance(nodeList[21].transform.position, nodeList[19].transform.position);
        nodeList[21].nodeDic[nodeList[23]] =Vector3.Distance(nodeList[21].transform.position, nodeList[23].transform.position);
        nodeList[21].nodeDic[nodeList[25]] = Vector3.Distance(nodeList[21].transform.position, nodeList[25].transform.position);

        nodeList[22].nodeDic[nodeList[17]] = Vector3.Distance(nodeList[22].transform.position, nodeList[17].transform.position);
        nodeList[22].nodeDic[nodeList[24]] =Vector3.Distance(nodeList[22].transform.position, nodeList[24].transform.position);
        nodeList[22].nodeDic[nodeList[27]] =Vector3.Distance(nodeList[22].transform.position, nodeList[27].transform.position);

        nodeList[23].nodeDic[nodeList[13]] = Vector3.Distance(nodeList[23].transform.position, nodeList[13].transform.position);
        nodeList[23].nodeDic[nodeList[21]] = Vector3.Distance(nodeList[23].transform.position, nodeList[21].transform.position);
        nodeList[23].nodeDic[nodeList[26]] =Vector3.Distance(nodeList[23].transform.position, nodeList[26].transform.position);

        nodeList[24].nodeDic[nodeList[20]] = Vector3.Distance(nodeList[24].transform.position, nodeList[20].transform.position);
        nodeList[24].nodeDic[nodeList[22]] = Vector3.Distance(nodeList[24].transform.position, nodeList[22].transform.position);
        nodeList[24].nodeDic[nodeList[25]] = Vector3.Distance(nodeList[24].transform.position, nodeList[25].transform.position);

        nodeList[25].nodeDic[nodeList[21]] = Vector3.Distance(nodeList[25].transform.position, nodeList[21].transform.position);
        nodeList[25].nodeDic[nodeList[24]] =Vector3.Distance(nodeList[25].transform.position, nodeList[24].transform.position);
        nodeList[25].nodeDic[nodeList[26]] =Vector3.Distance(nodeList[25].transform.position, nodeList[26].transform.position);

        nodeList[26].nodeDic[nodeList[23]] = Vector3.Distance(nodeList[26].transform.position, nodeList[23].transform.position);
        nodeList[26].nodeDic[nodeList[25]] = Vector3.Distance(nodeList[26].transform.position, nodeList[25].transform.position);

        nodeList[27].nodeDic[nodeList[16]] = Vector3.Distance(nodeList[27].transform.position, nodeList[16].transform.position);
        nodeList[27].nodeDic[nodeList[17]] = Vector3.Distance(nodeList[27].transform.position, nodeList[17].transform.position);
        nodeList[27].nodeDic[nodeList[22]] =Vector3.Distance(nodeList[27].transform.position, nodeList[22].transform.position);


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

        //목적지 좌표 설정
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000))
            {
                targetPos = hit.point;
            }
        }

        Debug.Log("TargetPos : " + targetPos);
    }
}
