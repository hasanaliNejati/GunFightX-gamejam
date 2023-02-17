using Assets.Scripts.Managment;
using Assets.Scripts.PlayerTask.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.PlayerTask.Reward
{
    public class RewardManager : MonoBehaviour
    {
        public PanelScript rewardPanel;

        public List<RewardCard> rewardCards1 = new List<RewardCard>();
        public List<RewardCard> rewardCards2 = new List<RewardCard>();
        public List<RewardCard> rewardCards3 = new List<RewardCard>();

       
        public void ActiveRewardPanel()
        {
            ActiveRandom();
            rewardPanel.SetActive(true);
        }

        void ActiveRandom()
        {
            int random1 = Random.Range(0, rewardCards1.Count);
            for (int i = 0; i < rewardCards1.Count; i++)
            {
                rewardCards1[i].gameObject.SetActive(i == random1);
            }

            int random2 = Random.Range(0, rewardCards2.Count);
            for (int i = 0; i < rewardCards2.Count; i++)
            {
                rewardCards2[i].gameObject.SetActive(i == random2);
            }

            int random3 = Random.Range(0, rewardCards3.Count);
            for (int i = 0; i < rewardCards3.Count; i++)
            {
                rewardCards3[i].gameObject.SetActive(i == random3);
            }
        }

        public void RewardSelected(TaskBase task)
        {
            rewardPanel.SetActive(false);
            GameManager.instance.taskManager.SelectTask(task);
        }

    }
}