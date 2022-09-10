using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
   // [SerializeField] private GameState currentGameState;
    // Start is called before the first frame update
    void Start()
    {
       // currentGameState = SPAWN_IN; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum GameStateEnum
{
    SPAWN_IN, 
    PLAYER_PLAYING,
    REACH_TARGET
}
