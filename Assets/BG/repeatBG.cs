using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatBG : MonoBehaviour
{
    Vector3 startPosition;
    float repeatHeight;
    void Start(){
        startPosition = transform.position;
        repeatHeight = GetComponent<BoxCollider2D>().size.y/2;
    }
    void Update()
    {
        if(transform.position.y < startPosition.y - repeatHeight){
            transform.position = startPosition;
        }
    }
}
