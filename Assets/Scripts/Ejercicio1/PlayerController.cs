using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace semana12
{
    public class PlayerController : MonoBehaviour
    {
        public float jumpForce;
        private new Rigidbody rigidbody;
        private bool isGrounded = true;
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
            
            else
            {
                GameController.Instance.GameOver();
            }
        }
        
        private void OnTriggerExit(Collider collision)
        {
            GameController.Instance.UpdateScore(1);
        }
    }
}
