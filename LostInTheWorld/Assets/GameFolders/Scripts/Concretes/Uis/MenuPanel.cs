using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Managers;
using UnityEngine;

namespace LostInTheWorld.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartClick()
        {
            GameManager.Instance.LoadLevelScene(1);
        }

        public void ExitClick()
        {
            GameManager.Instance.Exit();     
        }
    }

}
