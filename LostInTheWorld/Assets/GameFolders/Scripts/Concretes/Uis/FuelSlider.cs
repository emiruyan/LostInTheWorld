using LostInTheWorld.Movements;
using UnityEngine;
using UnityEngine.UI;

namespace LostInTheWorld.Uis
{
    public class FuelSlider : MonoBehaviour
    { 
        Slider _slider;
        FireParticleEffect _fireParticleEffect;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _fireParticleEffect = FindObjectOfType<FireParticleEffect>();
        }

        private void Update()
        {
            _slider.value = _fireParticleEffect.CurrentFire;
        }
    }

}

