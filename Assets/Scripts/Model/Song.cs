using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Event d'une chanson (une ou plusieurs notes, avec un début une fin et un volume).
/// </summary>
public class Event
{
    public List<Note> notes; // ensemble de notes joué en même temps
    public float attack; // currentTime pour début note
    public float release; // currentTime laché
    public float velocity; // volume
    private static int ID = 0;
    private int id; // id unique event

    /// <summary>
    /// Crée un event à partir d'une note et d'une durée.
    /// </summary>
    /// <param name="notes"></param>
    /// <param name="duration"></param>
    public Event(List<Note> notes, float duration)
    {
        this.notes = notes;
        this.attack = Game.CurrentTime;
        this.release = Game.CurrentTime + duration;
        this.id = ID++;
    }

    /// <summary>
    /// Crée un event à partir d'une note, d'un temps d'attack et de release.
    /// </summary>
    /// <param name="notes"></param>
    /// <param name="attack"></param>
    /// <param name="release"></param>
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
        return (int)attack+id;
    }

    public float GetCurrentTime()
    {
        return attack;
    }
}

/// <summary>
/// Création de 0 d'une sorted list.
/// </summary>
public class SortedEvents
{
    private List<Event> events;

    /// <summary>
    /// Initialise une sorted list d'events custom.
    /// </summary>
    public SortedEvents()
    {
        events = new List<Event>();
    }

    /// <summary>
    /// Ajoute un event dans la liste de manière triée par ordre de attack+id
    /// </summary>
    /// <param name="item"></param>
    public void AddEvent(Event item)
    {
        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].GetCurrentTime() > item.GetCurrentTime()) // ne peut être égal
            {
                events.Insert(i, item); // insère l'item à sa place
                return;
            }
        }
        events.Add(item); // ajoute l'item si la liste est vide
    }

    /// <summary>
    /// Supprime un élément de liste.
    /// </summary>
    /// <param name="item"></param>
    public void RemoveEvent(Event item)
    {
        events.Remove(item);
    }

    /// <summary>
    /// Recherche par dichotomie par intervalle de temps
    /// </summary>
    /// <param name="currentTime"></param>
    /// <param name="deltaTime"></param>
    /// <returns></returns>
    public List<Event> Events(float currentTime, float deltaTime)
    {
        int index = events.Count / 2;
        int step = events.Count / 4;
        while (events[index].GetCurrentTime() < currentTime + deltaTime || events[index].GetCurrentTime() > currentTime - deltaTime)
        {
            if (index / 2 == index)
            {
                throw new Exception("Cannot find event");
            }
            if (events[index].GetCurrentTime() > currentTime)
            {
                index += step;
            }
            else
            {
                index -= step;
            }
            step /= 2;
        }
        List<Event> result = new List<Event>();
        while (events[index-1].GetCurrentTime() == currentTime)
        {
            index--;
        }
        while (events[index].GetCurrentTime() == currentTime)
        {
            result.Add(events[index]);
            index++;
        }
        return result;
    }

    /// <summary>
    /// Comparaison entre deux events :
    /// - 1 si x > y
    /// - -1 si x < y
    /// - 0 sinon
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public int Compare(Event x, Event y)
    {
        if (x.GetCurrentTime() < y.GetCurrentTime())
        {
            return -1;
        }
        else if (x.GetCurrentTime() > y.GetCurrentTime())
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}

/// <summary>
/// Chanson, avec parseur et gameplay lié.
/// </summary>
public static class Song
{
    public static SortedEvents events;
    public static float score = 0;

    public static void SetMusicToImagine()
    {
        events = new SortedEvents();
        List<Note> c1 = new List<Note>();
        c1.Add(new Note(NoteName.E, NoteType.MAJOR, NoteTone.TONE4));
        c1.Add(new Note(NoteName.G, NoteType.MAJOR, NoteTone.TONE4));

        List<Note> c2 = new List<Note>();
        c2.Add(new Note(NoteName.C, NoteType.MAJOR, NoteTone.TONE4));

        events.AddEvent(new Event(c1, 0f, 1f));
        events.AddEvent(new Event(c2, 1f, 2f));
    }

}
