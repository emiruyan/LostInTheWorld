 using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Managers;
using UnityEngine;

namespace LostInTheWorld.Uis
{
    public class GameOverObject : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverPanel;

        private void Awake()
        {
            if (_gameOverPanel.activeSelf) //Game Over Panel Açık(True) ise bunu 
            {
                _gameOverPanel.SetActive(false); //False'a çeksin
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleOnGameOver;
        }
        
        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleOnGameOver;
        }
         
        private void HandleOnGameOver()
        {
            if (!_gameOverPanel.activeSelf) //Game Over Panel Kapalı(False) ise
            {
                _gameOverPanel.SetActive(true); //True'a çeksin
            }
        }
    }
}


