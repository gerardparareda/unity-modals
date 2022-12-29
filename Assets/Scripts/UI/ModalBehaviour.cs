using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalBehaviour : MonoBehaviour
{
    private IEnumerator waitCoroutine;

    private AddressablesManager modalAddressablesManager;

    private Button primaryHighlightedButton;
    [SerializeField] private GameObject panelButtons;
    public List<ButtonBase> buttonsAnswers = new List<ButtonBase>();

    public void Start()
    {
        ButtonBase lastInstantiatedAnswerButton = null;
        GameObject[] addressablesManagers = GameObject.FindGameObjectsWithTag("AddressableManager");
        if (addressablesManagers.Length > 0)
        {
            modalAddressablesManager = addressablesManagers[0].GetComponent<AddressablesManager>();
        }
        else
        {
            Debug.Log("No addressable managers instantianted");
        }
        foreach (ButtonBase button in buttonsAnswers)
        {
            ButtonBase instantiatedAnswerButton = Instantiate(button);
            instantiatedAnswerButton.SetModalParent(this.gameObject);
            instantiatedAnswerButton.transform.SetParent(panelButtons.transform, false);
            lastInstantiatedAnswerButton = instantiatedAnswerButton;
        }
        primaryHighlightedButton = lastInstantiatedAnswerButton.GetComponent<Button>();
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
        if(primaryHighlightedButton)
            primaryHighlightedButton.Select();
    }
}
