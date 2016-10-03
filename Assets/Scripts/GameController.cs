using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public static GameController instance = null;
    public DeathMenu deathMenu;
    public PlayerController player;

    private Vector3 platformGeneratorStartPoint;
    private Vector3 playerStartPoint;
    private PauseMenu pauseButton;
    private PlatformDestroyer[] platformList;
    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        PlatformsController.instance.InitializePlatforms();
        //platformGeneratorStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;   
        pauseButton = FindObjectOfType<PauseMenu>();
    }
	
	public void ResetGame() {
        //deathMenu.gameObject.SetActive(false);
        //platformList = FindObjectsOfType<PlatformDestroyer>();
        //foreach (var platform in platformList) {
        //    platform.gameObject.SetActive(false);
        //}
        //player.transform.position = playerStartPoint;
        ////platformGenerator.position = platformGeneratorStartPoint;
        //player.gameObject.SetActive(true);
        //ScoreController.instance.scoreCount = 0;        
        ////pauseButton.gameObject.SetActive(true);
    }
}
