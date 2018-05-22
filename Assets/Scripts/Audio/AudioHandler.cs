using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour {

	public AudioSource audioSource;

	public enum ClipAccessType {
		random,
		sequential,
		custom
	};

	public ClipAccessType clipPlayOrder = ClipAccessType.random;

	public AudioClip[] clips;


	private int numberOfClips;
	private int indexOfClipToPlay;

	void Start () {
		indexOfClipToPlay = 0;
		numberOfClips = clips.Length;
	}
	
	public void playClip() {
		if (clips.Length == 0) return;

		if (clipPlayOrder == ClipAccessType.random) {
			indexOfClipToPlay = (int)(Random.value * (float)(numberOfClips - 1));
			audioSource.clip = clips[indexOfClipToPlay];
			audioSource.Play();
		}
		else if (clipPlayOrder == ClipAccessType.sequential) {
			audioSource.clip = clips[indexOfClipToPlay];
			audioSource.Play();

			indexOfClipToPlay++;
			if (indexOfClipToPlay >= numberOfClips) indexOfClipToPlay = 0;
		}
		else if (clipPlayOrder == ClipAccessType.custom) {
			audioSource.clip = clips[indexOfClipToPlay];
			audioSource.Play();
		}
	}

	public void pauseClip() {
		audioSource.Pause();
	}

	public void unpauseClip() {
		audioSource.UnPause();
	}

	public void stopClip() {
		audioSource.Stop();
	}

	public void setClipPlayOrder(ClipAccessType order) {
		clipPlayOrder = order;
	}

	public void setClipIndex(int index) {
		indexOfClipToPlay = index;
	}

	public void setVolume(float volume) {
		audioSource.volume = volume;
	}

	public void setClips(AudioClip[] newClips) {
		clips = newClips;
	}

	public bool isPlayingClip() {
		return audioSource.isPlaying;
	}
}
