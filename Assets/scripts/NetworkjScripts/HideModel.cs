using Unity.Netcode;
using UnityEngine;

public class HideModel : NetworkBehaviour
{
    [SerializeField]
    GameObject playerModel;

    void Start()
    {
        if (IsOwner)
        {
            playerModel.SetActive(false);
        }
    }
}
