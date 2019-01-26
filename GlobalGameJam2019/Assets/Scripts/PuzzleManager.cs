using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzles;
    public List<GameObject> curPuzzPieces;
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
                    PuzzleRand(curPuzzPieces);
                }
                
                break;
            case puzzChoice.NONE:
                foreach (Transform c in puzzSpawn.transform)
                {
                    GameObject.Destroy(c.gameObject);
                }
                foreach (GameObject g in curPuzzPieces)
                {
                    curPuzzPieces.Remove(g);
                }
                spawned = false;
                break;
        }
    }
    public void PuzzleADD(GameObject _puzzle)
    {
        Transform pieces = _puzzle.transform.Find("Pieces");
        foreach (Transform c in pieces)
        {
            curPuzzPieces.Add(c.gameObject);
        }
    }
    public void PuzzleRand(List<GameObject> _puzzle)
    {
        Debug.Log("Randomizing");
        foreach (GameObject c in _puzzle)
        {
            float randOffsetX = Random.Range(-3,4);
            float randOffsetY = Random.Range(-1.5f,0.5f);
            Vector3 v = new Vector3(randOffsetX,randOffsetY);
            c.transform.position += v;
        }
    }
    public void PuzzleCheck(GameObject _puzzle,List<GameObject> _pieces)
    {
        Transform pieces = _puzzle.transform.Find("Pieces");
        
        foreach (Transform t in pieces)
        {
            foreach (GameObject g in _pieces)
            {
                if (g.transform.position.x == t.position.x && g.transform.position.y == t.position.y)
                {
                    g.SetActive(false);
                }
            }
        }
    }
    
}
