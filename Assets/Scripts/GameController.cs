using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public static GameController instance = null;    
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
