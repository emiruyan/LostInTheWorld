
using System;
using LostInTheWorld.Utilities;


public class CanvasManager : SingletonThisObject<CanvasManager>
{
    public Joystick joystick;

    private void Awake()
    {
        SingletonThisGameObject(this);
    }
}
