using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostInTheWorld.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _force; //Force'u Inspector'da görüntüledik.
        Rigidbody _rigidbody; //Rigidbody'e eriştik.
        DefaultInput _input; //Input System'a eriştik.

        bool _isRobotUp;
        
        private void Awake()
        {
            _rigidbody  = GetComponent<Rigidbody>(); 
            _input = new DefaultInput();
        }

        private void Update() //Input'umuzu Update'den alıyoruz.
        {

            Debug.Log(_input.IsRobotUp);
            
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
                _rigidbody.AddForce(Vector3.up * Time.deltaTime * _force); //Robotumuza yukarı doğru bir güç ekledik.
            }
        }
    }
}


