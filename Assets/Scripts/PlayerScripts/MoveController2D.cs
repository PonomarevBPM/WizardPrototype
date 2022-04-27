using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	

public class MoveController2D : MonoBehaviour
{

    [SerializeField] private float speed; 
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private Collider2D coll;
    [HideInInspector]public float moveHorizontal;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
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
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
            } else 
            {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {

         moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 moving = new Vector2 (moveHorizontal * speed, rb.velocity.y);
        rb.velocity = moving;
        
        //Вместо изменения скейла, теперь вращаем вокруг оси y, что позволит снарядам лететь в нужную сторну всегда
        Flip();    
    }

    public bool IsGrounded(){
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,LayerMask.GetMask("Ground","Enemies"));
        return raycastHit2D.collider !=null;
    }

    private void Flip()
    {
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

