using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostInTheWorld.Animations
{
    public class AnimationController : MonoBehaviour
    {
        Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void FlyIncrease(bool isFly)
        {
            _animator.SetBool("isFly", isFly);
        }

        public void PlayerDeath()
        {
            _animator.SetTrigger("isDeath");
        }
    }

}

