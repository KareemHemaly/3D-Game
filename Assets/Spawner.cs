using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;
    //public GameObject replacment;
    public int numberOfBoxes;
    public Transform forGift;
    public GameObject gift;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfBoxes; i++)
        {
            change_positions();
            Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
            Instantiate(gift, forGift.position, forGift.rotation);
            Debug.Log("position " + i + ":" + spawnPos.position);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void change_positions()
    {
        float x = Random.Range(300f, 900f);
        float z = Random.Range(265f, 800f);

        float y = 398.6f;
        Vector3 pos = new Vector3(x, y, z);
        spawnPos.position = pos;

        float ygift = 401f;
        Vector3 posgift = new Vector3(x, ygift, z);
        forGift.position = posgift;
    }
}
