using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField]public TextMeshPro ScoreLabel = null;
    public static int scoreValue = 0;
    public int pointsToUp;
    private void Start()
    {
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
