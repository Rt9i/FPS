using Unity.Netcode;
using UnityEngine;

public class weapon : NetworkBehaviour
{
    [SerializeField]
    PlayerInputs playerInputs;

    [SerializeField]
    Camera cam;

    [SerializeField]
    AudioSource gunShotSFX;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    float fireDelay = 0.25f;
    RaycastHit hit;

    // float damage = 10f;
    float nextFireTime = 0f;

    void Update()
    {
        if (!IsOwner)
        {
            animator.enabled = false;
            return;
        }

        if (!playerInputs.shoot || Time.time < nextFireTime)
            return;

        nextFireTime = Time.time + fireDelay;

        animator.Play("Fire_animation");
        gunShotSFX.Play();

        if (
            !Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity)
        )
            return;
    }
}
