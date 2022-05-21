using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Audio/AudioSourceEx")]
[RequireComponent(typeof(AudioSource))]


public class AudioSourceEx : MonoBehaviour 
{
	public enum SelectionType //an enum for all the different forms of random playback
	{
		stStandard = 0, //purely random selection
		stNoRepeat, //random, but the same clip is not repeated twice in a row
		stShuffle, //random, but dont repeat a clip until they have all been played
		stSequential //plays the clips in a sequential order
	};
	public SelectionType clipSelectionMode = SelectionType.stStandard; //Lets the user select a form of random playback
	public bool RandomPitch = false; //if bool is checked, will play the sound at a random range as specified by pitch min and max
	public bool RandomVolume = false; //if bool is checked, will play the sound at a random range as specified by vol min and max
	public float PitchSelect = 0; //used to specify a specific pitch that the user wants the sound played at, if not random
	public float pitchMin = 0; //pitchmin and max let the user set up random pitch variation in a range
	public float pitchMax = 0;
	public float pitchRandomRolls = 1; //ammount of rolls to input to the roll variable of randomex when randomizing pitch
	public float VolumeSelect = 1; //Lets user specify the specific volume they want the sound to play at
	public float volMin = 1;//VolMin and max are used to specify the offset in db to be applied to volumeselect at random
	public float volMax = 1;
	public float volRandomRolls = 1; //ammount of rolls to input the the roll variable of randomex when randomizing volume
	private int PreviousSound = -1;
	private int SequenceCount = 0;
	public AudioClip[] clips;
	public AudioSource Source;

	// Use this for initialization
	void Start () 
	{
		Source = GetComponent<AudioSource> ();

		//Reminds the user to set an audio source if there is none
		if (Source == null) 
		{
			Debug.LogError ("No Audio Source Has Been Detected");
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Play ()
	{
		if (Source.isPlaying) //makes sure that audio cues cannot infinitely layer
		{
			Source.Stop ();
		}

		//if statements using the SelectionType enum to produce the desired randomness
		if (clipSelectionMode == SelectionType.stStandard) 
		{
			Source.clip = clips [(int)HelperFunctions.RandomEx (0f, clips.Length)];
			//Plays clips entirely at random
		} 
			
		else if (clipSelectionMode == SelectionType.stNoRepeat) 
		{
			int i = (int)HelperFunctions.RandomEx (0f, clips.Length);
			if (i == PreviousSound) 
			{
				i++;
				i %= clips.Length;
			}
			Source.clip = clips [i];
			PreviousSound = i;
			//Makes sure clips don't play twice in a row
		} 

		else if (clipSelectionMode == SelectionType.stShuffle) 
		{
			
		}

		else if (clipSelectionMode == SelectionType.stSequential) 
		{
			if (SequenceCount >= clips.Length) 
			{
				SequenceCount = 0;
			}

			Source.clip = clips [SequenceCount];
			++SequenceCount;
		}

		//Plays audio at a specific pitch, or at random from a determined range
		if (RandomPitch == false) 
		{
			
			Mathf.Clamp (PitchSelect, -12f, 12f);//makes sure pitch can only be set in a range of 2 octaves
		
			Source.pitch = HelperFunctions.SemitonesToPitch(PitchSelect);
		}

		else if (RandomPitch == true) 
		{
			Mathf.Clamp (pitchMin, -12f, 12f);//these two lines are ditto of what
			Mathf.Clamp (pitchMin, -12f, 12f);//was done for the pitchselect variable
		
			Source.pitch = HelperFunctions.SemitonesToPitch 
				(HelperFunctions.RandomEx (pitchMin, pitchMax, (int)pitchRandomRolls));
		}

		if (RandomVolume == false) 
		{
			Source.volume = HelperFunctions.dBToGain (VolumeSelect);
		} 

		else if (RandomVolume == true) 
		{
			Source.volume = HelperFunctions.dBToGain (VolumeSelect) + HelperFunctions.dBToGain 
				(HelperFunctions.RandomEx (volMin, volMax, (int)volRandomRolls));
		}
			
		Source.Play();
	}

	public void Play(int ChooseClip)
	{
		if (Source.isPlaying) 
		{
			Source.Stop ();
		}

		Source.clip = clips [ChooseClip];
		Source.Play ();
	}
}
