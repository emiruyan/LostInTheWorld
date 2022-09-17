using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace LostInTheWorld.Controllers
{
    public class CoinController : SingletonThisObject<CoinController>
    {
        public int  coin;
        public TextMeshProUGUI _textCoins;
        

        private void Awake()
        {
            SingletonThisGameObject(this);
            _textCoins.text = PlayerPrefs.GetInt("Coin", 0).ToString();
        }

        private void OnTriggerEnter(Collider other) 
        {
            {
                if (other.transform.tag == "Coin")//Eğer Tetiklenen yapılardan birinin Tag'ı "Coin" ise;
                {
                    coin++; //UI'da Coini bir bir arttır.
                    int currentNumber = PlayerPrefs.GetInt("Coin", 0) + coin;
                    _textCoins.text = currentNumber.ToString(); 
                    Destroy(other.gameObject);//Diğer nesneyi yok et.
                }
            }
        }
    }

}

