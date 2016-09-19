using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public static ScoreController instance = null;
    public Text scoreText;
    public Text hiScoreText;
    public int scoreCount;
    public int hiScoreCount;


    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {        
        if (PlayerPrefs.HasKey("HighScore")) {
            hiScoreCount = PlayerPrefs.GetInt("HighScore");
            hiScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
    }
	
	public void UpdateScore(int score) {
        scoreCount += score;        
        if (scoreCount > hiScoreCount) {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetInt("HighScore", hiScoreCount);
            hiScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
        scoreText.text = "Score: " + scoreCount;        
    }
}
