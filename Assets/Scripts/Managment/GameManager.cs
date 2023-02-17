using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.PlayerTask;
using Assets.Scripts.PlayerTask.Tasks;
using Assets.Scripts.EnemyWave;
using Assets.Scripts.Building;
using Assets.Scripts.PlayerTask.Reward;

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
        public RewardManager rewardManager;
        private void Awake()
        {
            instance = this;
            enemyManagment.OnEndWave += FinishWave;
        }

        public void FinishWave()
        {
            rewardManager.ActiveRewardPanel();
        }

        public void StartNewWave()
        {
            enemyManagment.StartWave();
        }

        public void Lose()
        {
            
        }


    }
}