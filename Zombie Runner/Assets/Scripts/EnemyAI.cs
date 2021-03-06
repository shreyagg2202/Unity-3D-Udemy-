using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    bool isAngry = false;
    bool playing = false;
    EnemyHealth health;
    Transform target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        else
        {
            isProvoked = false;
        }

        if (isProvoked == true || isAngry == true)
        {
            EngageTarget();
            if (!playing)
            {
                FindObjectOfType<AudioManager>().Play("EnemyAttacking");
                playing = true;
            }
        }
        else
        {
            StopEnemy();
        }
    }

    public void OnDamageTaken()
    {
        isAngry = true;
    }

    private void EngageTarget()
    {
        Debug.Log("Engaged");
        FaceTarget();
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        Debug.Log("Chasing");
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log("Attacking");
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void StopEnemy()
    {
        Debug.Log("Enemy Stopped");
        GetComponent<Animator>().SetTrigger("idle");
        navMeshAgent.SetDestination(transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void EnemyWalkingEvent_Left()
    {
        FindObjectOfType<AudioManager>().Play("EnemyFootsteps_Left");
    }

    public void EnemyWalkingEvent_Right()
    {
        FindObjectOfType<AudioManager>().Play("EnemyFootsteps_Right");
    }
}
