using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Managers;
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
        FireParticleEffect _fireParticleEffect;
        
        bool _canRobotMove;
        bool _isRobotUp;
        float _robotRotator;

        public float _minX, _maxX, _minY, _maxY;
        
        
        public float TurnSpeed => _turnSpeed;
        public float Force => _force;
        public bool CanRobotMove => _canRobotMove;

        private void Awake() //Component'lar ve cashlemeler
        {
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
            _fireParticleEffect = GetComponent<FireParticleEffect>();
        }

        private void Start()
        {
            _canRobotMove = true;
        }

        private void OnEnable() //Etkinleştirildiğinde
        {
            GameManager.Instance.OnGameOver += HandleOnEventTriggered;
        }
        
        private void OnDisable()//Devre Dışı bırakıldığında
        {
            GameManager.Instance.OnGameOver -= HandleOnEventTriggered;   
        }

        private void Update() //Input'umuzu Update'den alıyoruz.
         {
             if (!_canRobotMove) //Player hareket edemiyorsa return et.
             {
                 return;
             }
             
             if (_input.IsRobotUp && !_fireParticleEffect.IsEmpty)  //Robotumuz kalkışa geçtiğinde ve fireParticle boş olduğunda.
            {
                _isRobotUp = true;
            }
            else
            {
                _isRobotUp = false;
                _fireParticleEffect.FireIncrease(0.01f); //Fire artışı
                
            }

            _robotRotator = _input.RobotRotator;
            
            PlayerBoundaries();
         }
        

       

        private void FixedUpdate() //Fixed Update'de fizik işlemlerimizi yapacağız.
        {
            if (_isRobotUp)
            {
                _mover.FixedTick();
                _fireParticleEffect.FireDecrease(0.2f); //Fire düşüşü
            }
            _rotator.FixedTick(_robotRotator);
        }
        
        private void HandleOnEventTriggered() //Tetiklenecek yapılar
        {
            _canRobotMove = false; //Player öldüyse hareket edemeyecek
            _isRobotUp = false; //Player öldüyse Yukarı güç uygulayamayacak.
            _robotRotator = 0f; //Player öldüyse sağa sola hareket edemeyecek.
            _fireParticleEffect.FireIncrease(0f);//Player öldüyse FireParticleEffect çalışmayacak.
        }

        void PlayerBoundaries()
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minX, _maxX),
                                             Mathf.Clamp(transform.position.y, _minY, _maxY), 0);
        }
    }
}


