using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DefaultNamespace 
{
    public class ComboBar: MonoBehaviour
    {
        public Slider slider;
        public static float comboValue;
        public static float initialValue = 0.5f;
        private void Start()
        {
            comboValue = initialValue;
            slider.value = initialValue;
        }
        
        private void Update()
        {
            if (comboValue<=1f)
            {
                slider.value = comboValue;
            }
            if (slider.value <= 0.1)
            {
                Debug.Log("You lost a life cause combo bar is empty");
                Life.lifeValue = Life.lifeValue - 1;
                comboValue = 0.5f;
            }
            
        }
    }
}