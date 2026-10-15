using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;

public class ServerManager : MonoBehaviour
{
    private static ServerManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private async void Start()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        Debug.Log(AuthenticationService.Instance.PlayerId);

        var rankingData = await CloudSaveService.Instance.Data.Custom.LoadAllAsync("FandomRanking");

        if (rankingData.TryGetValue("akfh", out var akfhData))
        {
            int akfhScore = akfhData.Value.GetAs<int>();
            Debug.Log("akfh 점수: " + akfhScore);
        }       
    }
}
