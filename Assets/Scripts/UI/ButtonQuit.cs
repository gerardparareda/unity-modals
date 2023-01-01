using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ButtonQuit : ButtonBase
{
    public void CloseGame()
    {
        Application.Quit();
    }
}
