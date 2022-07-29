using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Movements;
using UnityEngine;

namespace LostInTheWorld.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] float _force = 55f;
        
        Mover _mover; //Mover class'ımıza eriştik.
        DefaultInput _input; //Input System'a eriştik.
        Rotator _rotator;

        bool _isRobotUp;
        float _robotRotator;
        
        public float TurnSpeed => _turnSpeed;
        public float Force => _force;

        private void Awake()
        {
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this); 
        }

        private void Update() //Input'umuzu Update'den alıyoruz.
         {
           
            
            if (_input.IsRobotUp) 
            {
                _isRobotUp = true;
            }
            else
            {
                _isRobotUp = false;
            }

            _robotRotator = _input.RobotRotator;
         }

        private void FixedUpdate() //Fixed Update'de fizik işlemlerimizi yapacağız.
        {
            if (_isRobotUp)
            {
                _mover.FixedTick();
            }
            _rotator.FixedTick(_robotRotator);
        }
    }
}


