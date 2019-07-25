using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField]public TextMeshPro ScoreLabel = null;
    public static int scoreValue;
    public int pointsToUp;
    private void Start()
    {
        scoreValue = 0;
        ScoreLabel.text = "Score: " + scoreValue;
    }
    
    private void Update()
    {
        ScoreLabel.text = "Score: " + scoreValue;
        if (scoreValue >= pointsToUp)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
