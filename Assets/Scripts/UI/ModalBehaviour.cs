using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class ModalBehaviour : MonoBehaviour
{
    private IEnumerator waitCoroutine;

    private AddressablesManager modalAddressablesManager;

    [SerializeField] private Button primaryHighlightedButton;



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
        primaryHighlightedButton.Select();
    }
}
