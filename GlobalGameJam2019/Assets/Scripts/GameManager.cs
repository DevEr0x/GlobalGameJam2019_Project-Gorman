using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public EnemyPatrol enemy;
    EnemyPatrol inst;
    public PuzzleManager puzz;
    // Start is called before the first frame update
    void Start()
    {
        puzz = puzz.GetComponent<PuzzleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (puzz.state == PuzzleManager.STATE.BALL)
        //{
        //    SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(2));
        //}
        //else if (puzz.state == PuzzleManager.STATE.MOP)
        //{
        //    SceneManager.LoadScene("Level_03", LoadSceneMode.Additive);
        //}
        //else if (puzz.state == PuzzleManager.STATE.RING)
        //{
        //    SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(4));
        //}
        //else if (puzz.state == PuzzleManager.STATE.HAT)
        //{
        //    SceneManager.SetActiveScene(SceneManager.GetSceneByName("End"));
        //}
    }
}
