using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace semana12
{
    public class HazardContainer : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }


        private void Update()
        {
            rb.velocity = Vector3.left * speed;
        }
    }
}
