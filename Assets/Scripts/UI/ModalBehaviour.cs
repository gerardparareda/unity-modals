using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ModalBehaviour : MonoBehaviour
{
    private IEnumerator waitCoroutine;

    private AddressablesManager modalAddressablesManager;

    private Button primaryHighlightedButton;
    [SerializeField] private GameObject panelButtons;
    public List<GameObject> buttonsAnswers = new List<GameObject>();
    private List<GameObject> instantiatedButtonsAnswer = new List<GameObject>();

    public void Start()
    {
        GameObject[] addressablesManagers = GameObject.FindGameObjectsWithTag("AddressableManager");
        if (addressablesManagers.Length > 0)
        {
            modalAddressablesManager = addressablesManagers[0].GetComponent<AddressablesManager>();
        }
        else
        {
            Debug.Log("No addressable managers instantianted");
        }
        foreach (GameObject button in buttonsAnswers)
        {
            GameObject answerButton = Instantiate(button);
            answerButton.GetComponent<ButtonBase>().SetModalParent(this.gameObject);
            answerButton.transform.SetParent(panelButtons.transform, false);
            instantiatedButtonsAnswer.Add(answerButton);
        }
        primaryHighlightedButton = instantiatedButtonsAnswer[instantiatedButtonsAnswer.Count-1].GetComponent<Button>();
        SelectPrimaryHighlightedButton();
    }

    public void CloseModal()
    {
        if (modalAddressablesManager)
        {
            modalAddressablesManager.DestroyModal(gameObject);
        }
    }

    public void CloseModal(IEnumerator waitCoroutine)
    {
        if (this.waitCoroutine != null)
        {
            StopCoroutine(this.waitCoroutine);
        }
        this.waitCoroutine = waitCoroutine;
        StartCoroutine(this.waitCoroutine);
    }

    public void SelectPrimaryHighlightedButton()
    {
        GameObject primaryHighlightedButton = instantiatedButtonsAnswer[instantiatedButtonsAnswer.Count - 1];
        if (primaryHighlightedButton)
        {
            primaryHighlightedButton.GetComponent<Button>().Select();
        } else
        { 
            Debug.Log("No primary highlightable button found");
        }
    }

    public void DisableAnswerButtons()
    {
        GetComponent<CanvasGroup>().interactable = false;
    }

    public void EnableAnswerButtons()
    {
        GetComponent<CanvasGroup>().interactable = true;
    }
}
