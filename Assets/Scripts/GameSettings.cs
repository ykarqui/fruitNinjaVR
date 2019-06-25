using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "FruitNinja/Create Game Settings", order = 1)]
public class GameSettings : ScriptableObject {
    public int startTime = 3;
    public int matchTime = 30;
    public int scoreBase = 0;    
}