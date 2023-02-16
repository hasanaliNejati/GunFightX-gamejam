using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PlayerTask.Tasks
{
    public class TaskBase : MonoBehaviour, ITask
    {

        public LayerMask groundLayer;


        bool canExecute;
        protected virtual void Update()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, groundLayer))
            {
                canExecute = true;
                transform.position = hit.point;
            }
            else
            {
                canExecute = false;
            }

            TaskUpdate();
        }

        protected virtual void TaskUpdate()
        {

        }

        public virtual bool CanExecute()
        {
            return canExecute;
        }

        public virtual void Execute()
        {
            print("TaskBase executed.");
            Destroy(gameObject);
        }

        public virtual void Cancel()
        {
            Destroy(gameObject);

        }
    }
}