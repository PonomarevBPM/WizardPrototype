using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHandler : MonoBehaviour
{
    //Префаб снаряда
    [SerializeField] private GameObject projPrefab;
    [SerializeField] private Transform spawnPoint;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            //Спавним снаряд из spawnPoint в напрвлении как сам spawnpoint
            Instantiate(projPrefab,spawnPoint.position,spawnPoint.rotation);
        }
    }
}
