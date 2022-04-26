using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShadowerHandler : MonoBehaviour
{
    public Camera cam;
    [Range (0,1)]
    public float speed = 0.01f;
    private bool isZoomed;
    private  Tilemap tilemap;
    [SerializeField]private Color tempColor;
    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        
    }

    void LateUpdate()
    {
        tempColor = tilemap.color;
        
        if(isZoomed)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,4,speed);
            tempColor.a = Mathf.Lerp(tempColor.a,0,speed*3);
;            
        } else 
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,8,speed);
            tempColor.a = Mathf.Lerp(tempColor.a,10,speed);
        }
        tilemap.color = tempColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            isZoomed = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isZoomed = false;
        }
    }

}
