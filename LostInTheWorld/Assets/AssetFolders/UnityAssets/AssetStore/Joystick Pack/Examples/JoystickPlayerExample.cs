using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Controllers;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FixedJoystick variableJoystick;
    public Rigidbody _rigidbody;
    private PlayerController _playerController;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.up * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        _rigidbody.AddRelativeForce(Vector3.up * speed * Time.deltaTime *  _playerController.Force);
        
        
    }
}