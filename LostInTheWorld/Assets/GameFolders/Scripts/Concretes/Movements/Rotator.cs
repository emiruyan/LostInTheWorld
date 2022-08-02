using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Controllers;
using UnityEngine;

namespace LostInTheWorld.Movements
{
    public class Rotator : MonoBehaviour
    {
        Rigidbody _rigidbody;
        PlayerController _playerController;
        //float _moveBoundary;

        public Rotator(PlayerController playerController) //constructor method 
        {
            _playerController = playerController; //ctor için cashledik
            _rigidbody = playerController.GetComponent<Rigidbody>();//ctor için cashledik
            //_moveBoundary = playerController.MoveBoundary;

        }

        public void FixedTick(float direction)
        {
            if (direction == 0)
            {
                if (_rigidbody.freezeRotation)
                {
                    _rigidbody.freezeRotation = false;
                }
                return;
            }
            
            if (!_rigidbody.freezeRotation)
            {
                _rigidbody.freezeRotation = false;
            }
            
            _playerController.transform.Rotate(Vector3.back * Time.deltaTime * direction * _playerController.TurnSpeed);
            
        //     float xBoundary = Mathf.Clamp(_playerController.transform.position.x, -_moveBoundary, _moveBoundary);
        //     _playerController.transform.position = new Vector3(xBoundary, _playerController.transform.position.y, 0f); 
         }
    }
}

