using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    [SerializeField] protected int hp = 100;
    [SerializeField] protected int damage = 5;
    [SerializeField] protected float moveSpd = 1f;
    [SerializeField] protected float attackDelay = 1f;
    [SerializeField] protected float invulnerableTime = 1f;

    protected bool invulnerable = false;
    protected float invulnerableTimer = 0f;
    protected float attackTimer = 0f;

    protected Rigidbody rb;
    protected NavMeshAgent agent;


    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
	}


    void Update ()
    {
		
	}


    protected virtual void AttackMelee()
    {

    }


    protected virtual void AttackRange()
    {

    }


    protected virtual void OnTriggerEnter(Collider other)
    {

    }
}
