using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;

public class AddressablesManager : MonoBehaviour
{

    [SerializeField] private GameObject initialParentModal;

    private GameObject instantiatedModal;

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
                instantiatedModal.GetComponent<ModalBehaviour>().GetPrimaryHighlightedButton().Select();
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
            if(instantiatedModals.Count > 0)
            {
                instantiatedModals[instantiatedModals.Count-1].GetComponent<ModalBehaviour>().GetPrimaryHighlightedButton().Select();
            }
        } else
        {
            Debug.Log("Can't close modal. Not found in AdressablesManager.");
        }
    }

    public bool IsLastModal(GameObject checkModal)
    {
        if (instantiatedModals.Count > 0)
        {
            return instantiatedModals[instantiatedModals.Count - 1] == checkModal;
        } else {
            return false;
        }
    }

}
