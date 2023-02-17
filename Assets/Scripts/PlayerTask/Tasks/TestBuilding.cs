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
            if (GameManager.instance.mainTower.IsInsideApearingRange(transform))
            {
                float lowerest = 100;
                foreach (var item in GameManager.instance.buildings)
                {
                    float dis = Tools.VerticalDistance(item.transform.position, transform.position);
                    if (dis < lowerest)
                    {
                        lowerest = dis;
                    }
                }
                if (lowerest > 1)
                {
                    return true;
                }
            }
            //print("False");
            return false;
        }

        public override void Execute()
        {
            Instantiate(building, transform.position, transform.rotation);
            Destroy(gameObject);
        }



    }
}