using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] Health playerHealth;
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        hpSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        scoreText.text = ScoreKeeper.score.ToString("0000000");

        if (playerHealth != null && playerHealth.GetHealth() > 0)
            hpSlider.value = playerHealth.GetHealth();
    }
}