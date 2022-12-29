using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ButtonClose : ButtonBase
{
    public void CloseParentModal()
    {
        this.GetModalParentBehaviour().CloseModal();
    }
}
