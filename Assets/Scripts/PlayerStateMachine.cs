using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody2D rb;
    private MoveController2D moveController2D;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        moveController2D = GetComponent<MoveController2D>();
        playerAnim.SetBool("IsRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveController2D.moveHorizontal != 0)
        {
            playerAnim.SetBool("IsRunning", true);
        } else 
        {
            playerAnim.SetBool("IsRunning", false);
        }
    }

    public void SetElementalAnimation(int element)
    {
        playerAnim.SetInteger("elementalPower",element);
    }
}
