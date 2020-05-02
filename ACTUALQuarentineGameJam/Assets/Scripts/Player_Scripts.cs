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
    public Animator anim;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        rigid.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        anim.SetFloat("Horizontal", moveX);
        anim.SetFloat("Vertical", moveY);
        anim.SetFloat("Speed", rigid.velocity.sqrMagnitude);       
    }   
}
