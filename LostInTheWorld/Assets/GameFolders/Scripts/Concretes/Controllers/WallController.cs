using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace  LostInTheWorld.Controllers
{
    public class WallController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other) //iki nesne çarpıştığında
        {
            PlayerController player = other.collider.GetComponent<PlayerController>();//Bu iki nesneden birinde Player var mı?

            if (player != null) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //İki nesnemiz çarpıştığında sahnemiz tekrar yüklenir.
            }
        }
    }
}


