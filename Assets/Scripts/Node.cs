using Priority_Queue;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{ 
    private Dictionary<Node, int> _dic;
    public bool isVisited;

    public Dictionary<Node, int> nodeDic
    {
        get
        {
            if (_dic == null)
            {
                _dic = new Dictionary<Node, int>();
            }
            return _dic;
        }
    }
}
