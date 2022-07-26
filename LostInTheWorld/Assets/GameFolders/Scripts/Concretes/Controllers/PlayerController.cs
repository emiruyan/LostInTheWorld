using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Movements;
using UnityEngine;

namespace LostInTheWorld.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        Mover _mover; //Mover class'ımıza eriştik.
        DefaultInput _input; //Input System'a eriştik.

        bool _isRobotUp;
        
        private void Awake()
        {
            _input = new DefaultInput();
            _mover = new Mover(GetComponent<Rigidbody>());
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
        }

        private void FixedUpdate() //Fixed Update'de fizik işlemlerimizi yapacağız.
        {
            if (_isRobotUp)
            {
                _mover.FixedTick();
            }
        }
    }
}


