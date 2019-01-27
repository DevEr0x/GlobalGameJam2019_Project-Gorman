using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    private bool pushed = false;
    public void buttonPushed(){
        pushed = true;
    }
    private void Update(){
        if(DialougeManager.inConversation == false){
            if(pushed == true) {
                if (SceneManager.GetActiveScene().name == "Conclusion")
                {
                    Debug.Log("yes");
                    Application.Quit();
                }
                pushed = false;
                SceneManager.LoadScene("Level_01");
            }

        }
    }
}
