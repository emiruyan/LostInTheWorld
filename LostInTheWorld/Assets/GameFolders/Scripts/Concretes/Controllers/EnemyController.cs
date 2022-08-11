using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostInTheWorld.Managers;

namespace  LostInTheWorld.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Vector3 _direction;
        [Range(0f, 1f)] 
        [SerializeField] float _factor;
        
        Vector3 _startPosition;
        
         
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

        private void Update()
        {
            Vector3 offset = _direction * _factor;
            transform.position = offset + _startPosition;
        }
    }

}

