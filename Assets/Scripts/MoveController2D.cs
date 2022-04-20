using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Wizard2D
{
		

	public class MoveController2D : MonoBehaviour
	{

        [SerializeField] private float speed; 
        [SerializeField] private float jumpForce;
        private Rigidbody2D rb;
        private Collider2D coll;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            coll = GetComponent<Collider2D>();
        }

        private void Update()
        {
            // Можно прыгать, если коллайдер игрока трогает слой земля или противник

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
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

        private bool IsGrounded(){
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.01f,LayerMask.GetMask("Ground","Enemies"));
            return raycastHit2D.collider !=null;
        }



    }
}

