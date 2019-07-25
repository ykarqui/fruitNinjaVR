using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Life : MonoBehaviour
{
    [SerializeField]public TextMeshPro LifeLabel = null;
    public static int lifeValue;
    private void Start()
    {
        lifeValue = 3;
        LifeLabel.text = "Lifes: " + lifeValue;
    }
    
    private void Update()
    {
        if (lifeValue <= 0)
        {
            PlayerPrefs.SetInt("currentscore", Score.scoreValue);
            SceneManager.LoadScene(4);
        }
        LifeLabel.text = "Lifes: " + lifeValue;
    }
}