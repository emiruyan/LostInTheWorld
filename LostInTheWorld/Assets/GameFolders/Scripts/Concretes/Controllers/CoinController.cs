using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Utilities;
using UnityEngine;

namespace LostInTheWorld.Controllers
{
    public class CoinController : SingletonThisObject<CoinController>
    {
        private float coin = 0f;

        private void Awake()
        {
            SingletonThisGameObject(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "Coin")
            {
                Destroy(other.gameObject);
            }
        }
    }

}

