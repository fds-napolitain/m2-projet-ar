using System.Collections.Generic;

/// <summary>
/// Chanson, avec parseur et gameplay lié.
/// </summary>
public class Song
{
    public SortedEvents events;
    public float score = 0;
    public List<Event> currentEvents; 

    public Song()
    {
        events = new SortedEvents();
        currentEvents = new List<Event>();

        List<Note> c1 = new List<Note>();
        c1.Add(new Note(NoteName.E, NoteTone.TONE4));
        c1.Add(new Note(NoteName.G, NoteTone.TONE4));

        List<Note> c2 = new List<Note>();
        c2.Add(new Note(NoteName.C, NoteTone.TONE4));

        events.AddEvent(new Event(c1, 1f, 1f));
        events.AddEvent(new Event(c2, 2f, 2f));
    }

    /// <summary>
    /// Met a jour les événements de chanson courant.
    /// </summary>
    public void UpdateCurrentEvents()
    {
        List<Event> tmp = events.GetEvents();
        currentEvents = new List<Event>(tmp.Count);
        for (int i = 0; i < tmp.Count; i++)
        {
            currentEvents[i] = tmp[i];
        }
    }

}
