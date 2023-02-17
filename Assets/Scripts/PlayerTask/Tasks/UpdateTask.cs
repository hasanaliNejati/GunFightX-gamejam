using Assets.Scripts.Building;
using Assets.Scripts.Managment;
using Assets.Scripts.PlayerTask.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTask : TaskBase
{

    public Transform Shower;

    public enum UpdateType
    {
        Tower, Range, Shild
    }

    public UpdateType type;
    BuildingBase building;
    public override bool CanExecute()
    {

         building = null;
        float lowerest = 100;
        foreach (var item in GameManager.instance.buildings)
        {
            float dis = Tools.VerticalDistance(item.transform.position, transform.position);
            if (dis < lowerest)
            {
                lowerest = dis;
                building = item;
            }
        }
        Shower.transform.position = building.transform.position;

        return building;
    }

    protected override void TaskUpdate()
    {
        building = null;
        float lowerest = 100;
        foreach (var item in GameManager.instance.buildings)
        {
            float dis = Tools.VerticalDistance(item.transform.position, transform.position);
            if (dis < lowerest)
            {
                lowerest = dis;
                building = item;
            }
        }
        Shower.transform.position = building.transform.position;
    }


    public override void Execute()
    {

        switch (type)
        {
            case UpdateType.Tower:
                if (building.towerLevel < building.towerUpdates.Length - 1)
                    building.towerLevel++;
                break;
            case UpdateType.Range:
                if (building.rangeLevel < building.rangeUpdates.Length - 1)
                    building.rangeLevel++;
                break;
            case UpdateType.Shild:
                if (building.shildLevel < building.shildUpdates.Length - 1)
                    building.shildLevel++;
                break;
            default:
                break;
        }
        building.UpdateLevel();
        Destroy(gameObject);
    }
}
