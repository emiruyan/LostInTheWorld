using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Managers;
using UnityEngine;

namespace LostInTheWorld.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void PlayAgainButton()
        {
            GameManager.Instance.LoadLevelScene(); //Aynı bölümü oynayacağımız için index yazmadık.
        }

        public void MainMenuButton()
        {
            GameManager.Instance.LoadMenuScene(); //Coroutine
        }
    }

}

