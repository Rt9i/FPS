using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] InputAction leftClick;

    public bool shoot = false;

    void OnEnable()
    {
        leftClick.Enable();
    }


    void Update()
    {
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
