using UnityEngine;
using UnityEngine.SceneManagement;

public class CampusDoor : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] private string interiorSceneName;
    [SerializeField] private string interiorSpawnPointName;

    private Interactable interactable;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if (interactable == null) return;

        if (interactable.CanInteract() && Input.GetKeyDown(KeyCode.E))
        {
            SpawnManager.NextSpawnPointName = interiorSpawnPointName;
            SceneManager.LoadScene(interiorSceneName);
        }
    }
}