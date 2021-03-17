using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // config
    [SerializeField] public TextMeshProUGUI playerScoreText;
    [SerializeField] public TextMeshProUGUI gameLevelText;
    [SerializeField] public TextMeshProUGUI playerLivesText;


    // state
    private static GameSession _instance;
    public static GameSession Instance => _instance;

    public int GameLevel { get; set; }
    public static int PlayerScore { get; set; }
    public int PlayerLives { get; set; }
    public int PointsPerBlock { get; set; }
    public float GameSpeed { get; set; }


    private static string playerName;


    /**
     * Singleton implementation.
     */
    private void Awake() 
    { 
        // this is not the first instance so destroy it!
        if (_instance != null && _instance != this)
        { 
            Destroy(this.gameObject);
            return;
        }
        
        // first instance should be kept and do NOT destroy it on load
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    /**
     * Before first frame.
     */
    void Start()
    {
        playerScoreText.text = PlayerScore.ToString();
        gameLevelText.text = this.GameLevel.ToString();
        playerLivesText.text = this.PlayerLives.ToString();
    }

    /**
     * Update per-frame.
     */
    void Update()
    {
        Time.timeScale = this.GameSpeed;
        
        // UI updates
        playerScoreText.text = PlayerScore.ToString();
        gameLevelText.text = this.GameLevel.ToString();
        playerLivesText.text = this.PlayerLives.ToString();
    }

    /**
     * Updates player score with given points and also updates the UI score. The total points that are
     * calculated is based on the basis value (this.PointsPerBlock).
     */
    public void AddToPlayerScore(int blockMaxHits)
    {
        PlayerScore += blockMaxHits * this.PointsPerBlock;
        playerScoreText.text = PlayerScore.ToString();
    }
}
