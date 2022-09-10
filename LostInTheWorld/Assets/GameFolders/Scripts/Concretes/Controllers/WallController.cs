using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using LostInTheWorld.Animations;

namespace  LostInTheWorld.Controllers
{
    public class WallController : MonoBehaviour
    {
        
        private void OnCollisionEnter(Collision other) //iki nesne çarpıştığında
        {
            
            PlayerController player = other.collider.GetComponent<PlayerController>();//Bu iki nesneden birinde Player var mı?

            if (player != null && player.CanRobotMove)   
            {
                //Burada Game Manager'ı devreye sokarak artık bu aksiyonlarımızı GameManager üzerinden yapıyoruz.
                player.PlayerDeath();
                GameManager.Instance.GameOver();
                
            }
        }
    }
}


