using Assets.Scripts.Managment;
using Assets.Scripts.PlayerTask.Tasks;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PlayerTask.Reward
{
    public class RewardCard : MonoBehaviour
    {

        public TaskBase task;


        public void Click()
        {
            GameManager.instance.rewardManager.RewardSelected(task);
        }
    }
}