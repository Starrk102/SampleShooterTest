using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Settings;
using TMPro;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameManager : MonoBehaviour
{
    [Inject] private PlayerController playerController;
    [Inject] private GameSettings gameSettings;
    [Inject] private GameOverScreen.GameOverScreen gameOverScreen;
    [Inject] private Canvas canvas;
    [Inject] private DeadZone deadZone;
    
    public void Init()
    {
        deadZone.onTrigger += OnDeadZone;
        playerController.Init(gameSettings.speedPlayer, gameSettings.fireRatePlayer, gameSettings.fireRangePlayer, gameSettings.healthPlayer, deadZone.gameObject.transform);
    }

    public void OnDeadZone()
    {
        if (playerController.health.Value <= 0)
        {
            GameOver();
            return;
        }
        
        playerController.TakeDamage();
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        Instantiate(gameOverScreen, canvas.transform);
    }

    private void OnDestroy()
    {
        deadZone.onTrigger -= OnDeadZone;
    }
}
