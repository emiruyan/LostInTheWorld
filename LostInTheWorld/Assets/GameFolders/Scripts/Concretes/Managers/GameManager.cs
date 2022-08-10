using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LostInTheWorld.Managers
{
    //Bu class'ta Singleton Design Pattern'den yararlanacağız. Game Manager'ın tekrar tekrar oluşmasını istemiyoruz. Tekil bir yapı istiyoruz.
    public class GameManager : MonoBehaviour
    {
        public event Action OnGameOver; //Oyun bittiğinde, öldüğümüzde tetiklenecek bir event oluşturduk.
        public event Action OnLevelSuccessful; //Leveli başarı ile tamamladığımızda tetiklenecek eventi oluşturduk.
        

        public static GameManager Instance { get;private set; }//Static tekildir. 
        
        private void Awake() 
        {
            SingletonThisGameObject();
        }

        private void SingletonThisGameObject() //Bu bölümde Singleton Design Pattern uyguluyoruz.
        {
            if (Instance == null) //Bu instance ilk kez oluşuyorsa, daha önce hiç alınmadıysa.
            {
                Instance = this; //İlk oluşan Game Manager'ı bu Instance'a ata
                DontDestroyOnLoad(this.gameObject);//Bu Game Object'i yok etme.
            }
            else
            {
                Destroy(this.gameObject); //Bu Game Object'ten başka varsa bu Game Object'i yok et.
                                         //Böylece tekilleştirmiş oluruz.
            }
        }

        public void GameOver()
        {
            OnGameOver?.Invoke(); //OnGameOver boş değilse (!null) ise Invoke et.
        }

        public void LevelSuccessful()
        {
            OnLevelSuccessful?.Invoke(); //OnLevelSuccesful boş değilse (!null) ise Invoke et.
            Debug.Log("LevelSuccesful");
        }

        public void LoadLevelScene(int levelIndex = 0)//Menu UI,Button aksiyonlarında burayı çağıracağız.
        {
            StartCoroutine(LoadLevelSceneAsync(levelIndex));
        }
        
        //Coroutine methodlar diğer methodlardan farklı çalışır. Bir method bitmeden arka planda aykırı bir şekilde çalışabilir.

        private IEnumerator LoadLevelSceneAsync(int levelIndex)//Arka planda Coroutine method çalışmaya devam edecek
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
        }

        public void LoadMenuScene()//Player öldüğünde Menü'ye geçiş işlemleri
        {
            StartCoroutine(LoadMenuSceneAsync());//Menu işlemleri Coroutine Method üzerinden olacak.
        }

        private IEnumerator LoadMenuSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync("Menu");
;       }

        public void Exit()
        {
            Application.Quit();
        }
    }
}

