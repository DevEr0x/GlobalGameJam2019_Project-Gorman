using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D player;


    Animator anim;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (Input.GetAxis("Horizontal") > 0) {
            anim.SetBool("isFacingRight", true);
            anim.SetBool("isFacingUp", false);
            anim.SetBool("isFacingDown", false);
            anim.SetBool("isFacingLeft", false);

            Vector3 temp = player.velocity;
            temp.x = 2*speed;
            player.velocity = temp;
           
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("isFacingRight", false);
            anim.SetBool("isFacingUp", false);
            anim.SetBool("isFacingDown", false);
            anim.SetBool("isFacingLeft", true);
            Vector3 temp = player.velocity;
            temp.x = -2*speed;
            player.velocity = temp;

        }
        if (Input.GetAxis("Vertical") > 0)
        {
            anim.SetBool("isFacingRight", false);
            anim.SetBool("isFacingUp", true);
            anim.SetBool("isFacingDown", false);
            anim.SetBool("isFacingLeft", false);
            Vector3 temp = player.velocity;
            temp.y = 2*speed;
            player.velocity = temp;

        }
        if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetBool("isFacingRight", false);
            anim.SetBool("isFacingUp", false);
            anim.SetBool("isFacingDown", true);
            anim.SetBool("isFacingLeft", false);
            Vector3 temp = player.velocity;
            temp.y = -2*speed;
            player.velocity = temp;

        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            Vector3 temp = player.velocity;
            temp.x = 0;
            player.velocity = temp;


        }
        if (Input.GetAxis("Vertical") == 0)
        {
            Vector3 temp = player.velocity;
            temp.y = 0;
            player.velocity = temp;

        }
        if(player.velocity.x != 0 || player.velocity.y != 0)
        {
            anim.SetBool("isWalking", true);
        }
        if (player.velocity.x == 0 && player.velocity.y == 0)
        {
            anim.SetBool("isWalking", false);
        }
        
    }


}