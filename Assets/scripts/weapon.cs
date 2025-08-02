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
        if (playerInputs.shoot)
        {
            shoot = playerInputs.shoot;
            
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity);


            if (hit.collider)
            {
                Debug.Log("hit a: " + hit.collider.name);
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    hit.collider.gameObject.GetComponent<robot>().enabled = false;
                }

            shoot = playerInputs.shoot;

            Debug.Log("hit a: " + hit.collider.name);
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                hit.collider.gameObject.GetComponent<health>().Damage(damage);
            }




        }
    }
}
