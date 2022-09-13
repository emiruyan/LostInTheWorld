using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Controllers;
using LostInTheWorld.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace LostInTheWorld.Uis
{
    public class LevelSuccesfulPanel : MonoBehaviour
    {
        
        [SerializeField] private Text _highScore;
        

        public void StartClick()
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin", 0)+CoinController.Instance.coin);
            GameManager.Instance.LoadLevelScene(1);
        }
        
        private void Start()
        {
            _highScore.text = CoinController.Instance.coin.ToString();
        }
        
        
        
    }

}

