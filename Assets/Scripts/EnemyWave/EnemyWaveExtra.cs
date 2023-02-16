using Assets.Scripts.EnemyWave.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.EnemyWave
{
    [System.Serializable]
    public class EnemyInfo
    {
        public EnemyBase enemyObject;
        public int minWave;
        [Range(1,50)]
        public int possibility = 1;
    }
}