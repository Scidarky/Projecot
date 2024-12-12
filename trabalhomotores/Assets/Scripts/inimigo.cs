using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public bool inside = false;
    public bool inside2 = false;
    public float speed = -0.005f;
    private Rigidbody2D rb;

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

        if(col.gameObject.tag == "jump!") {
            rb.velocity = new Vector2(rb.velocity.x, 5f);
            inside2 = true;
        }
    }
}
