using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.PlayerTask.Tasks;

namespace Assets.Scripts.PlayerTask
{
    public class TaskManager : MonoBehaviour
    {



        ITask activeTask;
        private void Update()
        {
            if (activeTask != null && Input.GetMouseButtonUp(0))
            {
                ExecuteTask();
            }
            if (activeTask != null && Input.GetMouseButtonUp(1))
            {
                CancelTask();
            }
        }



        public void ShowGiftTask()
        {
            print("Gifttask showed.");
        }

        public void SelectTask(TaskBase task)
        {
            activeTask = Instantiate(task);
        }

        void ExecuteTask()
        {
            if (activeTask.CanExecute())
            {
                activeTask.Execute();
                activeTask = null;
            }
        }

        void CancelTask()
        {
            activeTask.Cancel();
            activeTask = null;
        }
    }
}