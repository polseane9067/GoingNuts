﻿using UnityEngine;
using System.Collections;

public class GoToScript : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject Extras;
    public GameObject ExtrasMenu;
    public GameObject Achievements;
    public GameObject Highscores;
    public GameObject Credits;
    public GameObject CheckReset;
    public GameObject CheckQuit;


    public void mainMenu()
    {
        Application.LoadLevel(0);
    }

    public void menu()
    {
        MainMenu.SetActive(true);
        Extras.SetActive(false);
        CheckQuit.SetActive(false);
    }

    public void loading()
    {
        Application.LoadLevel(3);
    }

    public void mainScore()
    {
        Highscores.SetActive(true);
        ExtrasMenu.SetActive(false);
    }

    public void score()
    {
        Application.LoadLevel(2);
    }

    public void settings()
    {

    }

    public void extras()
    {
        Extras.SetActive(true);
        ExtrasMenu.SetActive(true);
        Achievements.SetActive(false);
        Highscores.SetActive(false);
        Credits.SetActive(false);
        MainMenu.SetActive(false);
    }

    public void credits()
    {
        Credits.SetActive(true);
        ExtrasMenu.SetActive(false);
    }

    public void achievements()
    {
        Achievements.SetActive(true);
        ExtrasMenu.SetActive(false);
        CheckReset.SetActive(false);
    }

    public void play()
    {
        Application.LoadLevel(1);
    }

    public void checkQuit()
    {
        CheckQuit.SetActive(true);
    }

    public void checkReset()
    {
        CheckReset.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }
}
