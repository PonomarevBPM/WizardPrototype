using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Wizard2D
{
		

	public class MoveController2D : MonoBehaviour
	{

        [SerializeField] private float speed; 
        [SerializeField] private float jumpForce;
        private bool canJumping;
        Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // Можно прыгать, если коллайдер игрока трогает слой земля или противник
            canJumping = GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Ground", "Enemies"));

            if (Input.GetKeyDown(KeyCode.Space)&&canJumping)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        private void FixedUpdate()
        {

            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector2 moving = new Vector2 (moveHorizontal * speed, rb.velocity.y);
            rb.velocity = moving;
            
            //Вместо изменения скейла, теперь вращаем вокруг оси y, что позволит снарядам лететь в нужную сторну всегда
            if (moveHorizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0,0,0);   
            }
            if (moveHorizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0,180,0);
            }    
        }

        



    }
}

