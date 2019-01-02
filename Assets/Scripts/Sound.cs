/*
*
* Class using humble object pattern
* with a key inteface and a sound controller to emit sounds
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour, IKey {

    private SoundController _soundController;
    private AudioSource audioSource;
    private Blink blinkController;
    private int colourNum;
    private float urgeToSing;
    private float giveExtraUrge;
    [SerializeField]
    private float threshold;
    //implement the interface
    [SerializeField]
    private AudioClip root;
    public AudioClip Root { get { return root;  } }
    [SerializeField]
    private AudioClip second;
    public AudioClip Second { get { return second; } }
    [SerializeField]
    private AudioClip third;
    public AudioClip Third { get { return third; } }
    [SerializeField]
    private AudioClip fourth;
    public AudioClip Fourth { get { return fourth; } }
    [SerializeField]
    private AudioClip fifth;
    public AudioClip Fifth { get { return fifth; } }
    [SerializeField]
    private AudioClip sixth;
    public AudioClip Sixth { get { return sixth; } }
    [SerializeField]
    private AudioClip seventh;
    public AudioClip Seventh { get { return seventh; } }
    private AudioClip mySound;
    public AudioClip MySound
    {
        get { return mySound; }
        set { mySound = value; }
    }
    private Color myColor;
    public Color MyColor
    {
        get { return myColor; }
        set { myColor = value; }
    }
    private bool receivePulse;
    public bool ReceivePulse
    {
        get { return receivePulse; }
        set { receivePulse = value; }
    }

    public AudioClip RandomNote()
    {
        int rand = Random.Range(1, 7);
        colourNum = rand;
        if (rand == 1) return Root;
        if (rand == 2) return Second;
        if (rand == 3) return Third;
        if (rand == 4) return Fourth;
        if (rand == 5) return Fifth;
        if (rand == 6) return Sixth;
        return Seventh;
    }

    void Awake ()
    {
        receivePulse = false;
        giveExtraUrge = 0;
        urgeToSing = Random.Range(0, 1000);
        audioSource = GetComponent<AudioSource>();
        blinkController = GetComponent<Blink>();
        MySound = RandomNote();
        _soundController = new SoundController(this, audioSource, urgeToSing, threshold, blinkController);
	}

	void FixedUpdate()
    {
        _soundController.EmitSound(giveExtraUrge);
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "hex")
        {
            float distance = Vector2.Distance(col.gameObject.transform.position, gameObject.transform.position);
            giveExtraUrge += 1.0f / distance;
            receivePulse = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "hex")
        {
            giveExtraUrge = 0;
            receivePulse = false;
        }
    }
}
