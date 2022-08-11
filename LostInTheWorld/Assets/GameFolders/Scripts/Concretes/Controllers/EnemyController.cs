using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostInTheWorld.Managers;

namespace  LostInTheWorld.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Vector3 _direction;//yön atadık
        [SerializeField] float _factor; // Çarpanımızı burada _factor olarak atadık
        [SerializeField] float _speed = 1f; //Hız atadık
       // [Range(0f, 1f)] //0f ile 1f arasında bir sınır belirledik
        
        
        Vector3 _startPosition; //Başlangıç pozisyonumuzu default olarak verdik
        private const float FULL_CIRCLE = Mathf.PI * 2f;//Const'a burada değer atadığımızda bunu bir daha değiştiremeyiz.
        
         
        private void OnCollisionEnter(Collision enemy) //Enemy ile Player çarpıştığında
        {
            PlayerController player = enemy.collider.GetComponent<PlayerController>();

            if (player != null && player.CanRobotMove)
            {
                GameManager.Instance.GameOver();
            }
        }

        private void Awake()
        {
            _startPosition = transform.position;
            
        }

        private void Update() //Enemy hareket işlemleri
        { 
            float cycle = Time.time / _speed;  
            float sinWave = Mathf.Sin(cycle * FULL_CIRCLE); //Sin methodunda bir daire oluşturmasını istiyoruz. ( Pi, ve 2f'in sonucu ile )
            _factor = Mathf.Abs(sinWave); //Abs bize mutlak değeri döner. Enemymimizin eksi değerde gitmesini istemediğimiz için Abs kullandık.
            Vector3 offset = _direction * _factor;
            transform.position = offset + _startPosition;       
        }
    }
}

