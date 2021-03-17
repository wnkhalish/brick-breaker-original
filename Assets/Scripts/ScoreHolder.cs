using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreHolder : MonoBehaviour
{  
    [SerializeField] public TextMeshProUGUI finalScoreText;
        [SerializeField] public TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    void Awake()
    {
      
    
        finalScoreText.text = GameSession.PlayerScore.ToString();
        int bestScore = PlayerPrefs.GetInt("BestScoreDisplay", 0);
        if (GameSession.PlayerScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScoreDisplay", GameSession.PlayerScore);
        }
        bestScoreText.text = PlayerPrefs.GetInt("BestScoreDisplay", 0).ToString();
    
}

  
}
