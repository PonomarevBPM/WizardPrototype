using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private PlayerStateMachine playerStateMachine;
    [SerializeField]private Collider2D coll;
    void Start()
    {
        playerStateMachine = GameObject.FindWithTag("Player").GetComponent<PlayerStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && playerStateMachine.hasKey)
        {
            coll.enabled = false;
            playerStateMachine.hasKey = false;
        }
    }
}
