using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Rigidbody sphereRigidbody;
    private AddressablesManager modalAddressablesManager;
    [SerializeField] private AssetReferenceGameObject modelOptions;

    private void Awake()
    {
        sphereRigidbody = GetComponent<Rigidbody>();

        PlayerInputActions controlsInputActions = new PlayerInputActions();
        controlsInputActions.Enable();
        controlsInputActions.Player.Settings.performed += OpenSettings;
        controlsInputActions.Player.Move.performed += MovePlayer;
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
        if (!modalAddressablesManager.IsOptionsModalCreated())
            modalAddressablesManager.CreateModal(modelOptions);
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        sphereRigidbody.AddForce(new Vector3(movementInput.x, 0, movementInput.y) * moveSpeed, ForceMode.Force);
    }
}