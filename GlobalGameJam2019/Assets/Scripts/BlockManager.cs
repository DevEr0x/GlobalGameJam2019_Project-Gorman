using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    bool dragging = false;
    Transform drag;
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
                        drag = hit.collider.gameObject.GetComponent<Transform>();
                        dragging = true;
                    }

                }
                else if (hit.collider.gameObject.tag == "PUZZLE")
                {
                    puzzle.puzzle = PuzzleManager.puzzChoice.PUZZLE1;

                }
                else if (hit.collider.gameObject.tag == "KILL")
                {
                    puzzle.puzzle = PuzzleManager.puzzChoice.NONE;

                }
                else if (hit.collider.gameObject.tag == "Ball")
                {
                    puzzle.PuzzleCheck(puzzle.pieces,puzzle.curPuzzPieces);

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
