using UnityEngine;

public class ButtonBase : MonoBehaviour
{

    private GameObject modalParent;

    public void SetModalParent(GameObject modalParent)
    {
        this.modalParent = modalParent;
    }

    public ModalBehaviour GetModalParentBehaviour()
    {
        return this.modalParent.GetComponent<ModalBehaviour>();
    }
}
