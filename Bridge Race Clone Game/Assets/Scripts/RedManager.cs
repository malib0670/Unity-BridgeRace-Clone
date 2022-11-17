using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RedManager : MonoBehaviour
{
    Vector3 destination;
    public NavMeshAgent agent;
    public LayerMask layer;
    public Transform[] finalDestination;
    Animator redAnimator;

    bool closest, furthest;
    int randomNumber;
    bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        redAnimator = GetComponent<Animator>();
        randomNumber = Random.Range(0, 3);
        isMove = true;
        closest = true;
        furthest = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            stackFinder();
        }
    }

    public void stackFinder()
    {
        Collider[] objectsInArea = Physics.OverlapSphere(transform.position, 12f, layer);

        if (objectsInArea.Length > 0)
        {
            redAnimator.SetBool("idleAnim", true);

            if (closest)
            {
                destination = objectsInArea[objectsInArea.Length - 1].transform.position;
                agent.SetDestination(destination);

                if (RedStacks.stackListRed.Count > 0)
                {
                    GameObject.Find("Stack Parent Red").transform.GetChild
                        (GameObject.Find("Stack Parent Red").transform.childCount - 1).gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                if (RedStacks.stackListRed.Count > 4)
                {
                    agent.SetDestination(finalDestination[randomNumber].transform.position);
                }
            }
        }

        else if (objectsInArea.Length == 0 && RedStacks.stackListRed.Count == 0)
        {
            agent.SetDestination(new Vector3(-0.4f, 0.35f, -11.83f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            randomNumber = 3;
        }
    }

    private void onDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 12f);
    }
}
