using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    [SerializeField] protected float targetOffset = 1f;

    protected bool dead = false;
    
    protected Transform playerTrans;

    
	void Start ()
    {
        agent.speed = moveSpd;
        agent.stoppingDistance = targetOffset;

        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	
	void Update ()
    {
        agent.SetDestination(playerTrans.position);
    }


    protected virtual void Attack()
    {

    }


    protected void TakeDamage(int dmg, float pushBack, Vector3 playerPos)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            pushBack *= 10;
            dead = true;
        }

        Vector3 pushDir = transform.position - playerPos;

        rb.AddForce(pushDir.normalized * pushBack);
    }


    protected void Death()
    {
        Destroy(gameObject);
    }


    protected void OnCollisionEnter(Collision coll)
    {
        if (dead)
        {
            Death();
        }
    }


    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerDMG" && !invulnerable)
        {
            
        }
    }
}
