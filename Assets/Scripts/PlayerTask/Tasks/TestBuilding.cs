using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PlayerTask.Tasks
{
    public class TestBuilding : TaskBase
    {
        public GameObject building;

        public override void Execute()
        {
            Instantiate(building, transform.position, transform.rotation);
            Destroy(gameObject);
        }



    }
}