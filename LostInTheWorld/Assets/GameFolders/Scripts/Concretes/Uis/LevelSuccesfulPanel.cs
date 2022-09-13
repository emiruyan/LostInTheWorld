using System.Collections;
using System.Collections.Generic;
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
            GameManager.Instance.LoadLevelScene(1);
        }
        
        private void Start()
        {
            _highScore.text = PlayerPrefs.GetInt("_highScore").ToString();
        }
        
        
        
    }

}

