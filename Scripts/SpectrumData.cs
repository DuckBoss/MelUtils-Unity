using UnityEngine;

public class SpectrumData {
    private float[] GetSpectrum(AudioSource audioSource, float[] samples) {
        audioSource.GetSpectrumData(samples, 0, channelWindow);
        return samples;
    }
}
