using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Controllers;
using LostInTheWorld.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LostInTheWorld.Managers
{
    //Bu class'ta Singleton Design Pattern'den yararlanacağız. Game Manager'ın tekrar tekrar oluşmasını istemiyoruz. Tekil bir yapı istiyoruz.
    public class GameManager : SingletonThisObject<GameManager>
    {
        public event Action OnGameOver; //Oyun bittiğinde, öldüğümüzde tetiklenecek bir event oluşturduk.
        public event Action OnLevelSuccessful; //Leveli başarı ile tamamladığımızda tetiklenecek eventi oluşturduk.

        private void Awake()
        {
            SingletonThisGameObject(this);
        }

        public void GameOver()
        {
            OnGameOver?.Invoke(); //OnGameOver boş değilse (!null) ise Invoke et.
        }

        public void LevelSuccessful()
        {
            OnLevelSuccessful?.Invoke(); //OnLevelSuccesful boş değilse (!null) ise Invoke et.
            Debug.Log("sucseess");
        }

        public void LoadLevelScene(int levelIndex = 0)//Menu UI,Button aksiyonlarında burayı çağıracağız.
        {
            StartCoroutine(LoadLevelSceneAsync(levelIndex));
        }
        
        //Coroutine methodlar diğer methodlardan farklı çalışır. Bir method bitmeden arka planda aykırı bir şekilde çalışabilir.

        private IEnumerator LoadLevelSceneAsync(int levelIndex)//Arka planda Coroutine method çalışmaya devam edecek
        {
            //Menüden oyuna gidiyorsa
            SoundManager.Instance.StopSound(0);
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
            SoundManager.Instance.PlaySound(1);
        }

        public void LoadMenuScene()//Player öldüğünde Menü'ye geçiş işlemleri
        {
            StartCoroutine(LoadMenuSceneAsync());//Menu işlemleri Coroutine Method üzerinden olacak.
        }

        private IEnumerator LoadMenuSceneAsync()
        {
            SoundManager.Instance.StopSound(1);
            yield return SceneManager.LoadSceneAsync("Menu");
            SoundManager.Instance.PlaySound(0);
;       }

        public void Exit()
        {
            Application.Quit();
        }
    }
}

