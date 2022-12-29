using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonModal3Behaviour : MonoBehaviour
{
    [SerializeField] private GameObject parentModal;
    [SerializeField] private Text textQuestion;
    [SerializeField] private Text textDescription;
    [SerializeField] private Color colorToChangeTexts;

    public void ColorSubmit()
    {
        textQuestion.color = colorToChangeTexts;
        textDescription.color = colorToChangeTexts;

        parentModal.GetComponent<ModalBehaviour>().CloseModal(Waiter());
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2);
        parentModal.GetComponent<ModalBehaviour>().CloseModal();
    }
}
