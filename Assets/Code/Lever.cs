using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractiveObject
{

    public bool State = false;

    public Transform PhisicalLever;  

    public void StartGame()    
    {
        CanBeInteractedWith = true;
    }

    public override void ExecuteInteractiveAction()
    {
        State = !State;
        turnLever();

        

    }

    void turnLever()
    {
        if(State)
        {
            PhisicalLever.rotation = new Quaternion(0.3f,0.7f,-0.3f,0.7f);
        }
        else
        {
            PhisicalLever.localRotation = new Quaternion(-0.3826834f, 0, 0, 0.9238795f);
        }
    }

}
