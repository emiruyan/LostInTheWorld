using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Controllers;
using UnityEngine;

namespace LostInTheWorld.Movements
{
    public class Mover: MonoBehaviour //Her classın kendi görevi olması için roketin hareket işlemlerini mover adlı classa taşıdık.
    {
        Rigidbody _rigidbody;
        PlayerController _playerController;

        public Mover(PlayerController playerController) //constructor method
        {
            _playerController = playerController;
            _rigidbody = playerController.GetComponent<Rigidbody>();
        }
        
        public void FixedTick()
        {
            //AddForce Standart x,y,z ' ye göre force gönderiyor.
            //RelativeForce pozisyonumuza göre force gönderiyor.
            _rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * _playerController.Force); 
        }
    }
    
}


