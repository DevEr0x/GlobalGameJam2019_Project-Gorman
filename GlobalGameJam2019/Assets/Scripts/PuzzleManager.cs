using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzles;
    public GameObject puzzSpawn;
    public GameObject pieces;
    bool spawned = false;
    public enum puzzChoice
    {
        NONE,
        PUZZLE1,
        PUZZLE2,
        PUZZLE3
    }
    public puzzChoice puzzle;
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    private void Update()
    {
        switch (puzzle)
        {
            case puzzChoice.PUZZLE1:
                if(!spawned){
                    spawned = true;
                    pieces = Instantiate(puzzles[0], puzzSpawn.transform.position, Quaternion.identity, puzzSpawn.transform);
                    PuzzleADD(pieces);
                }
                PuzzleCheck(puzzles[0],pieces);
                break;
            case puzzChoice.PUZZLE2:
                if (!spawned)
                {
                    spawned = true;
                    pieces = Instantiate(puzzles[1], puzzSpawn.transform.position, Quaternion.identity, puzzSpawn.transform);
                    PuzzleADD(pieces);
                }
                PuzzleCheck(puzzles[1], pieces);
                break;
            case puzzChoice.NONE:
                foreach (Transform c in puzzSpawn.transform)
                {
                    GameObject.Destroy(c.gameObject);
                }
                spawned = false;
                break;
        }
    }
    public void PuzzleADD(GameObject _puzzle)
    {
        Transform pices = _puzzle.transform.Find("Pieces");
        foreach (Transform c in pices)
        {
            float randOffsetX = Random.Range(-3, 4);
            float randOffsetY = Random.Range(-1.5f, 0.5f);
            Vector3 v = new Vector3(randOffsetX, randOffsetY);
            c.transform.position += v;
            
        }
    }
    public void PuzzleCheck(GameObject _corPuzzle,GameObject _curPieces)
    {
        bool breakout = false;
        
        for (int i = 0;i<16;i++)
        {
            Transform pices = _corPuzzle.transform.Find("Pieces");
            Transform pces = _curPieces.transform.Find("Pieces");

            Transform c = pices.transform.GetChild(i);
            Transform h = pces.transform.GetChild(i);
            float a = Mathf.Abs(c.position.x - h.position.x);
            float b = Mathf.Abs(c.position.y - h.position.y);
            float distance = Mathf.Sqrt(a * a + b * b);
            if (distance > 2)
            {
                breakout = true;
                break;
            }
        }
        if (breakout == false)
        {
            Debug.Log("Correct");
        }

        
    }
    
}
