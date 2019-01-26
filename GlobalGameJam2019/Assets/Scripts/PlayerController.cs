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
            anim.SetBool("isFacingRight", true);
            anim.SetBool("isFacingLeft", false);
            anim.SetBool("isFacingUp", false);
            anim.SetBool("isFacingDown", false);
            anim.SetBool("isWalking", true);
        }
         if(Input.GetKeyDown(KeyCode.LeftArrow)){ //Moving Left
            anim.SetBool("isFacingRight", false);
            anim.SetBool("isFacingLeft", true);
            anim.SetBool("isFacingUp", false);
            anim.SetBool("isFacingDown", false);
            anim.SetBool("isWalking", true);
        }
         if(Input.GetKeyDown(KeyCode.UpArrow)){ //Moving Up
            anim.SetBool("isFacingRight", false);
            anim.SetBool("isFacingLeft", false);
            anim.SetBool("isFacingUp", true);
            anim.SetBool("isFacingDown", false);
            anim.SetBool("isWalking", true);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){ //Moving Down
            anim.SetBool("isFacingRight", false);
            anim.SetBool("isFacingLeft", false);
            anim.SetBool("isFacingUp", false);
            anim.SetBool("isFacingDown", true);
            anim.SetBool("isWalking", true);
        }else{
            anim.SetBool("isWalking", false);
        }
        


    }


}