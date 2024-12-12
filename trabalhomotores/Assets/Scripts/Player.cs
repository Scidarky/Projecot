using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundheck;
    [SerializeField] private LayerMask groundLayer;

    public float jump = 15f;
    public float speed = 5f;
    public bool naEscada;
    public bool notMoving;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && isGrounded() && !naEscada){
            rb.velocity = new Vector2(rb.velocity.y, jump);
        }

        if (Input.GetKeyUp(KeyCode.J) && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.25f);
        }

        falling();
    }

    private void FixedUpdate()
    {
            float hori = Input.GetAxis("Horizontal") * speed;
            hori *= Time.deltaTime;
            transform.Translate(hori, 0 ,0);

            if(Input.GetKey(KeyCode.W) && naEscada == true){
                transform.Translate(0,05*Time.deltaTime,0);
            }
    }

    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundheck.position, 0.2f, groundLayer);
    }

    void falling(){
        if (rb.velocity.y == 0f){
        notMoving = true;
        }
        else if (rb.velocity.y > 0f){
            notMoving = false;
        }
    }
    

   void OnTriggerEnter2D(Collider2D col){
      if(col.gameObject.tag == "Escada" && notMoving){
         naEscada = true;
        rb.gravityScale = 0;
      }
   }
   void OnTriggerExit2D(Collider2D col){
      if(col.gameObject.tag == "Escada"){
            naEscada = false;
            rb.gravityScale = 1;
         }
      }

}
