using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Вызываем метод-убийцу через 5 сек
        Invoke("DestroyInFiveSecons", 5);
    }

    
    void Update()
    {
        //Скорость = вправо со скростью speed
        rb.velocity = transform.right * speed * Time.deltaTime;
    }

// Когда триггер дотрагивается до какого-либо коллайдера
    void OnTriggerEnter2D (Collider2D other){
        // Если это враг, то мы уничтожаем сам снаряд и врага
        if(other.CompareTag("Enemy")){
        Destroy(gameObject);
        Destroy(other.gameObject);
        }//Если это земля, то уничтожаем только снаряд
         else if (other.CompareTag("Ground") || other.CompareTag("IceSpikes")){ 
            Destroy(gameObject);
        }
    }

// У него же могут быть дети!!!
    void DestroyInFiveSecons(){
        Destroy(gameObject);
    }
}
