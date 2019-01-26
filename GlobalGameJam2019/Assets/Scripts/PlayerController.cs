﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;

    public float speed;
    bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        transform.position += (move * speed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse2D = new Vector2(mousePos.x,mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mouse2D,Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "Draggable")
                {
                    if (!dragging)
                    {
                        Rigidbody2D drag = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                        drag.transform.position = new Vector2(mousePos.x, mousePos.y);
                        dragging = true;
                    }
                    else
                    {

                    }
                    
                }
            }
        }
    }


}
