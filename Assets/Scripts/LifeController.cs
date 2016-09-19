using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour {
    public static LifeController instance = null;
    public int currentHealth;
    public Image[] heartImages;
    public Sprite[] heartSprites;

    private int maxHeartAmount = 4;
    private int startHearts = 2;
    private int healthPerHearth = 2;
    private int errorDamage = -1;
    private int maxHealth;
    private int healthPerImage;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        currentHealth = startHearts * healthPerHearth;
        maxHealth = maxHeartAmount * healthPerHearth;
        healthPerImage = healthPerHearth / (heartSprites.Length - 1);
        CheckHealthAmount();
	}

    public void LoseLife() {        
        currentHealth += errorDamage;
        currentHealth = Mathf.Clamp(currentHealth, 0, startHearts * healthPerHearth);        
        UpdateHearts();
    }    

    private void CheckHealthAmount() {
        for (int i = 0; i < maxHeartAmount; i++) {
            if (startHearts <= i) {
                heartImages[i].enabled = false;
            } else {
                heartImages[i].enabled = true;
            }
        }
    }

    private void UpdateHearts() {
        bool empty = false;
        int index = 0;
        for (int i = 0; i < heartImages.Length; i++) {
            if (empty) {
                heartImages[i].sprite = heartSprites[0];
            } else {
                index++;
                if (currentHealth >= index * healthPerHearth) {
                    heartImages[i].sprite = heartSprites[heartSprites.Length - 1];
                } else {
                    int currentHeartHealth = (int)(healthPerHearth - (healthPerHearth * index - currentHealth));
                    int imageIndex = currentHeartHealth / healthPerImage;
                    heartImages[i].sprite = heartSprites[imageIndex];
                    empty = true;
                }
            }
        }

    }
}
