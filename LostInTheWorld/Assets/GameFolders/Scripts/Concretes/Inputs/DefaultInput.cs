using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Inputs;
using UnityEngine;

public class DefaultInput : MonoBehaviour
{
   DefaultAction _input; 

   public bool IsRobotUp { get; private set; } //private yapmamızın nedeni dışarıdan erişilmemesini sağlamak.
   
   public DefaultInput()  //constructor method
   {
      _input = new DefaultAction(); 

                        //tetiklendiğinde
      _input.Robot.RobotUp.performed += context => IsRobotUp = context.ReadValueAsButton();
      _input.Enable(); //Input'u etkinleştirmezsek hiç bir Input scriptimiz çalışmaz.
      
   }
}
