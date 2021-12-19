using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Event d'une chanson (une ou plusieurs notes, avec un début une fin et un volume).
/// </summary>
public class Event : IEquatable<Event>
{
    public List<Note> notes; // ensemble de notes
    public float attack; // currentTime pour début note
    public float release; // currentTime laché
    public float velocity; // volume
    private static int ID = 0;
    private int id; // id unique event

    public Event(List<Note> notes, float attack, float release)
    {
        this.notes = notes;
        this.attack = attack;
        this.release = release;
        this.id = ID++;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Event);
    }

    public bool Equals(Event other)
    {
        return other != null &&
               id == other.id;
    }

    public override int GetHashCode()
    {
        return id+(int)attack;
    }
}

/// <summary>
/// Chanson, avec parseur et gameplay lié.
/// </summary>
public static class Song
{
    public static HashSet<Event> events;
    public static float score = 0;

    public static void SetMusicToImagine()
    {
        List<Note> c1 = new List<Note>();
        c1.Add(new Note(NoteName.E, NoteType.MAJOR, NoteTone.TONE4));
        c1.Add(new Note(NoteName.G, NoteType.MAJOR, NoteTone.TONE4));

        List<Note> c2 = new List<Note>();
        c2.Add(new Note(NoteName.C, NoteType.MAJOR, NoteTone.TONE4));

        events.Add(new Event(c1, 0f, 1f));
        events.Add(new Event(c2, 1f, 2f));
    }

}
