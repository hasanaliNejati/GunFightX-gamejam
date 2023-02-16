using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnemyWave.Enemies;

namespace Assets.Scripts.EnemyWave
{
    public class EnemyWaveManagmer : MonoBehaviour
    {

        public List<EnemyInfo> enemies = new List<EnemyInfo>();
        public float safeAreaRadios = 10;
        public float spownAreaRadios = 10;

        [HideInInspector]
        public int waveNumber = 0;
        public int correntWaveEnemyCount
        {
            get { return enemiesQueue.Count; }
        }

        public event System.Action OnEndWave;

        //LOGIC
        List<EnemyBase> enemiesQueue = new List<EnemyBase>();
        public List<EnemyBase> aliveEnemies = new List<EnemyBase>();
        Transform _enemyParent;
        Transform enemyParent
        {
            get { return _enemyParent ? _enemyParent : _enemyParent = new GameObject("Enemy parent").transform; }
        }

        private void Start()
        {
            CalculateWave(1);
            StartWave();
        }

        void CalculateWave(int waveNumber)
        {
            List<EnemyInfo> canUseEnemyList = new List<EnemyInfo>();
            int allPossibility = 0;
            foreach (var item in enemies)
            {
                if (item.minWave <= waveNumber)
                {
                    canUseEnemyList.Add(item);
                    allPossibility += item.possibility;
                }
            }

            int enemyCount = Random.Range(waveNumber, waveNumber * 2);

            for (int i = 0; i <= enemyCount; i++)
            {
                int randomPossibility = Random.Range(0, allPossibility);
                foreach (var item in canUseEnemyList)
                {
                    randomPossibility -= item.possibility;
                    if (randomPossibility <= 0)
                    {
                        enemiesQueue.Add(item.enemyObject);
                        break;
                    }
                }
            }
        }


        public void StartWave()
        {
            StartCoroutine(SpownEnemiesqueue());
        }

        private IEnumerator SpownEnemiesqueue()
        {
            print(enemiesQueue.Count);
            float minDelay = 0.1f;
            float maxDelay = 1;
            float maxWaveTime = 20;
            var a = maxDelay * enemiesQueue.Count;
            if (a > maxWaveTime)
            {
                minDelay *= maxWaveTime / a;
                maxDelay *= maxWaveTime / a;
            }

            while (true)
            {
                Vector3 pos = Random.insideUnitCircle;
                pos = new Vector3(pos.x, 0, pos.y).normalized;
                pos *= Random.Range(safeAreaRadios, safeAreaRadios + spownAreaRadios);
                Quaternion rotation = new Quaternion();
                SpownEnemy(enemiesQueue[0], pos, rotation);
                enemiesQueue.RemoveAt(0);
                yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                if (enemiesQueue.Count <= 0)
                    break;
            }
        }

        public void SpownEnemy(EnemyBase enemy, Vector3 pos, Quaternion rotation)
        {
            var newEnemy = Instantiate(enemy, pos, rotation, enemyParent);
            aliveEnemies.Add(newEnemy);
            newEnemy.OnEnemyDie += DieEnemy;
        }

        private void DieEnemy(EnemyBase enemy)
        {
            aliveEnemies.Remove(enemy);
            if (enemiesQueue.Count <= 0 && aliveEnemies.Count <= 0)
                EndWave();
        }

        public void EndWave()
        {
            OnEndWave.Invoke();
        }
    }
}