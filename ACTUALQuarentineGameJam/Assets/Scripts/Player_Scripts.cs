using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Player_Scripts : MonoBehaviour
{
    #region Singleton

    public static Player_Scripts instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion


    [Header("Movement")]
    Rigidbody2D rigid;
    public float moveSpeed;
    bool facingRight = true;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        rigid.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);       


        if (facingRight && rigid.velocity.x < 0)
        {
            FlipPlayer();
        }
        else if (!facingRight && rigid.velocity.x > 0)
        {
            FlipPlayer();
        }
        if (moveY > 0 )
        {
            anim.setBool("Is_player_facing_up_or_Down", true);
        }

    }

    void FlipPlayer() 
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
    

}
    

 




