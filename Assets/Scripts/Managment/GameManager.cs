using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.PlayerTask;
using Assets.Scripts.PlayerTask.Tasks;
using Assets.Scripts.EnemyWave;
using Assets.Scripts.Building;

namespace Assets.Scripts.Managment
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;

        

        public TaskManager taskManager;
        public EnemyWaveManagmer enemyManagment;
        [HideInInspector]
        public List<BuildingBase> buildings= new List<BuildingBase>();
        public Building.BuildingBase mainTower;

        private void Awake()
        {
            instance = this;
        }

        public void FinishWave()
        {

        }

        public void StartNewWave()
        {

        }

        public void Lose()
        {

        }


    }
}