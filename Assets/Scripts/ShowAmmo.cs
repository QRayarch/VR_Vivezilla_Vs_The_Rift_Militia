﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowAmmo : MonoBehaviour {

    public GunStuff gun;
    public Slider slider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = gun.NormalizedAmmo;  

    }
}
