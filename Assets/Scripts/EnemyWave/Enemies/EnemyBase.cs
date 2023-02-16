using System.Collections;
using UnityEngine;
using System;

namespace Assets.Scripts.EnemyWave.Enemies
{
    public class EnemyBase : MonoBehaviour
    {

        public event Action<EnemyBase> OnEnemyDie;

        public void Die()
        {
            OnEnemyDie(this);
            Destroy(gameObject);
        }

    }
}