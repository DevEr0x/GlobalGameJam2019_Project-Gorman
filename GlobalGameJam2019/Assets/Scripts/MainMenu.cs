﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void playGame(){
        SceneManager.LoadScene("Intro Scene");
    }
    public void skipIntro(){
        SceneManager.LoadScene("Level_01");
    }
    public void quitGame(){
        Application.Quit();
    }
}