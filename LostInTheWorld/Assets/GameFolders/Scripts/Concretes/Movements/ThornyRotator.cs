using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostInTheWorld
{
    public class ThornyRotator : MonoBehaviour
    {
        
        void Update()
        {
            transform.Rotate(0,1,0 * Time.deltaTime );
        }
    }

}

