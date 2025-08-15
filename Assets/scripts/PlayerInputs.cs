using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : NetworkBehaviour
{
    [SerializeField] InputAction leftClick;
  
    public bool shoot = false;

    void OnEnable()
    {
        leftClick.Enable();
    }

    void OnDisable()
    {
        leftClick.Disable();
    }

    void Update()
    {
        if (!IsOwner)
            return;

        if (leftClick.WasPressedThisFrame())
        {
            shoot = true;
        }
        else
        {
            shoot = false;
        }
    }
}
