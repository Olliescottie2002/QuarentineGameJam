using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Player_Scripts : MonoBehaviour
{
    Rigidbody2D rigid;
    bool facingRight = true;
    bool canJump = true;
    public Transform startpos, endpos;
    public LayerMask groundLayer;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(move * 5f, rigid.velocity.y);


        RaycastHit2D hit = Physics2D.Linecast(startpos.position, endpos.position, groundLayer.value);

        if (hit.collider != null)
        {
            canJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rigid.velocity = Vector2.up * 10f;
            canJump = false;
        }

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
    

 




