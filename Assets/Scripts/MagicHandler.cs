using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHandler : MonoBehaviour
{
    //Префаб снаряда
    [SerializeField] private GameObject projPrefab;
    [SerializeField] private Transform spawnPoint;
    private SpriteRenderer spriteRenderer;
    int index;

    public Sprite[] spriteArray;
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

   
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            //Спавним снаряд из spawnPoint в напрвлении как сам spawnpoint
            Instantiate(projPrefab,spawnPoint.position,spawnPoint.rotation);
        }

        if (Input.GetButtonDown("Fire3")){
            ChangeElement(spriteRenderer.sprite);
        }
    }

     void ChangeElement(Sprite spriteOnCharacter)
     {
        index = System.Array.IndexOf(spriteArray,spriteOnCharacter);

        if(index == spriteArray.Length - 1){
            spriteRenderer.sprite = spriteArray[0];
        } else {
            spriteRenderer.sprite = spriteArray[index+1];
        } 
    }
}
