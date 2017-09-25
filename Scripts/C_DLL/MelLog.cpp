#include "MelLog.h"
#include <algorithm>
#include <stdio.h>
 
extern "C" {

	float clamp(float x, float lower, float upper)
	{
		float newVal = x;
		if (newVal <= lower)
			newVal = lower;
		if (newVal >= upper)
			newVal = upper;

		return newVal;
	}

	float ExecuteMel(float samples[], int lowerSampleLimit, int upperSampleLimit, float scaleLimit) {
		int _StrongestBin = GetStrongestBin(samples, lowerSampleLimit, upperSampleLimit);
		float _BinStrength = GetStrongestBinStrength(samples, lowerSampleLimit, upperSampleLimit);
		float val = clamp( (_BinStrength * MelScale(_BinStrength, _StrongestBin, sizeof(samples)/sizeof(samples[0]) )), 0, scaleLimit);
		return val;
	}

	float MelScale(float _Strength, int _StrongestBin, int sampleCounts) {
		float _Frequency = _StrongestBin * (44100 / sampleCounts) + 2000 / (_StrongestBin + 1);
		_Strength = 1127 * log(1 + (_Frequency / 700));

		return _Strength;
	}

	//Get Strongest bin and return it.
	int GetStrongestBin(float _Samples[], int _Bottom, int _Top) {
		float _Strength = 0;
		int _StrongestIndex = 0;
		for (int i = _Bottom;
			i < _Top;
			++i)
		{
			if (_Strength < _Samples[i])
			{
				_Strength = _Samples[i];
				_StrongestIndex = i;
			}
		}
		return _StrongestIndex;
	}

	//Get strength of strongest bin and return it.
	float GetStrongestBinStrength(float _Samples[], int _Bottom, int _Top) {
		float _Strength = 0;
		for (int i = _Bottom;
			i < _Top;
			++i)
		{
			if (_Strength < _Samples[i])
			{
				_Strength = _Samples[i];
			}
		}
		return _Strength;
	}

}
