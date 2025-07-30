using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] PlayerInputs playerInputs;
    [SerializeField] Camera cam;
    [SerializeField] AudioSource gunShotSFX;
    [SerializeField] private Animator animator;
    [SerializeField] float fireDelay = 0.25f;
    RaycastHit hit;
    float damage = 10f;
    float nextFireTime = 0f;

    void Update()
    {
        if (!playerInputs.shoot || Time.time < nextFireTime) return;


        nextFireTime = Time.time + fireDelay;
        Debug.Log("playing animation");
        animator.Play("Fire_animation");
        gunShotSFX.Play();

        if (!Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity)) return;

        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy") && hit.collider.gameObject.CompareTag("Robot"))
        {
            Debug.Log("hit a: " + hit.collider.name);
            hit.collider.gameObject.GetComponent<health>().Damage(damage);
        }


    }
}
