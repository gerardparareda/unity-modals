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

    public InputActions controlsInputActions;
    [SerializeField] private Button primaryHighlightedButton;

    public void Test(InputAction.CallbackContext context)
    {
        Debug.Log("Nativation performed");
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

    void FixedUpdate()
    { 
        // Control what to do if the mouse gains focus and then the user decides to use Keyboard or Gamepad
        /*if (Keyboard.current.anyKey.wasPressedThisFrame && EventSystem.current.currentSelectedGameObject == null)
        {
            primaryHighlightedButton.Select();
        }*/

        // Currently no 'Gamepad.current.anyButton' exists
        InputSystem.onAnyButtonPress.Call(
            ctrl =>
            {
                if ((ctrl.device is Gamepad || ctrl.device is Keyboard) && EventSystem.current.currentSelectedGameObject == null)
                {
                    if (modalAddressablesManager.IsLastModal(gameObject))
                        primaryHighlightedButton.Select();
                }
            });
    }

    public Button GetPrimaryHighlightedButton()
    {
        return primaryHighlightedButton;
    }
}
