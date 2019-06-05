using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    public GameObject wall;
    public GameObject platform;
    private bool check_hole = true;
    private Vector3 pos;
    private int x = 0;
     
    void Start()
    {
        GenerateLevel();
    }


    void Update()
    {
        StartCoroutine(GenerateLevel());
        transform.position -= transform.forward * 5f * Time.deltaTime;
    }
    IEnumerator GenerateLevel()
    {
        while (true)
        {
            CreateWall();
            yield return new WaitForSeconds(3f);
        }
    }

    void CreateWall()
    {
        if (x < 20)
        {
            for (x = 0; x <= 20; x += 2)
            {
                pos = new Vector3(x - 10f, .5f, 15);
                Instantiate(wall, pos, Quaternion.identity, transform);
                if (Random.value > .7f && check_hole)
                {
                    check_hole = false;
                    x += 2;
                }
            }
            Debug.Log(x);
        }
    }
}
