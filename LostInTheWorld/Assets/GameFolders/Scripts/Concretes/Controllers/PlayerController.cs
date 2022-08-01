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
        FireParticleEffect _fireParticleEffect;

        bool _isRobotUp;
        float _robotRotator;
        
        public float TurnSpeed => _turnSpeed;
        public float Force => _force;

        private void Awake() //Component'lar ve cashlemeler
        {
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
            _fireParticleEffect = GetComponent<FireParticleEffect>();
        }

        private void Update() //Input'umuzu Update'den alıyoruz.
         {
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
         }
        //Fire Particle Effect ile Inputlarımızı aynı bölümde kullandık çünkü birbiri ile iç içe kullanılabilir yapılar. Yukarı tuşuna bastığımızda Particle Effect aktif hale geliyor. Basmadığımızda aktif hale gelmiyor.

       

        private void FixedUpdate() //Fixed Update'de fizik işlemlerimizi yapacağız.
        {
            if (_isRobotUp)
            {
                _mover.FixedTick();
                _fireParticleEffect.FireDecrease(0.2f); //Fire düşüşü
            }
            _rotator.FixedTick(_robotRotator);
        }
    }
}


