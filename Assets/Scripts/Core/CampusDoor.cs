using UnityEngine;
using UnityEngine.SceneManagement;

public class CampusDoor : Interactable
{
    [SerializeField] private string interiorSceneName = "Bunny_Kitchen";
    [SerializeField] private string interiorSpawnPointName = "Spawn_InteriorEntry_BunnyKitchen";

    private void Update()
    {
        if (CanInteract())
        {
            SpawnManager.NextSpawnPointName = interiorSpawnPointName;
            SceneManager.LoadScene(interiorSceneName);
        }
    }
}