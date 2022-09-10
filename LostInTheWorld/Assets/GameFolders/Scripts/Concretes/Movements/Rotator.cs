using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Controllers;
using UnityEngine;

namespace LostInTheWorld.Movements
{
    public class Rotator
    {
        Rigidbody _rigidbody;
        PlayerController _playerController;
  
        public Rotator(PlayerController playerController) //constructor method 
        {
            _playerController = playerController; //ctor için cashledik
            _rigidbody = playerController.GetComponent<Rigidbody>();//ctor için cashledik
        }


        private Quaternion rotation;
        public void FixedTick(float direction)
        {
            if (_rigidbody.isKinematic)return;
            _playerController.transform.Rotate(Vector3.back * Time.deltaTime * direction * _playerController.TurnSpeed);
            rotation = _playerController.transform.rotation;
            rotation.z = Mathf.Clamp(rotation.z, -_playerController.maxMinZRotation, _playerController.maxMinZRotation);
            _playerController.transform.rotation = rotation;
            if (direction == 0)
            {
                if (_rigidbody.freezeRotation)
                {
                    //_rigidbody.freezeRotation = false;
                }
                return;
            }
            
            if (!_rigidbody.freezeRotation)
            {
              //  _rigidbody.freezeRotation = false;
            }
            
            



        }
    }
}

