using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChunkRandomiser : MonoBehaviour
{
    public List<GameObject> listChunks = new List<GameObject>();    

    // Start is called before the first frame update
    void Start()
    {
        GameObject goToSpawn = listChunks[Random.Range(0, listChunks.Count)];
        Instantiate(goToSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
