/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2020.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Script li?e ? chaque touche
/// </summary>
public class PianoToucheScript : MonoBehaviour
{
    // ================ AUDIO ATTRIBUTES ============

    // const
    private const float RELEASE_TIME = 0.33f;
    private const float VELOCITY_MAX = 0.5f;
    private const float VOLUME_MIN = 0.25f;
    private const float VOLUME_MAX = 1f;
    public const int KEYS_NUMBER = 88;
    
    // release
    private float release_tmp = 0;
    private float release = Mathf.Infinity; // infinite = false, float:x = play at x
    
    // play audio
    private float playNote = -1f; // -1 = false, float:x = play at x
    private AudioSource audioSource;

    // note
    public Note note;
    private bool noteEnabled = true;
    public static int updateScale = 88;
    private Renderer m_renderer;
    private Material materialEnabled;
    private Material materialDisabled;


    // ==================== METHODS ======================

    /// <summary>
    /// Appel? au d?but du script.
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // recupere l'audiosource dans une variable
        m_renderer = GetComponent<Renderer>(); // renderer used for changing material of keys
        materialEnabled = m_renderer.material; // black or white key
        materialDisabled = Resources.Load<Material>("Materials/Piano/Gray_DISABLED"); // gray_disabled key
    }

    /// <summary>
    /// Quand on touche une note avec un doigt.
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
        if (noteEnabled)
        {
            int a = Convert.ToInt32(collider.name);
            if (Game.frame.Hands.Count >= 1 && !Game.frame.Hands[0].IsLeft) // si la main "gauche" est celle de "droite"
            {
                if (a > 4) // inversement
                {
                    a -= 5;
                }
                else
                {
                    a += 5;
                }
            }
            if (Game.frame.Hands[a / 5].Fingers[a % 5].IsExtended) // joue le son
            {
                //Debug.Log("Note d?tect?e: " + Game.currentTime);
                playNote = Game.CurrentTimeQuantized;
                if (playNote == Game.CurrentTime)
                {
                    audioSource.volume = Mathf.Max(VOLUME_MIN, (VOLUME_MAX * Mathf.Min(VELOCITY_MAX, collider.GetComponent<VelocityFinger>().velocity)) / VELOCITY_MAX);
                    PlayNote();
                }
            }
        }
    }

    /// <summary>
    /// Quand on arr?te de toucher une note avec le doigt.
    /// </summary>
    void OnTriggerExit()
    {
        //Debug.Log("Note release: " + Game.currentTime);
        float release = Game.CurrentTimeQuantized;
        //transform.Rotate(new Vector3(1f, 0f, 0f) * -2);
    }

    /// <summary>
    /// Chaque frame, joue les sons ou non.
    /// </summary>
    void Update()
    {
        // quantification de notes
        if (Game.CurrentTime >= playNote)
        {
            //Debug.Log(playNote + " " + Game.currentTime);
            PlayNote();
        }
        // release de la touche jusqu'a fin de note (release_time)
        if (Game.CurrentTime >= release) 
        {
            release_tmp += Time.deltaTime;
            audioSource.volume -= Time.deltaTime / RELEASE_TIME;
            if (release_tmp >= RELEASE_TIME)
            {
                //Debug.Log("Note stop: " + Game.currentTime);
                release_tmp = 0;
                release = Mathf.Infinity;
                audioSource.Stop();
                audioSource.volume = 1f;
            }
        }
        // mise ? jour de la gamme
        if (updateScale != 0)
        {
            updateScale--;
            UpdateNoteScale();
        }
        // joue une musique
        List<Event> events = Song.events.Events(Game.CurrentTime, Time.deltaTime);
        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].notes.Contains(note))
            {
                playNote = events[i].attack;
            }
        }
    }

    /// <summary>
    /// Joue la note en fonction de la quantification.
    /// </summary>
    void PlayNote()
    {
        if (playNote != -1f) // joue la note, rotate la touche
        {
            //Debug.Log("Note d?but: " + Game.currentTime);
            audioSource.Play();
            //transform.Rotate(new Vector3(1f, 0f, 0f) * 2);
            playNote = -1f;
        }
    }

    /// <summary>
    /// Enable or disable note depending on scale.
    /// </summary>
    public void UpdateNoteScale()
    {
        noteEnabled = (int)note.type == (int)Game.scale.types[(int)note.name] || Game.scale.types[(int)note.name] == NoteType.ANY; // check if note type (major, minor...) == type of equivalent note in scale
        if (noteEnabled)
        {
            m_renderer.material = materialEnabled;
        }
        else
        {
            m_renderer.material = materialDisabled;
        }
    }
}
