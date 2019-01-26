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

        if(Input.GetKeyDown(KeyCode.RightArrow)){ //Moving right
            anim.SetBool("facingRight", true);
            anim.SetBool("facingLeft", false);
            anim.SetBool("facingUp", false);
            anim.SetBool("facingDown", false);
            anim.SetBool("isMoving", true);
        }
         if(Input.GetKeyDown(KeyCode.LeftArrow)){ //Moving Left
            anim.SetBool("facingRight", false);
            anim.SetBool("facingLeft", true);
            anim.SetBool("facingUp", false);
            anim.SetBool("facingDown", false);
            anim.SetBool("isMoving", true);
        }
         if(Input.GetKeyDown(KeyCode.UpArrow)){ //Moving Up
            anim.SetBool("facingRight", false);
            anim.SetBool("facingLeft", false);
            anim.SetBool("facingUp", true);
            anim.SetBool("facingDown", false);
            anim.SetBool("isMoving", true);
        } if (Input.GetKeyDown(KeyCode.DownArrow)){ //Moving Down
            anim.SetBool("facingRight", false);
            anim.SetBool("facingLeft", false);
            anim.SetBool("facingUp", false);
            anim.SetBool("facingDown", true);
            anim.SetBool("isMoving", true);
        }else{
            anim.SetBool("isMoving", false);
        }
        


    }


}