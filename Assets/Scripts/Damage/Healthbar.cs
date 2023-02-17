using Assets.Scripts.Building;
using Assets.Scripts.DamageManagment;
using Assets.Scripts.EnemyWave.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
    

    public Image slider;

    public EnemyBase enemyHealth;
    public BuildingBase buildingBase;


    private void Awake()
    {
       

    }

    private void Update()
    {
        if (enemyHealth)
        {

            slider.fillAmount = enemyHealth.Health();
        }
        if (buildingBase)
        {

            slider.fillAmount = buildingBase.Health();
        }
        transform.LookAt(Camera.main.transform.position);
    }
}
