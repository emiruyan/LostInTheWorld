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
        public void FixedTick(Joystick joystick)
        {
            if (_rigidbody.isKinematic)return;
            if (joystick.Direction!=Vector2.zero)
            {
               _playerController.transform.up = Vector3.Lerp(_playerController.transform.up,joystick.Direction,_playerController.rotationSpeed*Time.deltaTime);
            }
            else
            {
                _playerController.transform.rotation = Quaternion.Lerp(_playerController.transform.rotation,Quaternion.Euler(Vector3.zero),_playerController.rotationSpeed*Time.deltaTime);
            }
            
            // _playerController.transform.Rotate(Vector3.back * Time.deltaTime * direction * _playerController.TurnSpeed);
            // rotation = _playerController.transform.rotation;
            // rotation.z = Mathf.Clamp(rotation.z, -_playerController.maxMinZRotation, _playerController.maxMinZRotation);
            // _playerController.transform.rotation = rotation;
            // if (direction == 0)
            // {
            //     if (_rigidbody.freezeRotation)
            //     {
            //         //_rigidbody.freezeRotation = false;
            //     }
            //     return;
            // }
            //
            // if (!_rigidbody.freezeRotation)
            // {
            //   //  _rigidbody.freezeRotation = false;
            // }





        }
    }
}

