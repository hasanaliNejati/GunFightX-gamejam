using Assets.Scripts.EnemyWave.Enemies;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public class NormalTower : BuildingBase
    {
        public bool shooting;
        public float aimOffsetShoot;
        public float rotateSpeed = 5;
        //[HideInInspector]
        public EnemyBase target;

        //LOGIC
        float _delay;


        public override void CustomUpdate()
        {
            ScanTarget();
            if (target)
            {

                if (target.IsDeath)
                    target = null;
                MoveTorret();
            }
            else
                shooting = false;
            if (shooting)
            {
                Shooting();
            }
        }

        void ScanTarget()
        {
            if (target && !IsInsideShootRange(target.transform))
            {
                target = null;
            }
            if (!target)
            {
                target = NearestEnemy();
            }
        }

        void MoveTorret()
        {
            var v = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;


            //Aim
            var deg = (Mathf.Atan2(v.x, v.z) * Mathf.Rad2Deg);

            var root = towerUpdates[towerLevel].visualBuilding.rotateRoot;
            root.rotation = Quaternion.Lerp(root.rotation, Quaternion.Euler(0, deg, 0), rotateSpeed * Time.deltaTime);


            //Shoot
            if (Vector3.AngleBetween(-v, towerUpdates[towerLevel].visualBuilding.shootPos.forward) < aimOffsetShoot)
            {
                shooting = true;
                return;
            }

            shooting = false;
        }

        void Shooting()
        {
            _delay -= Time.deltaTime;
            if (_delay <= 0)
            {
                _delay = towerUpdates[towerLevel].shootRate;
                //_delay = Random.Range(towerUpdates[towerLevel].shootRate , towerUpdates[towerLevel].shootRate + 0.1f);
                Shoot();
            }
        }
        void Shoot()
        {
            var t = towerUpdates[towerLevel].visualBuilding.shootPos;
            Instantiate(towerUpdates[towerLevel].bullet, t.position, t.rotation);
        }
    }
}