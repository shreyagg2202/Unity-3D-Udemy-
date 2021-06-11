using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;

    public void IncreaseScore(int amountToIncrese)
    {
        score += amountToIncrese;
        Debug.Log($"Score is now {score}");
    }
}
