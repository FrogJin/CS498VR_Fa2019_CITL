﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixPositionTrigger : MonoBehaviour {
    public static bool shouldFixPos = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shouldFixPos = true;
        }
    }
}
