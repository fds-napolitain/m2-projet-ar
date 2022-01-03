using System.Collections.Generic;

/// <summary>
/// Chanson, avec parseur et gameplay lié.
/// </summary>
public class Song
{
    public SortedEvents events;
    public float score = 0;
    public List<Event> currentEvents;
    public Note tonality;

    public Song()
    {
        events = new SortedEvents();
        currentEvents = new List<Event>();

        // TODO: arpege C et Calt (a transformer en Chord + arppegiator)
        // imagine : https://s3.amazonaws.com/halleonard-pagepreviews/HL_DDS_0000000000390424.png

        /*
        List<Note> C = new List<Note>();
        C.Add(new Note(NoteName.C, NoteTone.TONE3));
        C.Add(new Note(NoteName.E, NoteTone.TONE4));
        C.Add(new Note(NoteName.G, NoteTone.TONE4));
        List<Note> Calt = new List<Note>();
        Calt.Add(new Note(NoteName.C, NoteTone.TONE4));

        List<Note> Cmaj7 = new List<Note>();
        Cmaj7.Add(new Note(NoteName.C, NoteTone.TONE4));
        Cmaj7.Add(new Note(NoteName.E, NoteTone.TONE4));
        Cmaj7.Add(new Note(NoteName.G, NoteTone.TONE4));
        Cmaj7.Add(new Note(NoteName.B, NoteTone.TONE4));

        List<Note> F = new List<Note>();
        F.Add(new Note(NoteName.C, NoteTone.TONE4));
        F.Add(new Note(NoteName.F, NoteTone.TONE4));
        F.Add(new Note(NoteName.A, NoteTone.TONE4));

        List<Note> Dm = new List<Note>();
        Dm.Add(new Note(NoteName.D, NoteTone.TONE4));
        Dm.Add(new Note(NoteName.F, NoteTone.TONE4));
        Dm.Add(new Note(NoteName.A, NoteTone.TONE4));

        List<Note> G = new List<Note>();
        G.Add(new Note(NoteName.D, NoteTone.TONE4));
        G.Add(new Note(NoteName.G, NoteTone.TONE4));
        G.Add(new Note(NoteName.B, NoteTone.TONE4));

        List<Note> G6sus = new List<Note>();
        G6sus.Add(new Note(NoteName.C, NoteTone.TONE4));
        G6sus.Add(new Note(NoteName.D, NoteTone.TONE4));
        G6sus.Add(new Note(NoteName.E, NoteTone.TONE4));
        G6sus.Add(new Note(NoteName.G, NoteTone.TONE4));

        List<Note> G7 = new List<Note>();
        G7.Add(new Note(NoteName.D, NoteTone.TONE4));
        G7.Add(new Note(NoteName.F, NoteTone.TONE4));
        G7.Add(new Note(NoteName.G, NoteTone.TONE4));
        G7.Add(new Note(NoteName.B, NoteTone.TONE4));

        List<Note> E = new List<Note>();
        E.Add(new Note(NoteName.E, NoteTone.TONE4));
        E.Add(new Note(NoteName.Ab, NoteTone.TONE4));
        E.Add(new Note(NoteName.B, NoteTone.TONE4));

        List<Note> E7 = new List<Note>();
        E7.Add(new Note(NoteName.D, NoteTone.TONE4));
        E7.Add(new Note(NoteName.E, NoteTone.TONE4));
        E7.Add(new Note(NoteName.Ab, NoteTone.TONE4));
        E7.Add(new Note(NoteName.B, NoteTone.TONE4));

        events.AddEvent(new Event(C, Quantization.WHOLE, Quantization.WHOLE+Quantization.EIGHT));
        events.AddEvent(new Event(Calt, Quantization.EIGHT));
        events.AddEvent(new Event(C, Quantization.EIGHT));
        events.AddEvent(new Event(Calt, Quantization.EIGHT));
        events.AddEvent(new Event(C, Quantization.EIGHT));
        events.AddEvent(new Event(Calt, Quantization.EIGHT));
        events.AddEvent(new Event(Cmaj7, Quantization.EIGHT));
        events.AddEvent(new Event(Calt, Quantization.EIGHT));*/
        
    }
}
