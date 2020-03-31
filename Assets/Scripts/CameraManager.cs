﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.orthographicSize = PlayerController.instance.transform.localScale.x*2f + 5f;
    }
}
