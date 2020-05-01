using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public string Tooltip;
    public bool CanBeInteractedWith;

    public string KeyItem;

    public virtual void ExecuteInteractiveAction()
    {
        CanBeInteractedWith = false;
    }
    public IEnumerator ActivateInXSec(int X)
    {
        yield return new WaitForSeconds(X);
        CanBeInteractedWith = true;
    }

}
