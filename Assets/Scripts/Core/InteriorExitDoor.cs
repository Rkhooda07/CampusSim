using UnityEngine;
using UnityEngine.SceneManagement;

public class InteriorExitDoor : MonoBehaviour
{
    [Header("Exit Settings")]
    [SerializeField] private string campusSceneName;
    [SerializeField] private string campusSpawnPointName;

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
            SpawnManager.NextSpawnPointName = campusSpawnPointName;
            SceneManager.LoadScene(campusSceneName);
        }
    }
}