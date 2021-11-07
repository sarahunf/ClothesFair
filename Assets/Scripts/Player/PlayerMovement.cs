using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]private float moveSpeed = 5f;
        private float defaultMoveSpeed;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator animator;
        private Vector2 movement;
        private bool allowMovement = true;

        private void Update()
        {
            if (!allowMovement) return;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        }

        public void StopMoving()
        {
            defaultMoveSpeed = moveSpeed;
            moveSpeed = 0f;
            animator.SetBool("FaceStore", true);
            allowMovement = false;
        }

        public void StartMoving()
        {
            moveSpeed = defaultMoveSpeed;
            animator.SetBool("FaceStore", false);
            allowMovement = true;
        }
    }
}
