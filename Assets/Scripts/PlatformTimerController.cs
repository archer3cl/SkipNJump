using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlatformTimerController : MonoBehaviour {
    public static PlatformTimerController instance = null;
    public bool startPlatformTimer;
    public float platformTimer;
    public float currentPlatformTimer;
    public Text platformTimerText;
    private CanvasRenderer canvasRenderer;


    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        platformTimer = 2f;
        currentPlatformTimer = platformTimer;
        canvasRenderer = GetComponent<CanvasRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (startPlatformTimer) {            
            currentPlatformTimer -= Time.deltaTime;
            platformTimerText.text = currentPlatformTimer.ToString("00.00");
            if (currentPlatformTimer <= 0) {
                ResetCounter();
                Debug.Log("Game Over");
                GameController.instance.ResetGame();
            }
        }
    }

    public void ResetCounter() {
        SwitchVisibility();                 
        startPlatformTimer = false;
        currentPlatformTimer = platformTimer;
        platformTimerText.text = "00.00";
    }

    public void SwitchVisibility() {
        if (canvasRenderer.GetAlpha() != 0) {
            canvasRenderer.SetAlpha(0);
        } else {
            canvasRenderer.SetAlpha(1);
        }        
    }
}
