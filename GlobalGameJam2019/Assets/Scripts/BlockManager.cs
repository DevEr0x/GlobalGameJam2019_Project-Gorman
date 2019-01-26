using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    bool dragging = false;
    Rigidbody2D drag;

    Vector3 mousePos;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Click");
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mouse2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "Draggable")
                {
                    if (!dragging)
                    {
                        drag = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                        dragging = true;
                    }

                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            drag = null;
        }
        if (dragging)
        {
            drag.transform.position = new Vector2(mousePos.x, mousePos.y);
        }
    }
}
