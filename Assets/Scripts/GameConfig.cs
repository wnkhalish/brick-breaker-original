﻿using System;
using System.Collections.Generic;
using System.Linq;

public class GameConfig
{

    public static readonly string[] AllowedGameModes = {"easy", "normal", "hard", "Insane"};
    public string GameMode
    {
        get => _gameMode;
        set
        {
            if (!AllowedGameModes.Contains(value))
                throw new Exception("Unexpected Game Mode!");
            
            _gameMode = value;
        }
    }
    private string _gameMode = "normal";
    
    // singleton
    private static readonly object padlock = new object();
    private static GameConfig _instance = null;
    public static GameConfig Instance
    {
        get
        {
            lock (padlock)
            {
                if (_instance == null)
                    _instance = new GameConfig();

                return _instance;
            }
        }
    }

    /**
     * Singleton implementation -- private constructor.
     */
    private GameConfig()
    {
        
    }
    
    /**
     * Returns the game mode variables based on the current difficulty.
     */
    public Dictionary<string, object> GetGameModeConfig()
    {
        var gameModeConfig = new Dictionary<string, object>();
        
        if(this._gameMode == "easy")
        {
            gameModeConfig.Add("playerLives", 10);
            gameModeConfig.Add("gameSpeed", 0.1f);
            gameModeConfig.Add("pointsPerBlock", 30);
        }
        else if (this._gameMode == "normal")
        {
            gameModeConfig.Add("playerLives", 5);
            gameModeConfig.Add("gameSpeed", 0.6f);
            gameModeConfig.Add("pointsPerBlock", 50);
        }
        else if (this._gameMode == "hard")
        {
            gameModeConfig.Add("playerLives", 4);
            gameModeConfig.Add("gameSpeed", 0.8f);
            gameModeConfig.Add("pointsPerBlock", 100);
        }
        else if (this._gameMode == "insane")
        {
            gameModeConfig.Add("playerLives", 3);
            gameModeConfig.Add("gameSpeed", 1.2f);
            gameModeConfig.Add("pointsPerBlock", 300);
        }
        else
        {
            gameModeConfig.Add("playerLives", 1);
            gameModeConfig.Add("gameSpeed", 1.4f);
            gameModeConfig.Add("pointsPerBlock", 500);
            
        }

        // regardless of the game play mode 
        gameModeConfig.Add("playerScore", 0);
        
        // initial level
        gameModeConfig.Add("gameLevel", 1);
        
        return gameModeConfig;
    }
}
