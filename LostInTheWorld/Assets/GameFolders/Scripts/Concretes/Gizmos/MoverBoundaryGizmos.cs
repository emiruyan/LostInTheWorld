using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  LostInTheWorld.UnityGizmos
{
    public class MoverBoundaryGizmos : MonoBehaviour
    {
  
        void OnDrawGizmos()     
        {  
            // Draw a yellow sphere at the transform's position
             Gizmos.color = Color.yellow;
             Gizmos.DrawSphere(transform.position, 0.7f);
            }
    }
}


