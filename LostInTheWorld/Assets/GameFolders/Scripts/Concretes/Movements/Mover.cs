using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostInTheWorld.Movements
{
    public class Mover //Her classın kendi görevi olması için roketin hareket işlemlerini mover adlı classa taşıdık.
    {
        Rigidbody _rigidbody;

        public Mover(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }
        
        public void FixedTick()
        {                                                                   //AddForce Standart x,y,z ' ye göre force gönderiyor.
            _rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * 55f); //RelativeForce pozisyonumuza göre force gönderiyor.
        }
    }
    
}


