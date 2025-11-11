using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePatrolingState : StateMachineBehaviour
{

    float timer;
    public float patrolTime = 10f;

    Transform player;
    NavMeshAgent navAgent;

    public float detectionArea = 18f;
    public float patrolSpeed = 2f;

    List<Transform> waypoints = new  List<Transform>();

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = animator.GetComponent<NavMeshAgent>();

        navAgent.speed = patrolSpeed;
        timer = 0;

        GameObject waypointParent = GameObject.FindGameObjectWithTag("Waypoints");

        foreach (Transform waypoint in waypointParent.transform)
        {
            waypoints.Add(waypoint);
        }

        Vector3 nextPosition = waypoints[Random.Range(0, waypoints.Count)].position;
        navAgent.SetDestination(nextPosition);

       

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            navAgent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
        }

        timer += Time.deltaTime;
        if (timer > patrolTime)
        {
            animator.SetBool("isPatroling", false);
        }

        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer < detectionArea)
        {
            animator.SetBool("isChasing", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navAgent.SetDestination(navAgent.transform.position);
    }

}
