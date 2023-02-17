using Assets.Scripts.Managment;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PlayerTask.Tasks
{
    public class TestBuilding : TaskBase
    {
        public GameObject building;

        public override bool CanExecute()
        {
            //GameManager.instance.
        }

        public override void Execute()
        {
            Instantiate(building, transform.position, transform.rotation);
            Destroy(gameObject);
        }



    }
}