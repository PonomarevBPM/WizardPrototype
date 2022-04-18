using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Wizard2D
{
		[RequireComponent(typeof(Rigidbody2D))]

	public class MoveController2D : MonoBehaviour
	{
		[SerializeField]
		private float speed, addForce;
		private float horizontalDirection;
		private Rigidbody2D body;
		private bool jump;

		void Start()
		{
			body = GetComponent<Rigidbody2D>();
			
			
		}

		void OnCollisionStay2D(Collision2D coll)
		{
			//Проверка на земле ли игрок
			if (coll.transform.tag == "Ground")
			{
				
				jump = true;
			}
		}

		void OnCollisionExit2D(Collision2D coll)
		{
			if (coll.transform.tag == "Ground")
			{
				jump = false;
			}
		}

		void FixedUpdate()
		{
	
			horizontalDirection = Input.GetAxisRaw("Horizontal");

			body.velocity = new Vector2(horizontalDirection * speed * Time.deltaTime, 0f);

			if (Input.GetButton("Jump") && jump)
				{
					body.velocity = new Vector2(0, addForce);
				}
			Flip();
		}

		void Flip()	
		{
			if (body.velocity.x > 0) {
				transform.localScale =  new Vector2(1, transform.localScale.y);
			} else if (body.velocity.x < 0) {
				transform.localScale =  new Vector2(-1, transform.localScale.y);
			}
		}

	}
}

