using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]public TextMeshPro ScoreLabel = null;
    public static int scoreValue = 0;
    private void Start()
    {
        ScoreLabel.text = "Score: " + scoreValue;
    }
    
    private void Update()
    {
        ScoreLabel.text = "Score: " + scoreValue;
    }
}
