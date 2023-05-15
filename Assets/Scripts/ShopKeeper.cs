using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShopKeeper : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animState;
    private Vector3 lastPos;

    [SerializeField] Transform target;
    [SerializeField] float currentSpeed;

    public float stopDistance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        agent = GetComponent<NavMeshAgent>();
        animState = GetComponent<Animator>();

        agent.SetDestination(target.position);

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if (agent.remainingDistance < stopDistance)
            agent.isStopped = true;


        //is he moving?

        currentSpeed = Vector3.Distance(transform.position, lastPos);

        if (currentSpeed > 0.00001f)
        {
            animState.SetBool("isWalking", true);
            animState.SetBool("isIdle", false);
        }
        else
        {
            animState.SetBool("isWalking", false);
            animState.SetBool("isIdle", true);
        }

        lastPos = transform.position;
    }

    public void setTarget(Transform newTarget)
    {
        //check on stuff before setting new target
        target = newTarget;

    }

}
