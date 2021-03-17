using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Events : MonoBehaviour
{

    public TMP_InputField playerNameInput;
    public Button confirmPlayerNameBtn;
    public Button skipSavingScoreBtn;
    private static string playerName;
    public static string getPlayerName()
    {
        return playerName;
    }

    public static void SetPlayerName(string _playerName)
    {
        playerName = _playerName;
    }
    public void OnConfirmPlayerNameBtnClick()
    {
        Events.SetPlayerName(this.playerNameInput.text);
        Highscore.isScoreAlreadyAdded = false;
        SceneManager.LoadScene(10);
    }

    public void OnSkipBtnClick()
    {
        Highscore.isScoreAlreadyAdded = true;
        SceneManager.LoadScene(0);
    }


    public void HighscoreTable()
    {

        SceneManager.LoadScene("HighScore", LoadSceneMode.Additive);
    }
}
