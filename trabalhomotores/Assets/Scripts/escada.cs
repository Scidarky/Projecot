using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escada : MonoBehaviour
{
   public bool naEscada;
   private Rigidbody2D rb;

   void Start () {
    rb = GetComponent<Rigidbody2D>();
   }
   
   void Update () {
      if(Input.GetKey(KeyCode.W) && naEscada == true){
         transform.Translate(0,05*Time.deltaTime,0);
      }
   }
   void OnTriggerEnter2D(Collider2D col){
      if(col.gameObject.tag == "Escada"){
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

