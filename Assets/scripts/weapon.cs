using UnityEngine;

public class weapon : MonoBehaviour
{

    [SerializeField] PlayerInputs playerInputs;
    [SerializeField] Camera cam;
    [SerializeField] AudioSource gunShotSFX;
    bool shoot;
    float damage = 10;
    RaycastHit hit;
    void Update()
    {
        if (playerInputs.shoot)
        {
            gunShotSFX.Play();
            if (!Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity)) return;

            shoot = playerInputs.shoot;

            Debug.Log("hit a: " + hit.collider.name);
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                hit.collider.gameObject.GetComponent<health>().Damage(damage);
            }




        }


    }
}
