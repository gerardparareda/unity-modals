using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : ButtonBase
{
    private ModalBehaviour parentModalBehaviourReference;
    [SerializeField] private Text textQuestion;
    [SerializeField] private Text textDescription;
    [SerializeField] private Color colorToChangeTexts;

    public void Start()
    {
        parentModalBehaviourReference = GetModalParentBehaviour();
        this.textQuestion = parentModalBehaviourReference.GetQuestion();
        this.textDescription = parentModalBehaviourReference.GetDescription();
    }
    public void ColorSubmit()
    {
        if(textQuestion)
            textQuestion.color = colorToChangeTexts;
        
        if(textDescription)
            textDescription.color = colorToChangeTexts;

        parentModalBehaviourReference.CloseModal(Waiter());
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSecondsRealtime(2);
        parentModalBehaviourReference.CloseModal();
    }
}
