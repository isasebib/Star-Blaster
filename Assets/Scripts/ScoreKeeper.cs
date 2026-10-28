using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static int score;  

    public void addScore()
    {
        score += 100;
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
