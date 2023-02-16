using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.DamageManagment
{
    public interface ITakeDamage
    {

        public void TakeDamage(float damage);
        //betwwin 0-1
        public float Health();
        public void Heal(float heal);
    }
}