using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveScoreMenuSelector : VerticalMenuSelector
{

    private readonly string MENU_OPTION_CONFIRM_NAME = "MenuOptionConfirmName";
    private readonly string MENU_OPTION_CANCEL_SAVE = "MenuOptionCancelSave";

  

    /**
     * Before first frame update. 
     */
    private void Start()
    {
     
    }
    void Awake()
    {
        transform.position = GetMenuSelectorPosition();
    }

 

    /**
     * Update per frame.
     */
    void Update()
    {
        // invokes base class up/down arrows handling
        this.HandleUpDownArrowPresses();

        // enter case handling
        if (Input.GetKeyDown(KeyCode.Return)) HandleReturn();
    }

    /**
     * Handles ENTER pressing that allows the user to choose an option.
     */
    private void HandleReturn()
    {
        GameObject currentMenu = this.GetCurrentMenu();

        if (currentMenu.name == this.MENU_OPTION_CONFIRM_NAME)
        {
          /*  SetPlayerName(this.playerNameInput.text);
            Highscore.isScoreAlreadyAdded = false;
            this.sceneLoader.LoadHighscoreScene();*/
        }
        else
        {
            Highscore.isScoreAlreadyAdded = true;
            this.sceneLoader.Quit();
        }
           
    }
}
