using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int score = 0;
    public static ScoreController Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void AddScore(int points)
    {
        score += points;
    }

    public void RemoveScore(int points) { 
        score -= points;
    }

}
