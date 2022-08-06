using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostInTheWorld.Managers
{
    //Bu class'ta Singleton Design Pattern'den yararlanacağız. Game Manager'ın tekrar tekrar oluşmasını istemiyoruz. Tekil bir yapı istiyoruz.
    public class GameManager : MonoBehaviour
    {
        public event Action OnGameOver; //Oyun bittiğinde, öldüğümüzde tetiklenecek bir event oluşturduk.

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
            OnGameOver?.Invoke(); 
        }
        
    
    }

}

