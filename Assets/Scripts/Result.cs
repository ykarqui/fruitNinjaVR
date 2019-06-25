using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] public Text LifeLabel = null;
    private void Start()
    {
        LifeLabel.text = "Result: " + Score.scoreValue;
    }
}