using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHandler : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    private SpriteRenderer spriteRenderer;
    private int elemetalPower = 0;
    public Sprite[] elementSpriteArray = new Sprite[3];
    [SerializeField] private GameObject[] projPrefab = new GameObject[3];
    private Collider2D coll;
    [SerializeField] private float cooldownTime;
    private float lastAbilityTime;
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
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

        if(Input.GetButtonDown("Fire2")){
            HandleElementalSkill();
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

    void HandleElementalSkill()
    {
        //Общий кулдаун для всех способностей, можно задавать в инспекторе. Если еще куладун то выходим из метода
        if(Time.time - lastAbilityTime < cooldownTime)
            return;
        //Задаем время последнего использования, чтобы начать отсчет куладуна
        lastAbilityTime = Time.time;

        switch(elemetalPower)
        {
            case 0:
                DoArcaneTeleport();
                break;

            case 1:

                break;

            case 2:

                break;

        }
    }

    void DoArcaneTeleport()
    {
        Vector2 startPosition;
        float travelDistance = 3f;

        startPosition = transform.position;
        //Луч проверяет есть ли впреди земля, если не проверть то телепортирует в текстуры
        RaycastHit2D raycastHit2D = Physics2D.Raycast(startPosition,transform.right,travelDistance,LayerMask.GetMask("Ground"));
        //Проверяем какая дистанция до земли? Она должна быть больше чем пол тела игрока и меньше чем максимальная дистанция телепорта
        if(raycastHit2D.distance > coll.bounds.size.x/2 && raycastHit2D.distance <= travelDistance){
            travelDistance = raycastHit2D.distance - (coll.bounds.size.x/1.9f);  //Выставляем дистанцию телепорта на растояние до земли
        } 
        if (raycastHit2D.distance == 0 || raycastHit2D.distance > 0.5){
            if(transform.rotation.eulerAngles.y == 0)
                transform.Translate(transform.right*travelDistance); //Телепорт в право
            else if(transform.rotation.eulerAngles.y == 180)
                transform.Translate(transform.right * -travelDistance); //Телепорт в лево
        }
    }
}
