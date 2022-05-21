using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class HelperFunctions 
{
	
	/*-----------------------------------------------*/


	/*This function takes a float value in dBfs 
	 * and converts it to a gain value of 0-1*/

	static public float dBToGain(float dB)
	{
		float Gain;
		Gain = Mathf.Pow (10, dB / 20);
		return Gain;
	}


	/*-----------------------------------------------*/


	/*This function takes a pitch value in semitones
	up to 2 octaves in range (values -12.00 to 12.00)
	to convert from cents to a Unity pitch value*/

	static public float SemitonesToPitch(float semitones)
	{
		float UnityPitch = Mathf.Pow (2f, semitones / 12f);
		return UnityPitch;
	}


	/*-----------------------------------------------*/

	/*This function generates 2 different kinds of random numbers.
	First is an equal distribution, the second is a weighted distribution*/

	static public float RandomEx(float min, float max, int rolls = 1)
	{
		float RandNum = 0;
		float total = 0;
		float avg = 0;

		if (rolls == 1) 
		{
			avg = Random.Range (min, max);
			return avg;
		}
	

		else if (rolls > 1) 
		{
			for (int i = 1; i <= rolls; ++i) 
			{
				RandNum = Random.Range (min, max);
				total += RandNum;
			}
			avg = (total / rolls);
			return avg;
		}
		return avg;
	}
}
