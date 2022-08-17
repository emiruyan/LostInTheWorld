using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Managers;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;

namespace LostInTheWorld.Uis
{
    public class VolumeSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private void Start()
        {
            _slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
        }
    }

}

