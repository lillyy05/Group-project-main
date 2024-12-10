using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRespawner : MonoBehaviour
{
    public GameObject dogPrefab; // Reference to the dog prefab
    public Transform spawnPoint; // Transform for the spawn location
    public float respawnDelay = 2f; // Delay before respawning the dog

    private GameObject currentDog; // Reference to the currently active dog

    // Start is called before the first frame update
    void Start()
    {
        SpawnDog(); // Spawn the initial dog
    }

    // Spawn the dog at thespawn point
    public void SpawnDog()
    {
        if (currentDog != null)
        {
            Destroy(currentDog); // Remove the existing dog
        }

        currentDog = Instantiate(dogPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // Trigger respawn process
    public void RespawnDog()
    {
        StartCoroutine(RespawnCoroutine());
    }

    // handle respawn delay
    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay); // Wait for the delay
        SpawnDog(); // Spawn the dog
    }
}
