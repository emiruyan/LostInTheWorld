using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace LostInTheWorld.Movements
{
    public class FireParticleEffect : MonoBehaviour
    {
        [SerializeField] float _maxFire = 100f;
        [SerializeField] float _currentFire;
        [SerializeField] ParticleSystem _fireParticle;

        public bool IsEmpty => _currentFire < 1f;  //Current fire 1f'den küçük yakıtımız boştur.

        public float CurrentFire => _currentFire / _maxFire; 

        private void Awake()
        {
            _currentFire = _maxFire;
        }

        public void FireIncrease(float increase) //Fire Fx Artışı sağlandığında.
        {
            _currentFire += increase; //Current fire'ı sürekli arttırıyoruz.
            _currentFire = Mathf.Min(_currentFire, _maxFire); //Burada maxFire(100f) üzerine çıkamayacağız. Bu yüzden iki değerden minimum olan değeri alacak.
            
            if (_fireParticle.isPlaying) //Oynuyorsa durdur.
            {
                _fireParticle.Stop();
            }
            
            
        }

        public void FireDecrease(float decrease)//Fire Fx Düşüsü sağlandığında.
        {
            _currentFire -= decrease;
            _currentFire = Mathf.Max(_currentFire, 0f); //Burada maksimum olan değeri alacak. currentFire'ımız 0'ın altını alamaycak. Bunu sağlamış olduk.

            if (_fireParticle.isStopped)//Duruyorsa oynat.
            {
                _fireParticle.Play();
            } 
        }
    }
}


