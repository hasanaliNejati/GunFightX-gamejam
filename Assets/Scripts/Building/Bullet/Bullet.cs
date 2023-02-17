using Assets.Scripts.DamageManagment;
using Assets.Scripts.EnemyWave.Enemies;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;

namespace Assets.Scripts.Building
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 20;
        public float damage = 20;
        public LayerMask layer;

        public GameObject fire;
        public GameObject impact;
        //LOGIC
        Vector3 distenation;
        Vector3 startPos;


        EnemyBase targetEnemy;



        private void Awake()
        {
            Instantiate(fire, transform.position, transform.rotation);
        }
        RaycastHit outRay;
        private void Start()
        {
            var ray = new Ray(transform.position, transform.forward);


            if (Physics.Raycast(ray, out outRay, 100, layer))
            {
                distenation = outRay.point;
                if (outRay.collider.GetComponent<EnemyBase>())
                {
                    targetEnemy = (outRay.collider.GetComponent<EnemyBase>());
                }
            }
            else
            {
                distenation = transform.position + transform.forward * 40;
            }
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, distenation, speed * Time.deltaTime);
            if (transform.position == distenation)
            {
                Hit();
            }
        }

        private void Hit()
        {
            if (targetEnemy)
            {
                targetEnemy.TakeDamage(damage);
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, outRay.normal);
                Vector3 pos = outRay.point;
                Instantiate(impact, pos, rot);
            }
            Destroy(gameObject);
        }
    }
}