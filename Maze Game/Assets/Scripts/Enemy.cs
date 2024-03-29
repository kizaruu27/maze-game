﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float playerDistance;
    public float awaareAI = 10f;
    public float AIMoveSpeed;
    public float damping = 6f;

    public Transform[] navPoint;
    public UnityEngine.AI.NavMeshAgent agent;
    public int destPoint = 0;
    public Transform goal;

    private void Start()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;

        agent.autoBraking = false;
    }

    private void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance < awaareAI)
        {
            LookAtPlayer();
            Debug.Log("Seen");
        }

        if (playerDistance < awaareAI)
        {
            if (playerDistance > 2f)
                Chase();
            else
                GotoNextPoint();
        }
        {
            if (agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }

    }

    void LookAtPlayer()
    {
        transform.LookAt(player);
    }

    void GotoNextPoint()
    {
        if (navPoint.Length == 0)
            return;
        agent.destination = navPoint[destPoint].position;
        destPoint = (destPoint + 1) % navPoint.Length;
    }

    void Chase()
    {
        transform.Translate(Vector3.forward * AIMoveSpeed * Time.deltaTime);
    }

}
