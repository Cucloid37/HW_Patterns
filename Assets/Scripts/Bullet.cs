using System;
using UnityEngine;

namespace HW_Patterns
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Fire(Vector3 vector, float force)
        {
            rb.AddForce(vector * force);
        }
    }
}