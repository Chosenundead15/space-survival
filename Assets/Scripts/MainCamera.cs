using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public Transform player;
    Vector3 offset = new Vector3(0, 0, -10);
    Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, 0.1f);
    }
}
