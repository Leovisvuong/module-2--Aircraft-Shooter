using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour
{
    float speed = 4f;
    void Update()
    {
        transform.position = transform.position + new Vector3(0,-speed*Time.deltaTime,0);
    }
}
