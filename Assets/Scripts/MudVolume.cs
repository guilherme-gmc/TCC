﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudVolume : MonoBehaviour
{

	public Slider Volume;
	public AudioSource myMusic;

	void Update(){

		myMusic.volume=Volume.value;

	}
}
