using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private ICommand buttonA;
    private ICommand buttonB;
    public void SetButtonACommand(ICommand command)
    {
        buttonA = command;
    }
    public void SetButtonBCommand(ICommand command)
    {
        buttonB = command;
    }
    public void PressButtonA()
    {
        buttonA.Execute();
    }
    public void PressButtonB()
    {
        buttonB.Execute();
    }
}
