using System.Collections;
using UnityEngine;
using System;
using UnityEngine.AI;
using Assets.Scripts.Managment;
using Assets.Scripts.DamageManagment;

namespace Assets.Scripts.EnemyWave.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyBase : MonoBehaviour , ITakeDamage 
    {

        public event Action<EnemyBase> OnEnemyDie;


        public enum EnemyType { normal,bomb,giant}
        public EnemyType enemyType;
        
        public float health;
        float _maxHealth;

        enum State { Follow, Attack }
        State state = State.Follow;


        public float minDistance;

        public Transform target;

        //LOGIC 
        NavMeshAgent _agent;
        NavMeshAgent agent
        {
            get { return _agent ? _agent : _agent = GetComponent<NavMeshAgent>(); }
        }


        private void Update()
        {
            if (!target)
                target = GameManager.instance.mainTower.transform;
            if (FollowingDistance() <= minDistance)
                state = State.Attack;
            else
                state = State.Follow;

            switch (state)
            {
                case State.Follow:
                    SetDestination(target.position);
                    break;
                case State.Attack:
                    StopFollowing();
                    break;
                default:
                    break;
            }
        }

        public float FollowingDistance()
        {
            if (!target)
                return 1000;
            return Tools.VerticalDistance(transform.position, target.position);
        }

        public void SetDestination(Vector3 destination)
        {
            agent.SetDestination(destination);
        }

        public void StopFollowing()
        {
            agent.SetDestination(transform.position);
        }

        public void Die()
        {
            OnEnemyDie(this);
            Destroy(gameObject);
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
                Die();
        }

        public float Health()
        {
            return health / _maxHealth;
        }

        public void Heal(float heal)
        {
            health += heal;
            heal = Mathf.Clamp(heal,0,_maxHealth);
        }
    }
}