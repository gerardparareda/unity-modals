using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonModal3Behaviour : MonoBehaviour
{
    [SerializeField] private Text textQuestion;
    [SerializeField] private Text textDescription;
    [SerializeField] private Color colorToChangeTexts;

    public void ColorSubmit()
    {
        textQuestion.color = colorToChangeTexts;
        textDescription.color = colorToChangeTexts;
        //parentModal.GetComponent<ButtonModalBehaviour>().CloseModal();
    }
}
