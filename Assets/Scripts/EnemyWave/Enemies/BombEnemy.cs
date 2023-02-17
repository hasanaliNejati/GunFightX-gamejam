using Assets.Scripts.EnemyWave.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Assets.Scripts.EnemyWave.Enemies
{

    public class BombEnemy : EnemyBase
    {
        public GameObject expelosionEffect;
        public override void CoustomUpdate()
        {
            base.CoustomUpdate();
            if (state == State.Attack)
                Expelosion();
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