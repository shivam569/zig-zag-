using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    Vector3 lastPosition;
    float size;
    public GameObject platform;
    public GameObject diamond;
    public bool gameOver;

   
    void Start()
    {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x;

        for(int i = 0; i < 25; i++)
        {
            SpawnPlatforms();
        }      
    }

  
    void Update()
    {
        if(GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    // 
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 2f, 0.3f);
    }



    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if(rand < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }

    
    void SpawnX()
    {
        Vector3 pos = lastPosition;
        pos.x += size;
        lastPosition = pos;

        
        Instantiate(platform, pos, Quaternion.identity);

        int diamondRandom = Random.Range(0, 4);

        if(diamondRandom == 0)
        {
            Instantiate(diamond, new Vector3(pos.x, (pos.y + 1), pos.z), diamond.transform.rotation);
        }
    }

   
    void SpawnZ()
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        lastPosition = pos;

     
        Instantiate(platform, pos, Quaternion.identity);

       
        int diamondRandom = Random.Range(0, 4);
        if (diamondRandom == 0)
        {
            Instantiate(diamond, new Vector3(pos.x, (pos.y + 1), pos.z), diamond.transform.rotation);
        }
    }
}
