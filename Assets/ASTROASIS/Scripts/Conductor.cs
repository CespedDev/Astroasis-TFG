// Copyright (c) Carlos Cabrera 06/09/2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    /// <summary>
    /// Conductor instance.
    /// </summary>
    [field: SerializeField] public static Conductor instance { get; private set; }

    /// <summary>
    /// Song beats per minute. This is determined by the song you're trying to sync up to.
    /// </summary>
    [field: SerializeField] public float songBpm { get; private set; }

    /// <summary>
    /// The offset to the first beat of the song in seconds.
    /// </summary>
    [field: SerializeField] public float firstBeatOffset { get; private set; }

    /// <summary>
    /// The number of seconds for each song beat. 
    /// </summary>
    public float secPerBeat { get; private set; } //CCabrera (11-09-2023): Private?

    /// <summary>
    /// Current song position, in seconds.
    /// </summary>
    public float songPosition { get; private set; }

    /// <summary>
    /// Current song position, in beats.
    /// </summary>
    public float songPositionInBeats { get; private set; }

    /// <summary>
    /// How many seconds have passed since the song started.
    /// </summary>
    public float dspSongTime { get; private set; } //CCabrera (11-09-2023): Private?

    /// <summary>
    /// An AudioSource attached to this GameObject that will play the music.
    /// </summary>
    [field: SerializeField] public AudioSource musicSource { get; private set; } 

    /// <summary>
    /// The number of beats in each loop.
    /// </summary>
    [field: SerializeField] public float beatsPerLoop { get; private set; }

    /// <summary>
    /// The total number of loops completed since the looping clip first started.
    /// </summary>
    [field: SerializeField] public int completedLoops { get; private set; } = 0;

    /// <summary>
    /// The current position of the song within the loop in beats.
    /// </summary>
    [field: SerializeField] public float loopPositionInBeats { get; private set; }

    /// <summary>
    /// The current relative position of beat between 0 and 1.
    /// </summary>
    [field: SerializeField] public float loopPositionInBeatsNormalize { get; private set; }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
    }

    void Update()
    {
        //Determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //Determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        //Calculate the loop position
        if (songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
            completedLoops++;
        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;

        //Calculate the normalize loop position
        loopPositionInBeatsNormalize = loopPositionInBeats - Mathf.Floor(loopPositionInBeats);
    }
}
