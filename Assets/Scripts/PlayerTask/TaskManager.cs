using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.PlayerTask.Tasks;
using Assets.Scripts.Managment;

namespace Assets.Scripts.PlayerTask
{
    public class TaskManager : MonoBehaviour
    {



        ITask activeTask;
        private void Update()
        {
            if (activeTask != null && Input.GetMouseButtonUp(1))
            {
                ExecuteTask();
            }
            //if (activeTask != null && Input.GetMouseButtonUp(1))
            //{
            //    CancelTask();
            //}
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
                //if building task 
                GameManager.instance.StartNewWave();

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