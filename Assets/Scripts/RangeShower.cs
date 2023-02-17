using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeShower : MonoBehaviour
{

    public bool alwaysShow;

    public Transform shootRange;
    public Transform apearingRange;

    public BuildingBase building;
    bool show;

    private void Update()
    {
        if (alwaysShow)
        {
            show = true;
        }
        else
        {
            show = Input.GetMouseButton(1);
        }

        shootRange.gameObject.SetActive(show);
        apearingRange.gameObject.SetActive(show);   

        if(building)
        {
            shootRange.localScale = Vector3.one * building.rangeUpdates[building.rangeLevel].shootRange * 2;
            apearingRange.localScale = Vector3.one * building.rangeUpdates[building.rangeLevel].apearingRange * 2;
        }
    }
}
