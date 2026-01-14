using UnityEngine;
using UnityEngine.SceneManagement;

public class InteriorExitDoor : MonoBehaviour
{
    [Header("Exit Settings")]
    [SerializeField] private string campusSceneName = "CampusScene";
    [SerializeField] private string campusSpawnPointName = "Spawn_InteriorEntry_BunnyKitchen";

    private Interactable interactable;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if (interactable != null && interactable.CanInteract())
        {
            SpawnManager.NextSpawnPointName = campusSpawnPointName;
            SceneManager.LoadScene(campusSceneName);
        }
    }
}