using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Controllers;
using UnityEngine;

namespace LostInTheWorld.Movements
{
    public class Mover: MonoBehaviour //Her classın kendi görevi olması için Player'ın hareket işlemlerini mover adlı classa taşıdık.
    {
        Rigidbody _rigidbody;
        [SerializeField] private float upForce = 5f;

        public Rigidbody rigidbody => _rigidbody;
        PlayerController _playerController;
        
        
        public Mover(PlayerController playerController) //constructor method
        {
            
            _playerController = playerController;
            _rigidbody = playerController.GetComponent<Rigidbody>();
        }

        private Vector3 velocity;
        public void FixedTick()
        {
            //AddForce Standart x,y,z ' ye göre force gönderiyor.
            //RelativeForce pozisyonumuza göre force gönderiyor.
            if (_playerController.joystick.Direction!=Vector2.zero)
            {
                _rigidbody.AddForce((_playerController.transform.up )* Time.deltaTime * _playerController.Force);
                rigidbody.velocity = ReturnClampVelocity(rigidbody.velocity,_playerController.clampMaxVelocity);
            }
           
        }

        public  Vector3 ReturnClampVelocity(Vector3 velocity,float clampValue)
        {
            velocity.Set(Mathf.Clamp(velocity.x, -clampValue, clampValue),
                Mathf.Clamp(velocity.y, -clampValue, clampValue),
                Mathf.Clamp(velocity.z, -clampValue, clampValue));
            return velocity;
        }
    }
    
}


