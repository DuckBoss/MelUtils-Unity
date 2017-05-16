using UnityEngine;

namespace JJAudioUtils {
	public class SpectrumData {
	    public float[] GetSpectrum(AudioSource audioSource, float[] samples) {
		audioSource.GetSpectrumData(samples, 0, channelWindow);
		return samples;
	    }

	    public IEnumerator LoadSongFromPath(string path, AudioSource audioSource) {
			WWW www = new WWW("file:///" + path);
			while(!www.isDone) {
				yield return null;
			}

			audioSource.clip = www.GetAudioClip(false,true);
			yield return null;
	    }
	}
}

