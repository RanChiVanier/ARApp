﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Calculation Credit: https://blog.falafel.com/displaying-device-compass-unity    */
/* This script is attached to an object (arrow sprite) that will move acccordingly */
/* depending on the value read. Will make the sprite point to specific angles      */
/* are where the cabinets.                                                         */

public class position : MonoBehaviour
{
	public Dropdown dropdown;

    // Use this for initialization
    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        var xrot = Mathf.Atan2(Input.acceleration.z, Input.acceleration.y);
        var yzmag = Mathf.Sqrt(Mathf.Pow(Input.acceleration.y, 2) + Mathf.Pow(Input.acceleration.z, 2));
        var zrot = Mathf.Atan2(Input.acceleration.x, yzmag);

        var xangle = xrot * (180 / Mathf.PI) + 90;
        var zangle = -zrot * (180 / Mathf.PI);

			//no arrows for all
			if (dropdown.value == 0) 
		{
		}
			//arrow for 4 cabinet
			if ((dropdown.value == 1) || (dropdown.value == 2) || (dropdown.value == 3) || (dropdown.value == 4)) 
		{
			transform.eulerAngles = new Vector3 ((xangle - (xangle % 1)), 0, ((zangle - Input.compass.trueHeading) - ((zangle - Input.compass.trueHeading) % 1)) - 70);
		}
			//arrow for 3 desk
			if ((dropdown.value == 5) || (dropdown.value == 6) || (dropdown.value == 7)) 
		{
			transform.eulerAngles = new Vector3 ((xangle - (xangle % 1)), 0, ((zangle - Input.compass.trueHeading) - ((zangle - Input.compass.trueHeading) % 1)) - 110);
		}
			//arrow for right wood cabinet
			if ((dropdown.value == 8) || (dropdown.value == 9)) 
		{
			transform.eulerAngles = new Vector3 ((xangle - (xangle % 1)), 0, ((zangle - Input.compass.trueHeading) - ((zangle - Input.compass.trueHeading) % 1)) - 170);
		}
			//arrow for left wood cabinet
			if ((dropdown.value == 10) || (dropdown.value == 11)) 
		{
			transform.eulerAngles = new Vector3 ((xangle - (xangle % 1)), 0, ((zangle - Input.compass.trueHeading) - ((zangle - Input.compass.trueHeading) % 1)) - 260);
		}
    }
}
