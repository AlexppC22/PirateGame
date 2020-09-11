using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score;
    
    public Vector3 spawnPoint;
    void Awake()     
    {
        
        if (Instance == null) {Instance = this; } else if (Instance != this) {Destroy(this); }
    }
}
