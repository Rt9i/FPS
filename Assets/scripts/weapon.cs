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
            shoot = playerInputs.shoot;
            gunShotSFX.Play();
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity);


            if (hit.collider)
            {
                Debug.Log("hit a: " + hit.collider.name);
                // if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                // {
                //     hit.collider.gameObject.GetComponent<robot>().enabled = false;
                // }

                shoot = playerInputs.shoot;

                Debug.Log("hit a: " + hit.collider.name);
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    hit.collider.gameObject.GetComponent<health>().Damage(damage);
                }
            }

        }
    }
}
