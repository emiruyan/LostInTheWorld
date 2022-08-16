using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Utilities;
using Unity.VisualScripting;
using UnityEngine;

namespace LostInTheWorld.Managers
{
    public class SoundManager : SingletonThisObject<SoundManager>
    { 
        AudioSource[] _audioSource;
        
        private void Awake()
        {  
            SingletonThisGameObject(this); //Singleton Design Pattern

            _audioSource = GetComponentsInChildren<AudioSource>(); //Birden fazla Component barındıracağı için GetComponentsInChildren kullandık.

        }

        public void PlaySound(int index)//Soundlarımızı oynatacağımız method
        {
            if (!_audioSource[index].isPlaying)//Oynamıyorsa
            {
                _audioSource[index].Play();//Oynatsın
            }
            
        }

        public void StopSound(int index) //Soundlarımızı durduracağımız method
        {

            if (_audioSource[index].isPlaying)//Oynuyorsa
            {
                _audioSource[index].Stop();//Durdursun
            }
            
        }
    }
}


