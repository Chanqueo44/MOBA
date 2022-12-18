using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour {
    [Header("NPC Spawner Configuration")]
    [Tooltip("A refab list of NPCs that can be spawned. Spawner will destroy itself is this list is empty.")]
    public GameObject[] Spawnables;
    [Tooltip("A spawn interval in seconds. (5 sec by default)")]
    public float interval = 5f;
    [Tooltip("A spawn radius (a distance in which all NPCs will be spawned")]
    public float radius = 5f;
    [Tooltip("Maximum number of spawned NPCs (0 means infinity)")]
    public int maxNpcs = 0;
    [Tooltip("Distance to player when spawning begins")]
    public float playerDistance = 20f;
    [Tooltip("Game player object for distance reference")]
    public GameObject player;

    private int currentSpawned = 0;
    private bool canSpawn = true;

	// Use this for initialization
	void Start () {
        if (Spawnables.Length == 0)
        {
            Destroy(this);
            return;
        }
        StartCoroutine("spawnerJob");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, playerDistance);
    }

    public IEnumerator spawnerJob()
    {
        while (canSpawn)
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) <= playerDistance)
            {
                yield return new WaitForSeconds(interval);
                GameObject currentNpc = Spawnables[Random.Range(0, Spawnables.Length - 1)];
                Instantiate(currentNpc, this.transform.position + Random.insideUnitSphere * radius, currentNpc.transform.rotation).name = "Spawned NPC";
                currentSpawned++;
                canSpawn = (currentSpawned <= maxNpcs) || (maxNpcs == 0);
            }
        }
    }
}