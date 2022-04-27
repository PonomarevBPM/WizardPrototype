using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private PlayerStateMachine playerStateMachine;

    // Start is called before the first frame update
    void Start()
    {
        playerStateMachine = GameObject.FindWithTag("Player").GetComponent<PlayerStateMachine>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerStateMachine.GetKey();
        }
    }
}
