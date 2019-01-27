using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    bool dragging = false;
    Rigidbody2D drag;
    public PuzzleManager puzzle;

    Vector3 mousePos;

    private void Start()
    {
        puzzle = this.gameObject.GetComponent<PuzzleManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mouse2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Draggable")
                {
                    if (!dragging)
                    {
                        drag = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                        dragging = true;
                        drag.bodyType = RigidbodyType2D.Dynamic;
                    }

                }
                else if (hit.collider.gameObject.tag == "Draggable" && hit.collider.gameObject.name == "Spec")
                {
                    if (!dragging)
                    {
                        drag = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                        dragging = true;
                        drag.bodyType = RigidbodyType2D.Dynamic;
                    }
                }
                else if (hit.collider.gameObject.tag == "PUZZLE")
                {
                    puzzle.puzzle = PuzzleManager.puzzChoice.PUZZLE2;

                }
                else if (hit.collider.gameObject.tag == "KILL")
                {
                    puzzle.puzzle = PuzzleManager.puzzChoice.NONE;

                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (drag.gameObject.name == "Spec")
            {
                dragging = false;
                drag = null;
            }
            else
            {
                dragging = false;
                drag.bodyType = RigidbodyType2D.Kinematic;
                drag = null;
            }
            
        }
        if (dragging)
        {
            //drag.transform.position = ;
            drag.transform.position = Vector2.MoveTowards(drag.transform.position, new Vector2(mousePos.x, mousePos.y), 0.1f);
        }           
    }

   
}
