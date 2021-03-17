using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class MenuSelector : VerticalMenuSelector
{
  
    private readonly string MENU_OPTION_START = "MenuOptionStart";
    private readonly string MENU_OPTION_INSTRUCTIONS = "MenuOptionInstructions";
    private readonly string MENU_OPTION_OPTIONS = "MenuOptionOptions";
    private readonly string MENU_OPTION_HIGHSCORE = "MenuOptionHighscore";
  
    void Start()
    {
        transform.position = GetMenuSelectorPosition();
    }

  
    void Update()
    {
  
        this.HandleUpDownArrowPresses();
        
  
        if (Input.GetKeyDown(KeyCode.Return)) HandleReturn();
    }
    
    /**
     * Handles ENTER pressing that allows the user to choose an option.
     */
    private void HandleReturn()
    {
        var currentMenu = this.GetCurrentMenu();

        if (currentMenu.name == MENU_OPTION_START) 
            this.sceneLoader.LoadSceneByName("Level1");
        
       /* else if (currentMenu.name == MENU_OPTION_INSTRUCTIONS) 
            this.sceneLoader.LoadSceneByName("InstructionsMenu");*/
        
        else if (currentMenu.name == MENU_OPTION_OPTIONS) 
            this.sceneLoader.LoadSceneByName("OptionsMenu");

        else if (currentMenu.name == MENU_OPTION_HIGHSCORE)
            this.sceneLoader.LoadSceneByName("Highscores");
        else 
            this.sceneLoader.Quit();
    }
}
