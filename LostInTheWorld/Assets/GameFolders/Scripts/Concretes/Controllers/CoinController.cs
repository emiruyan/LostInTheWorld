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
    public class CoinController : MonoBehaviour
    {
        private int coin = 0;
        public Text _textCoins; 


        private void Update()
        {
            if (coin > PlayerPrefs.GetInt("_highScore"))
            {
                PlayerPrefs.SetInt("_highScore", coin);
            }
        }

        private void OnTriggerEnter(Collider other) 
        {
            {
                if (other.transform.tag == "Coin")//Eğer Tetiklenen yapılardan birinin Tag'ı "Coin" ise;
                {
                    coin++; //UI'da Coini bir bir arttır.
                    _textCoins.text = coin.ToString(); 
                    Destroy(other.gameObject);//Diğer nesneyi yok et.
                }
            }
        }
    }

}

