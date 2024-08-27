using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChunkRandomiser : MonoBehaviour
{
    public List<GameObject> listChunks = new List<GameObject>();

    [SerializeField] private Transform firstPosition;
    [SerializeField] private Transform secondPosition;
    [SerializeField] private Transform thirdPosition;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject goToSpawn = listChunks[Random.Range(0, listChunks.Count)];
        //Instantiate(goToSpawn, transform.position, Quaternion.identity);
        //Destroy(gameObject);

        SpawnChunk1();
        SpawnChunk2();
        SpawnChunk3();

    }

    private void SpawnChunk1()
    {
        //Randomly select a LevelChunk from the list, and instantiate it at the first chunk position
        GameObject firstSpawn = listChunks[Random.Range(0, listChunks.Count)];
        Instantiate(firstSpawn, firstPosition.position, Quaternion.identity);

        //remove the spawned chunk from the spawnable list, then destroy it's spawn location
        listChunks.Remove(firstSpawn);
        Destroy(firstPosition.gameObject);
    }

    private void SpawnChunk2()
    {
        // Randomly select and instantiate a chunk from the remaining chunks
        GameObject secondSpawn = listChunks[Random.Range(0, listChunks.Count)];
        Instantiate(secondSpawn, secondPosition.position, Quaternion.identity);

        //remove the spawned chunk from the spawnable list, then destroy it's spawn location
        listChunks.Remove(secondSpawn);
        Destroy(secondPosition.gameObject);
    }

    private void SpawnChunk3()
    {
        //Spawn the final level chunk in the avaliable list
        GameObject thirdSpawn = listChunks[Random.Range(0, listChunks.Count)];
        Instantiate(thirdSpawn, thirdPosition.position, Quaternion.identity);

        //remove the spawned chunk from the spawnable list, then destroy it's spawn location
        listChunks.Remove(thirdSpawn);
        Destroy(thirdPosition.gameObject);
    }
}
