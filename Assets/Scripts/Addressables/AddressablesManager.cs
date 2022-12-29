using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressablesManager : MonoBehaviour
{

    [SerializeField] private GameObject initialParentModal;

    private GameObject instantiatedModal;
    private GameObject asyncOperationResult;

    private List<GameObject> instantiatedModals = new List<GameObject>();
    private List<AssetReferenceGameObject> instantiatedModalsAssetsReferences = new List<AssetReferenceGameObject>();

    public void CreateModal(AssetReferenceGameObject modalAssetReference)
    {
        modalAssetReference.InstantiateAsync().Completed += (asyncOperation) =>
        {
            instantiatedModal = asyncOperation.Result;
            if (instantiatedModals.Count == 0)
            {
                instantiatedModal.transform.SetParent(initialParentModal.transform, false);
            }
            else
            {
                instantiatedModal.transform.SetParent(instantiatedModals[instantiatedModals.Count - 1].transform, false);
                EventSystem.current.SetSelectedGameObject(instantiatedModal);
            }
            instantiatedModals.Add(instantiatedModal);
            instantiatedModalsAssetsReferences.Add(modalAssetReference);
        };
    }

    public void DestroyModal(GameObject destroyableModal)
    {
        int modalIndex = instantiatedModals.FindIndex(m => m == destroyableModal);
        if (modalIndex != -1)
        {
            instantiatedModalsAssetsReferences[modalIndex].ReleaseInstance(instantiatedModals[modalIndex]);
            instantiatedModals.RemoveAt(modalIndex);
            instantiatedModalsAssetsReferences.RemoveAt(modalIndex);
        } else
        {
            Debug.Log("Can't close modal. Not found in AdressablesManager.");
        }
    }

}
