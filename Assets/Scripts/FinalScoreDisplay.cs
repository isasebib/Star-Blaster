using TMPro;
using UnityEngine;

public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        text.text = "FINAL SCORE\n" + ScoreKeeper.score.ToString("0000000");
    }
}