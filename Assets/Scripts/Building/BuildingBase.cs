using Assets.Scripts.Building.Visual;
using Assets.Scripts.DamageManagment;
using Assets.Scripts.EnemyWave.Enemies;
using Assets.Scripts.Managment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Building
{
    public class BuildingBase : MonoBehaviour , ITakeDamage
    {

        [HideInInspector]
        public int towerLevel = 0;
        [HideInInspector]
        public int rangeLevel = 0;
        [HideInInspector]
        public int shildLevel = 0;


        [System.Serializable]
        public class TowerData
        {
            public float shootRate = 1;
            public Bullet bullet;
            public VisualBuildingBase visualBuilding;
        }
        [System.Serializable]
        public class RangeData
        {
            public float apearingRange = 10;
            public float shootRange = 10;
        }
        [System.Serializable]
        public class ShildData
        {
            public int shildHealth;
        }

        public TowerData[] towerUpdates;
        public RangeData[] rangeUpdates;
        public ShildData[] shildUpdates;

        public EnemyBase.EnemyType apearingEnemy;


        public GameObject dieEffect;

        public float buildingHealth = 100;
        float health;


        private void Start()
        {
            health = buildingHealth;
            GameManager.instance.buildings.Add(this);
            UpdateSkin();
            
        }
        void UpdateSkin()
        {
            for (int i = 0; i < towerUpdates.Length; i++)
            {
                towerUpdates[i].visualBuilding.SetActive(i == towerLevel);
            }

        }

        private void Update()
        {
            Apearing();
            CustomUpdate();
        }

        public virtual void CustomUpdate()
        {

        }

        void Apearing()
        {
            var enemies = FindAllEnemy(rangeUpdates[rangeLevel].apearingRange);
            foreach (var item in enemies)
            {
                if (item.enemyType != apearingEnemy)
                    continue;
                float dis = Tools.VerticalDistance(item.transform.position, transform.position);
                if (item.FollowingDistance() > dis)
                {
                    item.target = transform;
                }

            }
        }

        public EnemyBase NearestEnemy()
        {
            var insideRangeEnemy = FindAllEnemy(rangeUpdates[rangeLevel].shootRange);
            EnemyBase nearestEnemy = null;
            foreach (var item in insideRangeEnemy)
            {
                if (nearestEnemy == null)
                {
                    nearestEnemy = item;
                    continue;
                }
                if (Tools.VerticalDistance(transform.position, item.transform.position)
                    < Tools.VerticalDistance(transform.position, nearestEnemy.transform.position))
                {
                    nearestEnemy = item;
                }
            }
            return nearestEnemy;
        }

        protected EnemyBase[] FindAllEnemy(float radios)
        {
            var result = new List<EnemyBase>();
            foreach (var item in GameManager.instance.enemyManagment.aliveEnemies)
            {
                if (IsInsideCircle(item.transform, radios))
                {
                    result.Add(item);
                }
            }
            return result.ToArray();
        }

        public bool IsInsideCircle(Transform tr, float radios)
        {
            var dis = Tools.VerticalDistance(tr.position, transform.position);
            return dis <= radios;
        }
        public bool IsInsideShootRange(Transform tr)
        {
            var dis = Tools.VerticalDistance(tr.position, transform.position);
            return dis <= rangeUpdates[rangeLevel].shootRange;
        }
        public bool IsInsideApearingRange(Transform tr)
        {
            var dis = Tools.VerticalDistance(tr.position, transform.position);
            return dis <= rangeUpdates[rangeLevel].apearingRange;
        }

        private void OnDestroy()
        {
            GameManager.instance.buildings.Remove(this);
        }

        private void Die()
        {
            Instantiate(dieEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        public float Health()
        {
            return health / buildingHealth;
        }

        public void Heal(float heal)
        {
            health += heal;
            heal = Mathf.Clamp(heal, 0, buildingHealth);
        }
    }
}