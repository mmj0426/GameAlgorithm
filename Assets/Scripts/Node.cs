using Priority_Queue;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{ 
    private Dictionary<Node, float> _dic;
    public bool isVisited;

    public Dictionary<Node, float> nodeDic
    {
        get
        {
            if (_dic == null)
            {
                _dic = new Dictionary<Node, float>();
            }
            return _dic;
        }
    }
}
