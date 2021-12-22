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
        List<Note> c1 = new List<Note>();
        c1.Add(new Note(NoteName.E, NoteTone.TONE4));
        c1.Add(new Note(NoteName.G, NoteTone.TONE4));

        List<Note> c2 = new List<Note>();
        c2.Add(new Note(NoteName.C, NoteTone.TONE4));

        events.AddEvent(new Event(c1, 0f, 1f));
        events.AddEvent(new Event(c2, 1f, 2f));
    }

}
