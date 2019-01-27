using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneScript : MonoBehaviour
{

    public bool ending = false;

    private void Update()
    {
        if (DialougeManager.inConversation == false)
        {
            if (GameManager.firstDone)
            {
                SceneManager.LoadScene("Level_02");
            }
        }
    }
}
