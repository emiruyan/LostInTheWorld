using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostInTheWorld.Controllers
{
    public class StartFloorController : MonoBehaviour
    {
        private void OnCollisionExit(Collision other) //Player collision'dan ayrıldığında
        {
            PlayerController player = other.collider.GetComponent<PlayerController>();
 
            if (player != null ) //Eğer player yoksa
            {
                Destroy(this.gameObject);//Start Floor kendini yok edecek
            }
        }
    }

}

