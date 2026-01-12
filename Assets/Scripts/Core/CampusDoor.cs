using UnityEngine;
using UnityEngine.SceneManagement;

public class CampusDoor : MonoBehaviour
{
    [SerializeField] private string interiorSceneName = "Bunny_Kitchen";
    [SerializeField] private string interiorSpawnPointName = "Spawn_InteriorEntry_BunnyKitchen";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnManager.NextSpawnPointName = interiorSpawnPointName;
            SceneManager.LoadScene(interiorSceneName);
        }
    }
}