using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.PlayerTask.Tasks
{
    public interface ITask
    {
        public bool CanExecute();
        public void Execute();
        public void Cancel();
    }
}