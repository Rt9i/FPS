using Unity.Netcode;
using UnityEngine;

public class PlayerMovementAnimator : NetworkBehaviour
{
    [SerializeField]
    Animator animator;
    Movment MovmentScript;
    bool previousIsMoving = false;

    void Start()
    {
        if (!IsOwner)
            return;
        MovmentScript = GetComponent<Movment>();
    }

    void Update()
    {
        if (!IsOwner)
            return;
        Vector2 movementVector = MovmentScript.movment.ReadValue<Vector2>();
        bool currentIsMoving = movementVector.magnitude > 0f;

        if (currentIsMoving != previousIsMoving)
        {
            animator.SetBool("IsMoving", currentIsMoving);
            previousIsMoving = currentIsMoving;
        }
    }
}
