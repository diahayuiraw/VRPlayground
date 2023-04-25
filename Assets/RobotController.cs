using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{

    float x = 0.0f;
    
    public float velocity = 2.0f;


    void Start()
    {
    }

    void Update()
    {

        /*x += velocity * Time.deltaTime;

        transform.position = new Vector3(x, 0.0f, 0.0f);
        
        transform.rotation = Quaternion.Euler(new Vector3(0,0,-30));*/

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider:" + other.gameObject.tag);
    }



}
