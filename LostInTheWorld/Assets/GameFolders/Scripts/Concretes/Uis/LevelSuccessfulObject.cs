using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Managers;
using LostInTheWorld.Movements;
using UnityEngine;
using UnityEngine.UI;

namespace LostInTheWorld.Uis
{
    public class LevelSuccessfulObject : MonoBehaviour
    {
        [SerializeField] GameObject _levelSuccesfulPanel;
       

        Mover _mover;
        
        private void Awake()
        {
            if (_levelSuccesfulPanel.activeSelf) //Level Succesful Panel Açık(True) ise bunu 
            {
                _levelSuccesfulPanel.SetActive(false); //False'a çeksin
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnLevelSuccessful += HandleOnLevelSuccesful;
        }
        
        private void OnDisable()
        {
            GameManager.Instance.OnLevelSuccessful -= HandleOnLevelSuccesful;
        }
        
        private void HandleOnLevelSuccesful() 
        {
            if (!_levelSuccesfulPanel.activeSelf) //Level Succesful Panel Kapalı(False) ise
            {
                _levelSuccesfulPanel.SetActive(true); //True'a çeksin
            }
            
            
        }
        
    }

}

