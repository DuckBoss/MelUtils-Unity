using UnityEngine;

namespace JJAudioUtils {
	public static class MelLog {

		/*
		 * Special thanks to Unity communities for solving MEL calculation issues!
		 */

		//returns the mel-adjusted float value given the samples, limits, and scale limit.
		public static float ExecuteMel(float[] samples, int lowerSampleLimit, int upperSampleLimit, float scaleLimit) {
			int _StrongestBin = GetStrongestBin (samples, lowerSampleLimit, upperSampleLimit );
			float _BinStrength = GetStrongestBinStrength (samples, lowerSampleLimit, upperSampleLimit );
			float val = Mathf.Clamp( ( ( _BinStrength * MelScale ( _BinStrength, _StrongestBin, samples.Length ) ) ), 0f, scaleLimit );
			return val;
		}
		
		public static float[] ExecuteLog(float[] samples) {
			for(int i = 0; i < samples.Length; i++) {
				if(i != 0)
					samples[i] *= (1 + Mathf.Log(i))/2;
				if(i == 0)
					samples[i] *= 1;
			}
			return samples;
		}


		//Logarithmically scales strength based on the frequency of the strongest sample to immitate human hearing range.
		//Return scaled strength.
		private static float MelScale ( float _Strength, int _StrongestBin, int sampleCounts ) {
			float _Frequency = _StrongestBin * ( 44100 / sampleCounts ) + 2000f / ( _StrongestBin + 1 );
			_Strength = 1127 * Mathf.Log ( 1 + ( _Frequency / 700f ) );

			return _Strength;
		}

		//Get strongest bin (the frequency range with the strongest signal) between _Bottom and _Top and return it.
		private static int GetStrongestBin ( float[] _Samples, int _Bottom, int _Top ) {
			float _Strength = 0f;
			int _StrongestIndex = 0;
			for ( int i = _Bottom; i < _Top; ++i ) {
				if ( _Strength < _Samples[ i ] ) {
					_Strength = _Samples[ i ];
					_StrongestIndex = i;
				}
			}
			return _StrongestIndex;
		}

		//Get strength of strongest bin and return it.
		private static float GetStrongestBinStrength ( float[] _Samples, int _Bottom, int _Top ) {
			float _Strength = 0f;
			for ( int i = _Bottom; i < _Top; ++i ) {
				if ( _Strength < _Samples[ i ] ) {
					_Strength = _Samples[ i ];
				}
			}
			return _Strength;
		}


	}
}
