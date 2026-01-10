using UnityEngine;
using UnityEngine.SceneManagement;

public class InteriorExitDoor : MonoBehaviour
{
    [SerializeField] private string exteriorSceneName = "CampusScene";
    [SerializeField] private string spawnPointName = "Spawn_InteriorExit_BunnyKitchen";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnManager.NextSpawnPointName = spawnPointName;
            SceneManager.LoadScene(exteriorSceneName);
        }
    }
}