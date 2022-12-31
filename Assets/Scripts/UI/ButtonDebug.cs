using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDebug : ButtonBase
{

    public void SendDebug()
    {
        Debug.Log("Debug message");
    }

}
