using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {    
    public bool isOnPlatform;
    public float jumpSpeed;
    
    // Use this for initialization
    void Start() {
        isOnPlatform = true;        
    }

    // Update is called once per frame
    void Update() {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.A) && isOnPlatform) {            
            if (IsCorrectInput(Platform.Color.Blue)) {
                MovePlayer();
            } else {
                LoseLife();
            }
        } else if (Input.GetKeyDown(KeyCode.S) && isOnPlatform) {
            if (IsCorrectInput(Platform.Color.Red)) {
                MovePlayer();
            } else {
                LoseLife();
            }
        } else if (Input.GetKeyDown(KeyCode.D) && isOnPlatform) {
            if (IsCorrectInput(Platform.Color.Yellow)) {
                MovePlayer();
            } else {
                LoseLife();
            }
        } else if (Input.GetKeyDown(KeyCode.F) && isOnPlatform) {
            if (IsCorrectInput(Platform.Color.Green)) {
                MovePlayer();
            } else {
                LoseLife();
            }
        }
#elif UNITY_ANDROID

#endif
        if (!LeanTween.isTweening(gameObject)) {
            isOnPlatform = true;
        }
    }

    private void MovePlayer() {
        isOnPlatform = false;
        GameObject currentPlatform = PlatformsController.instance.generatedPlatforms[0];
        GameObject nextPlatform = PlatformsController.instance.generatedPlatforms[1];
        LeanTween.move(gameObject, new Vector3[] { transform.position, new Vector3(nextPlatform.transform.position.x, 2f, 0f), new Vector3(currentPlatform.transform.position.x, 2f, 0f), nextPlatform.transform.position + new Vector3(0f, 0.76f, 0f) }, jumpSpeed);
        PlatformsController.instance.UpdatePlatforms();
        ScoreController.instance.UpdateScore(nextPlatform.GetComponent<Platform>().scoreValue);
    }

    private bool IsCorrectInput(Platform.Color input) {
        Platform nextPlatform = PlatformsController.instance.generatedPlatforms[1].GetComponent<Platform>();        
        if (input == nextPlatform.color) {
            return true;
        }
        return false;
    }

    private void LoseLife() {
        LifeController.instance.LoseLife();
    }
}