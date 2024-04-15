using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float Movespeed = 600;
    private Rigidbody2D rb;
 


    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
    }

 
  
    private void FixedUpdate()
    {
      Movement();
    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        bool move = moveHorizontal != 0 || moveVertical != 0;

        if (move)
        {
          Vector2 movedir = new Vector2(moveHorizontal,moveVertical/1.3f);
          rb.AddForce(movedir * Movespeed);
        }
    }

     
}    
