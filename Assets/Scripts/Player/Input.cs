using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{

    
    private AddressablesManager modalAddressablesManager;
    [SerializeField] private AssetReferenceGameObject modelOptions;

    private void Awake()
    {
        PlayerInputActions controlsInputActions = new PlayerInputActions();
        controlsInputActions.Enable();
        controlsInputActions.Player.Settings.performed += OpenSettings;
    }

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

    private void OpenSettings(InputAction.CallbackContext context)
    {
        modalAddressablesManager.CreateModal(modelOptions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
