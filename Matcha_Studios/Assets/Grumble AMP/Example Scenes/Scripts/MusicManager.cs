using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	private float globalCrossFadeTime = 3f;
	private string globalCrossFadeTimeString = "3";
	private float defaultGlobalCrossFadeTime = 3f;
	private float fadeInTime = 0f;
	private string fadeInTimeString = "0";
	private float fadeOutTime = 4f;
	private string fadeOutTimeString = "4";
	private float masterVolume = 0.5f;
	private string masterVolumeString = "5";
	private float defaultMasterVolume = 5f;
	private int activeSong;
	private int activeLayer;
	enum PlayState
	{
		Stopped,
		FadingIn,
		FadingOut,
		Playing,
		Paused
	};
	private PlayState thePlayState = PlayState.Stopped;
	private float accumulatedDeltaTime;
	private float alarmAt;
	private bool alarmSet;




	// Drag the Music Player Game Object into this
	// in the inspector.  Or do a Search for it.
	public grumbleAMP gA;
	public grumbleAMP gAL1;
	public grumbleAMP gAL2;
	public grumbleAMP gAL3;
	public grumbleAMP gAL4;

	// PUBLIC COMMANDS
	// All references to the instance of the
	// adaptive music player are shown here
	// in functions describing the event in
	// which they would be called.

	void hitNewLayerButton(int layerNumber)
	{
		gA.CrossFadeToNewLayer(layerNumber);
	}

	void hitNewSongButton(int songNumber, int layerNumber)
	{
		gA.CrossFadeToNewSong(songNumber, layerNumber);
	}

	void hitFadeIn()
	{
		gA.PlaySong(activeSong, activeLayer, fadeInTime);
	}

	void hitPlayWhileStopped()
	{
		gA.PlaySong(activeSong, activeLayer);
	}

	void hitPlayWhilePaused()
	{
		gA.UnPause();
	}

	void hitPause()
	{
		gA.Pause();
	}

	void hitStop()
	{
		gA.StopAll();
	}

	void hitFadeOut()
	{
		gA.StopAll(fadeOutTime);
	}


	// ACCESSORS

	void setGlobalCrossFadeTime()
	{
		gA.setGlobalCrossFadeTime(globalCrossFadeTime);
	}

	void setGlobalCrossFadeTime(float crossFadeTime)
	{
		globalCrossFadeTime = crossFadeTime;
		gA.setGlobalCrossFadeTime(globalCrossFadeTime);
	}

	void setGlobalVolume()
	{
		gA.setGlobalVolume(masterVolume);
	}

	void setGlobalVolume(float volume)
	{
		masterVolume = Mathf.Clamp(volume, 0f, 1f);
		gA.setGlobalVolume(masterVolume);
	}

	int getNumberOfSongs()
	{
		return gA.songs.Length;
	}

	int getNumberOfLayersOfSong(int songNumber)
	{
		return gA.songs[songNumber].layer.Length;
	}

	float getLoopCrossFadeTime(int songNumber)
	{
		if (songNumber < gA.songs.Length && songNumber >= 0)
		{
			return gA.songs[songNumber].getLoopCrossfadeBy();
		}
		else
		{
			return 0f;
		}
	}

	bool setLoopCrossFadeTime(int songNumber, float newCrossFadeTime)
	{
		bool failure = false;
		if (songNumber < gA.songs.Length && songNumber >= 0)
		{
			gA.songs[songNumber].setLoopCrossfadeBy(newCrossFadeTime);
		}
		else
		{
			failure = true;
		}
		return failure;
	}

	float getLayerCrossFadeTime(int songNumber)
	{
		if (songNumber < gA.songs.Length && songNumber >= 0)
		{
			return gA.songs[songNumber].getLayerCrossfadeBy();
		}
		else
		{
			return 0f;
		}
	}

	bool setLayerCrossFadeTime(int songNumber, float newCrossFadeTime)
	{
		bool failure = false;
		if (songNumber < gA.songs.Length && songNumber >= 0)
		{
			gA.songs[songNumber].setLayerCrossfadeBy(newCrossFadeTime);
		}
		else
		{
			failure = true;
		}
		return failure;
	}
	// Start is called before the first frame update
	void Start()
	{
		gA.PlaySong(activeSong, activeLayer);

		gAL1.setGlobalVolume(0);
		gAL1.PlaySong(activeSong, activeLayer);
		gAL2.setGlobalVolume(0);
		gAL2.PlaySong(activeSong, activeLayer);
		gAL3.setGlobalVolume(0);
		gAL3.PlaySong(activeSong, activeLayer);
		gAL4.setGlobalVolume(0);
		gAL4.PlaySong(activeSong, activeLayer);
	}

	public void FireLayer2()
	{
		gAL1.setGlobalVolume(1);
	}
	public void FireLayer3()
	{
		gAL2.setGlobalVolume(1);
	}
	public void FireLayer4()
	{
		gAL3.setGlobalVolume(1);
	}
	public void FireLayer5()
	{
		gAL4.setGlobalVolume(1);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
