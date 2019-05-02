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
    private GameObject player;
    private List<GameObject> boxes;
    private List<GameObject> gifts;
    public static int gold = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("aj");
        boxes = new List<GameObject>();
        gifts = new List<GameObject>();
        for (int i = 0; i < numberOfBoxes; i++)
        {
            change_positions();
            GameObject g1 = Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
            GameObject g2 = Instantiate(gift, forGift.position, forGift.rotation);
            boxes.Add(g1);
            gifts.Add(g2);
            Debug.Log("position " + i + ":" + spawnPos.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (boxes.Count > 0)
        {
            destroy_closest();
        }
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

    void destroy_closest()
    {
        /*foreach(GameObject item in boxes)
        {
            if (item != null)
            {
                //Debug.Log("name:" + item.transform.position);
                if (Vector3.Distance(player.transform.position, item.transform.position) <= 7)
                {
                    Destroy(item);
                }
            }
        }*/
        foreach (GameObject item in gifts)
        {
            if (item != null)
            {
                //Debug.Log("name:" + item.transform.position);
                if (Vector3.Distance(player.transform.position, item.transform.position) <= 7)
                {
                    Destroy(item);
                    gold++;
                }
            }
        }

    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;
        GUILayout.Label("<size=25>your gold score: <color=yellow>"+gold+"</color></size>", style);
    }

}
