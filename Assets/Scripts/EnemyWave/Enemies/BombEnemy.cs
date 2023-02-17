using Assets.Scripts.EnemyWave.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.DamageManagment;

namespace Assets.Scripts.EnemyWave.Enemies
{

    public class BombEnemy : EnemyBase
    {
        public float expelosionPower = 50;
        public GameObject expelosionEffect;
        public override void CoustomUpdate()
        {
            base.CoustomUpdate();
            if (state == State.Attack)
            {
                target.GetComponent<ITakeDamage>().TakeDamage(expelosionPower);
                Expelosion();
            }
        }

        void Expelosion()
        {

            ApplyDie();
            CameraShake.NormalShake();
            Instantiate(expelosionEffect,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }


}