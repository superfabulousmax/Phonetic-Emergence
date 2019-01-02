using System.Collections;
using UnityEngine;

public class SoundController {

    private IKey _key;
    private AudioSource _audioSource;
    private float _sing; // urge to emit sound
    private float _threshold;
    private float percentage;
    private Blink _blinkController;
   

    public SoundController(IKey key, AudioSource audioSource, float sing, float threshold, Blink blinkController)
    {
        _key = key;
        _audioSource = audioSource;
        _sing = sing;
        _threshold = threshold;
        percentage = 10;
        _blinkController = blinkController;
    }

    public void EmitSound(float extra)
    {
        extra = Mathf.Min(1, extra);
        _sing += 1;// + extra;
        Debug.Log("sing: " + _sing);
        if(_sing >= _threshold)
        {
            float seconds = _key.MySound.length;
            _blinkController.BlinkColour(seconds);
            _audioSource.PlayOneShot(_key.MySound);
            _sing = 0;
            _blinkController.WaitBeforeNextBlink(0.05f);
        }

        if(_key.ReceivePulse)
        {
            _sing += (_sing / percentage);
        }
    } 

}
