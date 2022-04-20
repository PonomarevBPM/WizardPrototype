using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHandler : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    private SpriteRenderer spriteRenderer;
    private int elemetalPower = 0;
    [HideInInspector] public bool isFire, isWater, isArcane;
    public Sprite[] elementSpriteArray = new Sprite[3];
    [SerializeField] private GameObject[] projPrefab = new GameObject[3];
    void Start()
    {
        isArcane = true;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

   
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            //Спавним снаряд нужного элемента из spawnPoint в напрвлении как сам spawnpoint
            Instantiate(projPrefab[elemetalPower],spawnPoint.position,spawnPoint.rotation);
        }

        if (Input.GetButtonDown("Fire3")){
            ChangeElement(spriteRenderer.sprite);
        }
    }
    //Меняем элементы по очереди
     void ChangeElement(Sprite spriteOnCharacter)
     {
         //Находим индекс спрайта в массиве спрайтов
        elemetalPower = System.Array.IndexOf(elementSpriteArray,spriteOnCharacter);
        // Если индекс последнего элемента, то меняем на первый
        if(elemetalPower == elementSpriteArray.Length - 1){
            elemetalPower = 0;
        } else {
            //Если индекс не последний, то меняем на следующий
            elemetalPower++;
        } //Меняем спрайт игрока на спрайт следующего элемента
        spriteRenderer.sprite = elementSpriteArray[elemetalPower];
    }
}
