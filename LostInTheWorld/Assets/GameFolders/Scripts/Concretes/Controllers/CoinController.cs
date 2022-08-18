using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Utilities;
using TMPro;
using UnityEngine;

namespace LostInTheWorld.Controllers
{
    public class CoinController : MonoBehaviour
    {
        private float coin = 0f;//Float tipinde coin değişkeni atadık.
        public TextMeshProUGUI _textCoins; //UI'da TMP kullanmak için bu değişkeni oluşturduk. 
        
        private void OnTriggerEnter(Collider other) 
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

