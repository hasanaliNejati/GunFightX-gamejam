using Assets.Scripts.Building;
using Assets.Scripts.EnemyWave.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalEnemy : EnemyBase
{

    public float attackPower;
    public float attackDelay = 2;
    public float giveDamageDelay = 1;
    float _attackDelay;

    public override void CoustomUpdate()
    {
        base.CoustomUpdate();
        animator.SetBool("Move", state == State.Follow);

        if (state == State.Attack)
        {
            _attackDelay -= Time.deltaTime;
            if (_attackDelay <= 0)
            {
                animator.SetTrigger("Attack");
                _attackDelay = attackDelay;
                StartCoroutine(GiveDamage(target.GetComponent<BuildingBase>(), giveDamageDelay));
            }
        }

    }

    IEnumerator GiveDamage(BuildingBase building, float time)
    {
        yield return new WaitForSeconds(time);
        //take damage
        building.TakeDamage(attackPower);
    }

    public override void Die()
    {
        ApplyDie();

        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Collider>().enabled = false;

        animator.SetBool("Death", true);
        this.enabled = false;

        Destroy(gameObject, 3);
    }

}
