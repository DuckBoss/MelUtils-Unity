export const ExecuteMel = (samples_float_arr, lowerSampleLimit, upperSampleLimit, scaleLimit) => {
    let _strongestBin = GetStrongestBin(samples_float_arr, lowerSampleLimit, upperSampleLimit);
    let _binStrength = GetStrongestBinStrength(samples_float_arr, lowerSampleLimit, upperSampleLimit);
    let val = Math.min(Math.max(_binStrength * MelScaleStrength(_binStrength, _strongestBin, samples_float_arr.length), 0.0), scaleLimit);
    return val;
}

export const ExecuteLog = (samples_float_arr) => {
    for (let i = 0; i < samples_float_arr.length; i++) {
        if (i !== 0) {
            samples_float_arr[i] *= (1 + Math.log(i))/2;
        }
        if (i === 0) {
            samples_float_arr[i] *= 1;
        }
    }
    return samples_float_arr;
}

export const MelScaleStrength = (strength, strongest_bin, sample_counts) => {
    let _frequency = strongest_bin * (44100 / sample_counts) + 2000.0 / (strongest_bin + 1);
    strength = 1127 * Math.log(1 + (_frequency / 700.0));
    return strength;
}

export const GetStrongestBin = (samples_float_arr, bottom, top) => {
    let _strength = 0.0;
    let strongest_index = 0;
    for (let i = bottom; i < top; ++i) {
        if (_strength < samples_float_arr[i]) {
            _strength = samples_float_arr[i];
            strongest_index = i;
        }
    }
    return strongest_index;
}

export const GetStrongestBinStrength = (samples_float_arr, bottom, top) => {
    let _strength = 0.0;
    for (let i = bottom; i < top; ++i) {
        if (_strength < samples_float_arr[i]) {
            _strength = samples_float_arr[i];
        }
    }
    return _strength;
}
