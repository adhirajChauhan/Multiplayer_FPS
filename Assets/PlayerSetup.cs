using UnityEngine;
using UnityEngine.Networking;


public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsTDisable;

    private Camera sceneCamera;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsTDisable.Length; i++)
            {
                componentsTDisable[i].enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;

            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
            
        }
    }

    private void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
