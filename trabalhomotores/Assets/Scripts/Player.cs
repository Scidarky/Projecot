using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundheck;
    [SerializeField] private LayerMask groundLayer;

    public float jump = 15f;
    public float speed = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && isGrounded()){
            rb.velocity = new Vector2(rb.velocity.y, jump);
        }

        if (Input.GetKeyUp(KeyCode.J) && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
            float hori = Input.GetAxis("Horizontal") * speed;
            hori *= Time.deltaTime;
            transform.Translate(hori, 0 ,0);
    }

    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundheck.position, 0.2f, groundLayer);
    }
}
