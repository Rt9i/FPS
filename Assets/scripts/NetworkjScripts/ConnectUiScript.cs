using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ConnectUiScript : MonoBehaviour
{
    [SerializeField]
    private Button hostButton;

    [SerializeField]
    private Button clientButton;

    void Start()
    {
        hostButton.onClick.AddListener(OnHostButtonClick);
        clientButton.onClick.AddListener(OnClientButtonClick);
    }

    private void OnHostButtonClick()
    {
        Debug.Log("Host button clicked");
        NetworkManager.Singleton.StartHost();
    }

    private void OnClientButtonClick()
    {
        Debug.Log("client button clicked");
        NetworkManager.Singleton.StartClient();
    }
}
