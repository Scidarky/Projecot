using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public bool inside = false;
    public float speed = -0.005f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(speed, 0 ,0);

        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "wait!") {
            speed = 0.005f;
            inside = true;
        }
    }
}
