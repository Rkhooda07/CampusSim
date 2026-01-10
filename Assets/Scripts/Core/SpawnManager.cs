using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static string NextSpawnPointName;

    void Start()
    {
        if (string.IsNullOrEmpty(NextSpawnPointName)) return;

        GameObject spawnPoint = GameObject.Find(NextSpawnPointName);
        if (spawnPoint != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = spawnPoint.transform.position;
            }
        }

        NextSpawnPointName = null;
    }
}