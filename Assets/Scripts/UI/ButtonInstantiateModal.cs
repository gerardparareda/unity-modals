using UnityEngine;
using UnityEngine.AddressableAssets;

public class ButtonInstantiateModal : ButtonBase
{
    [SerializeField]
    private AssetReferenceGameObject modalAssetReference;

    private AddressablesManager modalAddressablesManager;

    public void Start()
    {
        GameObject[] addressablesManagers = GameObject.FindGameObjectsWithTag("AddressableManager");
        if (addressablesManagers.Length > 0) {
            modalAddressablesManager = addressablesManagers[0].GetComponent<AddressablesManager>();
        } else
        {
            Debug.Log("No addressable managers instantianted");
        }
    }

    public void CreateModal()
    {
        if(modalAddressablesManager)
        {
            modalAddressablesManager.CreateModal(modalAssetReference);
        }
    }
}
