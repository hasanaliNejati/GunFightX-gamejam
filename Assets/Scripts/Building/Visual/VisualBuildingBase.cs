using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Building.Visual
{
    public class VisualBuildingBase : MonoBehaviour
    {

        [SerializeField]public Transform shootPos;
        public Transform rotateRoot;

        

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        
    }
}