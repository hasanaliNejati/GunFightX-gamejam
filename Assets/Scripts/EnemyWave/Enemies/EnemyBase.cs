using System.Collections;
using UnityEngine;
using System;
using UnityEngine.AI;
using Assets.Scripts.Managment;

namespace Assets.Scripts.EnemyWave.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyBase : MonoBehaviour
    {

        public event Action<EnemyBase> OnEnemyDie;

        public void Die()
        {
            OnEnemyDie(this);
            Destroy(gameObject);
        }

        public enum EnemyType { normal,bomb,giant}
        public EnemyType enemyType;
        
        

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
    }
}