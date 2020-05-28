using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int[,] a_Map;
    public GameObject m_Map;

    [Header("맵크기")]
    public int Width_x = 0;
    public int Width_z = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int x=0; x< Width_x; x++)
        {
            for(int z=0; z< Width_z; z++)
            Instantiate(m_Map, new Vector3( x, transform.position.y, z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
