/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2020.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using UnityEngine;
using System;

/// <summary>
/// Script liée à chaque touche
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
    private Vector3 basePos;
    private Quaternion baseRot;
    private Vector3 rotatedPos;
    private Quaternion rotatedRot;
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
    /// Appelé au début du script.
    /// </summary>
    void Start() 
    {
        audioSource = GetComponent<AudioSource>(); // recupere l'audiosource dans une variable
        m_renderer = GetComponent<Renderer>(); // renderer used for changing material of keys
        materialEnabled = m_renderer.material; // black or white key
        materialDisabled = Resources.Load<Material>("Materials/Piano/Gray_DISABLED"); // gray_disabled key
        basePos = this.transform.position;
        baseRot = this.transform.rotation;
        transform.Rotate(new Vector3(1f, 0f, 0f) * -2);
        rotatedPos = this.transform.position;
        rotatedRot = this.transform.rotation;
        transform.SetPositionAndRotation(basePos, baseRot);
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
        // mise à jour de la gamme
        if (updateScale != 0)
        {
            UpdateNoteScale();
        }
        // joue une musique
        for (int i = 0; i < Game.song.currentEvents.Count; i++)
        {
            if (Game.song.currentEvents[i].notes.Contains(note))
            {
                //Debug.Log("Play: " + note.ToString());
                playNote = Game.song.currentEvents[i].attack;
            }
        }
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
                //Debug.Log("Note " + note.ToString() + " détectée: " + Game.CurrentTime);
                playNote = Game.CurrentTimeQuantized;
                if (playNote == Game.CurrentTime)
                {
                    audioSource.volume = Mathf.Max(VOLUME_MIN, VOLUME_MAX * Mathf.Min(VELOCITY_MAX, collider.GetComponent<VelocityFinger>().velocity) / VELOCITY_MAX);
                    PlayNote();
                }
                Chords.currentChords.Add(note);
                ShowClickedNote(true, KeyPressIndicator.COLOR);
            }
        }
    }

    /// <summary>
    /// Quand on arrête de toucher une note avec le doigt.
    /// </summary>
    void OnTriggerExit()
    {
        //Debug.Log("Note " + note.ToString() + " release: " + Game.CurrentTime);
        float release = Game.CurrentTimeQuantized;
        ShowClickedNote(false, KeyPressIndicator.COLOR);
        Chords.currentChords.Remove(note);
        m_renderer.material = materialEnabled;
    }

    /// <summary>
    /// Joue la note en fonction de la quantification.
    /// </summary>
    void PlayNote()
    {
        if (playNote != -1f) // joue la note, rotate la touche
        {
            //Debug.Log("Note début: " + Game.currentTime);
            audioSource.Play();
            playNote = -1f;
        }
    }

    /// <summary>
    /// Enable or disable note depending on scale.
    /// </summary>
    public void UpdateNoteScale()
    {
        updateScale--;
        if (Game.scale.types[(int)note.name]) // check if note is in scale
        {
            m_renderer.material = materialEnabled;
        }
        else
        {
            m_renderer.material = materialDisabled;
        }
    }

    /// <summary>
    /// Enumerations des types de feedbacks quand on appuie sur une touche.
    /// </summary>
    private enum KeyPressIndicator
    {
        NONE,
        ROTATION,
        COLOR,
    }

    /// <summary>
    /// Permet d'avoir un retour sur les clicks de touches (rotation ou couleur ou rien)
    /// </summary>
    /// <param name="value"></param>
    /// <param name="keyPressIndicator"></param>
    private void ShowClickedNote(bool value, KeyPressIndicator keyPressIndicator = KeyPressIndicator.COLOR)
    {
        switch (keyPressIndicator)
        {
            case KeyPressIndicator.NONE:
                break;
            case KeyPressIndicator.ROTATION:
                if (value)
                {
                    transform.SetPositionAndRotation(basePos, baseRot);
                }
                else
                {
                    transform.SetPositionAndRotation(rotatedPos, rotatedRot);
                }
                break;
            case KeyPressIndicator.COLOR:
                m_renderer.material = value ? materialDisabled : materialEnabled;
                break;
        }
    }
}
