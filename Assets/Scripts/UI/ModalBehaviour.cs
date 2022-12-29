using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ModalBehaviour : MonoBehaviour
{
    private IEnumerator waitCoroutine;

    private AddressablesManager modalAddressablesManager;

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

    /*public void Update()
    {
        if (this.waitCoroutine != null)
        {
            Debug.Log(waitCoroutine.Current.ToString());
        }
    }*/

    public void CloseModal(IEnumerator waitCoroutine)
    {
        if (this.waitCoroutine != null)
        {
            StopCoroutine(this.waitCoroutine);
        }
        this.waitCoroutine = waitCoroutine;
        StartCoroutine(this.waitCoroutine);
    }
}
