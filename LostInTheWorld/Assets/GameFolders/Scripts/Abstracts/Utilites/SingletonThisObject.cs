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
            Instance = entity; //İlk oluşan Game Manager'ı bu Instance'a ata
        }
    }
}

