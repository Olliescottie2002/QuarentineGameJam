using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Player_Scripts : MonoBehaviour
{
    Rigidbody2D rigid;
    bool facingRight = true;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(move * 5f, rigid.velocity.y);       


        if (facingRight && rigid.velocity.x < 0)
        {
            FlipPlayer();
        }
        else if (!facingRight && rigid.velocity.x > 0)
        {
            FlipPlayer();
        }

    }

    void FlipPlayer() 
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
    

 




