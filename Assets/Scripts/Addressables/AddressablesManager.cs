using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

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
            }
            instantiatedModals.Add(instantiatedModal);
            instantiatedModalsAssetsReferences.Add(modalAssetReference);
            instantiatedModal.GetComponent<ModalBehaviour>().SelectPrimaryHighlightedButton();
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
                instantiatedModals[instantiatedModals.Count-1].GetComponent<ModalBehaviour>().SelectPrimaryHighlightedButton();
            }
        } else
        {
            Debug.Log("Can't close modal. Not found in AdressablesManager.");
        }
    }

    void FixedUpdate()
    {
        // Control what to do if the mouse gains focus and then the user decides to use Keyboard or 
        InputSystem.onAnyButtonPress.Call(
            ctrl =>
            {
                if ((ctrl.device is Gamepad || ctrl.device is Keyboard) && instantiatedModals.Count > 0)
                {
                    if (EventSystem.current.currentSelectedGameObject == null)
                    {
                        RefocusUI();
                    }
                    else
                    {
                        if (
                            EventSystem.current.currentSelectedGameObject.GetComponent<ButtonBase>().GetModalParentBehaviour().gameObject
                            != instantiatedModals[instantiatedModals.Count - 1]
                        )
                            RefocusUI();
                    }
                    // Error is here. Somehow goes to back modal because is not controlled
                }
            });
    }

    public void RefocusUI()
    {
        if (instantiatedModals.Count > 0)
            instantiatedModals[instantiatedModals.Count - 1].GetComponent<ModalBehaviour>().SelectPrimaryHighlightedButton();
    }
}
