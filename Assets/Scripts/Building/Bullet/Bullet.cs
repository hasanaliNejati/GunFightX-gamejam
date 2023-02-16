using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 20;
        public LayerMask layer;

        //LOGIC
        Vector3 distenation;
        Vector3 startPos;
        private void Start()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit outRay;

            if (Physics.Raycast(ray, out outRay, 100, layer))
            {
                distenation = outRay.point;
            }
            else
            {
                distenation = transform.position + transform.forward * 40;
            }
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, distenation, speed * Time.deltaTime);
            if (transform.position == distenation)
            {
                Hit();
            }
        }

        private void Hit()
        {
            Destroy(gameObject);
        }
    }
}