using UnityEngine;
using System.Collections;

public class PlatformsController : MonoBehaviour {
    public ObjectPooler[] platformsPoolers;
    public Transform creationPoint;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InitializePlatforms() {        
        for (int i = 0; i < platformsPoolers.Length; i++) {            
            int platformSelector = Random.Range(0, platformsPoolers.Length);                        
            InstantiatePlatform(platformSelector);
        }        
    }


    private void InstantiatePlatform(int platformSelector) {        
        GameObject newPlatform = platformsPoolers[platformSelector].GetPooledObject();        
        newPlatform.transform.position = creationPoint.position;
        newPlatform.transform.rotation = creationPoint.rotation;
        newPlatform.SetActive(true);
        creationPoint.position = new Vector3(creationPoint.position.x + newPlatform.GetComponent<Renderer>().bounds.size.x * 3, creationPoint.position.y, creationPoint.position.z);
    }
}
