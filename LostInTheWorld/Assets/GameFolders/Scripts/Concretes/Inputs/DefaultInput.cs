using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Inputs;
using UnityEngine;
using LostInTheWorld.Animations;
using LostInTheWorld.Controllers;

public class DefaultInput : MonoBehaviour
{
    [SerializeField] PlayerController _player;
    [SerializeField] AnimationController _animationController;
    DefaultAction _input; 
    

   public bool IsRobotUp { get; private set; } //private yapmamızın nedeni dışarıdan erişilmemesini sağlamak.
   public float RobotRotator { get; private set; }
   
   public DefaultInput()  //constructor method
   {
      _input = new DefaultAction(); 
      
                        //tetiklendiğinde
      _input.Robot.RobotUp.performed += context => IsRobotUp = context.ReadValueAsButton();
      _input.Robot.RobotRotator.performed += context => RobotRotator = context.ReadValue<float>();
      
      _input.Enable(); //Input'u etkinleştirmezsek hiç bir Input scriptimiz çalışmaz.
      
   }
}
