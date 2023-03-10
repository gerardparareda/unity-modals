using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class AddressablesManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject initialParentModal;

    public GameObject buttonOptionsOpen;

    private GameObject instantiatedModal;

    private List<GameObject> instantiatedModals = new List<GameObject>();
    private List<AssetReferenceGameObject> instantiatedModalsAssetsReferences = new List<AssetReferenceGameObject>();

    private bool usingMouse = true;

    public void CreateModal(AssetReferenceGameObject modalAssetReference)
    {
        modalAssetReference.InstantiateAsync().Completed += (asyncOperation) =>
        {
            instantiatedModal = asyncOperation.Result;
            instantiatedModal.transform.SetParent(initialParentModal.transform, false);
            DisableBehindModalInteractables();
            instantiatedModals.Add(instantiatedModal);
            instantiatedModalsAssetsReferences.Add(modalAssetReference);

            if (instantiatedModals.Count == 1)
            {
                gameManager.PauseGame();
            }
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
                instantiatedModals[instantiatedModals.Count-1].GetComponent<ModalBehaviour>().EnableAnswerButtons();
                if (!usingMouse)
                    instantiatedModals[instantiatedModals.Count-1].GetComponent<ModalBehaviour>().SelectPrimaryHighlightedButton();
            }
            if (instantiatedModals.Count == 0)
            {
                if (instantiatedModals.Count == 0)
                    buttonOptionsOpen.SetActive(true);

                gameManager.ResumeGame();
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
                if (ctrl.device is Mouse && !usingMouse && EventSystem.current.currentSelectedGameObject)
                {
                    EventSystem.current.SetSelectedGameObject(null);
                    usingMouse = true;
                }

                if ((ctrl.device is Gamepad || ctrl.device is Keyboard) && usingMouse && EventSystem.current.currentSelectedGameObject)
                {
                    EventSystem.current.SetSelectedGameObject(null);
                    usingMouse = false;
                }

                if ((ctrl.device is Gamepad || ctrl.device is Keyboard) && instantiatedModals.Count > 0)
                {
                    //EventSystem.current.SetSelectedGameObject(null);
                    if (EventSystem.current.currentSelectedGameObject == null)
                    {
                        RefocusUI();
                    }
                }
            });
    }

    public void RefocusUI()
    {
        if (instantiatedModals.Count > 0)
            instantiatedModals[instantiatedModals.Count - 1].GetComponent<ModalBehaviour>().SelectPrimaryHighlightedButton();
    }

    public void DisableBehindModalInteractables()
    {
        if (instantiatedModals.Count == 0)
            buttonOptionsOpen.SetActive(false);

        if (instantiatedModals.Count > 0)
            instantiatedModals[instantiatedModals.Count - 1].GetComponent<ModalBehaviour>().DisableAnswerButtons();
    }

    public bool IsOptionsModalCreated()
    {
        return instantiatedModals.Count > 0;
    }

    public bool IsUsingMouse()
    {
        return usingMouse;
    }
}
