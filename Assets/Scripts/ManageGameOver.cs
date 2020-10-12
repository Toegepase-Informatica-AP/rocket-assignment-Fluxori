using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGameOver : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    private Health healthPlayer;
    private Coins coinsPlayer;
    public enum GameStates
    {
        Playing, GameOver
    }

    public GameStates gameState = GameStates.Playing;
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        healthPlayer = player.GetComponent<Health>();
        coinsPlayer = player.GetComponent<Coins>();
    }

    void Update()
    {
        switch (gameState)
        {
            case GameStates.Playing:
                if (!healthPlayer.isAlive)
                {
                    gameState = GameStates.GameOver;
                    coinsPlayer.ResetCoins();
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                }

                break;
        }
    }
}
