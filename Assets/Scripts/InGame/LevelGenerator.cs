using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int[,] a_Map;
    public GameObject m_Map;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<100; i++)
        {
            for(int j=0; j<100; j++)
            Instantiate(m_Map, new Vector3(transform.position.x *22* j, transform.position.y, transform.position.z* 1.5f * i), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
