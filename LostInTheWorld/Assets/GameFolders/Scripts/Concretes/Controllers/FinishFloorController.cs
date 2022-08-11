using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LostInTheWorld.Controllers
{
    public class FinishFloorController : MonoBehaviour
    {
        [SerializeField] GameObject _finishParticleEffect;//Particle effecti verdil.
        

        private void OnCollisionEnter(Collision other) //İki nesne arasında çarpışma gerçekleştiğinde
        {
            PlayerController player = other.collider.GetComponent<PlayerController>();//Player ve collider çarpıştığında 

            if (player == null || !player.CanRobotMove) //player null mı ?
            {
                return; //nullsa return et
            }

            if (other.GetContact(0).normal.y == -1)//Player collider'a tam tepeden y pozisyonundan mı değiyor ?
            {
                _finishParticleEffect.gameObject.SetActive(true);//Particle effecti' devreye sok
                GameManager.Instance.LevelSuccessful();//Event  
            }
            else
            {
                //Burada Game Manager'ı devreye sokarak artık bu aksiyonlarımızı GameManager üzerinden yapıyoruz. Bu aksiyonu önceden Unity içerisinde bulunan SceneManager(31.Satır) üzerinden yapıyorduk.
                 GameManager.Instance.GameOver(); 
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); Oynanan sahneyi tekrar yükle(Game Over)
            }
        }
        
    }

}

