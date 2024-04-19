using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float threshold;


    void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(15f, 1f, 0f);
        }
                
                


    }
}
