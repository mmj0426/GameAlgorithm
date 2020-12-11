using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMove : MonoBehaviour
{
    public GameObject Leader;
    public FSM fsm;

    [SerializeField]
    public float maxSpeed = 0.1f;

    public Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fsm.canfollow == true)
        {
            StartCoroutine(MoveToPath());
        }
    }

    public IEnumerator MoveToPath()
    {
        
        while (fsm.targetNode_queue.Count != 0)
        {
            Debug.Log("Peek : " + fsm.targetNode_queue.Peek().ToString());
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find(fsm.targetNode_queue.Peek().ToString()).transform.position, maxSpeed );
            yield return null;
            if (Vector3.Distance(transform.position, GameObject.Find(fsm.targetNode_queue.Peek().ToString()).transform.position) < 20f)
            {
                fsm.targetNode_queue.Dequeue();
            }
        }
    }
}
