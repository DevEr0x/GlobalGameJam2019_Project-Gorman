using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;

    public Animator anim;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += (move * speed * Time.deltaTime);

        if(move.x > 0){
            anim.SetBool("facingRight", true);
            anim.SetBool("facingLeft", false);
            anim.SetBool("facingUp", false);
            anim.SetBool("facingDown", false);
            anim.SetBool("isMoving", true);
        }
        else if(move.x < 0){
            anim.SetBool("facingRight", false);
            anim.SetBool("facingLeft", true);
            anim.SetBool("facingUp", false);
            anim.SetBool("facingDown", false);
            anim.SetBool("isMoving", true);
        }
        else if(move.y > 0){
            anim.SetBool("facingRight", false);
            anim.SetBool("facingLeft", false);
            anim.SetBool("facingUp", true);
            anim.SetBool("facingDown", false);
            anim.SetBool("isMoving", true);
        } else if (move.y < 0){
            anim.SetBool("facingRight", false);
            anim.SetBool("facingLeft", false);
            anim.SetBool("facingUp", false);
            anim.SetBool("facingDown", true);
            anim.SetBool("isMoving", true);
        }

        if(move.x == 0 && move.y == 0)
        {
            anim.SetBool("isMoving", false);
        }
        


    }


}