#define TESTDLLSORT_API __declspec(dllexport) 

extern "C" {
	TESTDLLSORT_API float clamp(float x, float lower, float upper);
	TESTDLLSORT_API float ExecuteMel(float samples[], int lowerSampleLimit, int upperSampleLimit, float scaleLimit);
	TESTDLLSORT_API float MelScale(float _Strength, int _StrongestBin, int sampleCounts);
	TESTDLLSORT_API int GetStrongestBin(float _Samples[], int _Bottom, int _Top);
	TESTDLLSORT_API float GetStrongestBinStrength(float _Samples[], int _Bottom, int _Top);
}
