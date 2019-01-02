using UnityEngine;

public interface IKey
{
    AudioClip Root { get; }
    AudioClip Second { get; }
    AudioClip Third { get; }
    AudioClip Fourth { get; }
    AudioClip Fifth { get; }
    AudioClip Sixth { get; }
    AudioClip Seventh { get; }
    AudioClip MySound { get; set; }
    Color MyColor { get; set; }
    bool ReceivePulse { get;  set; }   
}
