using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostInTheWorld.Utilities
{
    public abstract class SingletonThisObject<T> : MonoBehaviour //Bu bölümde Singleton Design Pattern uyguluyoruz.
    {

        public static T Instance { get; set; }

        protected void SingletonThisGameObject(T entity)
        {
            if (Instance == null) //Bu instance ilk kez oluşuyorsa, daha önce hiç alınmadıysa.
            {
                Instance = entity; //İlk oluşan Game Manager'ı bu Instance'a ata
                DontDestroyOnLoad(this.gameObject); //Bu Game Object'i yok etme.
            }
            else
            {
                Destroy(this.gameObject); //Bu Game Object'ten başka varsa bu Game Object'i yok et.
                //Böylece tekilleştirmiş oluruz.
            }
        }
    }
}

