using GridLab.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("UI Options")]
    [SerializeField]
    private float offsetPositionFromPlayer = 1.0f;//How far from camera

    [SerializeField]
    private GameObject menuContainer; //Canvas with a couple of buttons

    private const string GAME_SCENE_NAME = "CabinEscape"; //Allows us to restart the game.


    [Header("Events")]
    public Action onGameResumeActionExecuted; //Notifies the GameManager to update class
    //Referencing the Menu.cs script
    private Menu menu;

    //bind menu buttons
    public void Awake()
    {
        menu = GetComponentInChildren<Menu>(true);//Add true in case any part of the menu is hidden at the beginning 

        menu.ResumeButton.onClick.AddListener(() =>
        {
            HandleMenuOptions(GameState.Playing);
            onGameResumeActionExecuted?.Invoke();
        });

        menu.RestartButton.onClick.AddListener(() =>
        {
           SceneManager.LoadScene(GAME_SCENE_NAME);
            onGameResumeActionExecuted?.Invoke();
        });


    }

    private void OnEnabled()
    {
        //TODO - Need to add listener for Game Manager changes
    }
    private void OnDisable()
    {
        //TODO - Need to add listener for Game Manager changes
    }

    private void HandleMenuOptions(GameState gameState)
    {
        if (gameState == GameState.Paused)
        {
            menuContainer.SetActive(true);
            //PlaceMenuInFrontOfPlayer();
        }
        else if (gameState == GameState.PuzzleSolved)
        {
            menuContainer.SetActive(true);
            menu.ResumeButton.gameObject.SetActive(true);
            menu.SolvedText.gameObject.SetActive(true);
            //PlaceMenuInFrontOfPlayer();

        } 
        else
        {
            menuContainer.SetActive(false);//This is essentially the Playing
        }
         
            
    }
}
