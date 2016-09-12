using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    private Transform nextPlatform;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {        
        if (Input.GetKeyDown(KeyCode.Space)) {            
            LeanTween.move(gameObject, new Vector3[] { transform.position, new Vector3(-5f, 0f, 0f), new Vector3(-6f, 0f, 0f), nextPlatform.position + new Vector3(0f, 0.76f, 0f)}, 0.7f);
        }
    }
}