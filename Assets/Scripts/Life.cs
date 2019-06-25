using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Life : MonoBehaviour
{
    [SerializeField]public TextMeshPro LifeLabel = null;
    public static int lifeValue = 3;
    private void Start()
    {
        LifeLabel.text = "Lifes: " + lifeValue;
    }
    
    private void Update()
    {
        if (lifeValue <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        LifeLabel.text = "Lifes: " + lifeValue;
    }
}