using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostInTheWorld.Movements
{
    public class SawRotator : MonoBehaviour
    {

        void Update()
        {
        
            transform.Rotate(3,0,0 * Time.deltaTime );
        }
    }
}
