using System.Collections.Generic;

public class Chords
{
    public static Chords C = 
    public List<Note> notes = new List<Note>();

    public Chords()
    {
        
    }

    /// <summary>
    /// Appelle Note.Transpose sur chaque notes.
    /// </summary>
    /// <param name="semitones"></param>
    public Chords Transpose(int semitones)
    {
        Chords result = new Chords();
        for (int i = 0; i < notes.Count; i++)
        {
            result.notes.Add(notes[i].Transpose(semitones));
        }
        return result;
    }

    /// <summary>
    /// Transpose to a C chord.
    /// </summary>
    /// <returns></returns>
    private Chords TransposeToBase()
    {
        return new Chords();
    }

    public List<NoteName> GetNotes()
    {
        List<NoteName> result = new List<NoteName>();
        for (int i = 0; i < Scale.SEMITONES_NUMBER; i++)
        {

        }
        return new List<NoteName>();
    }

    /// <summary>
    /// Reconnait les accords à partir d'une listes de notes jouées.
    /// </summary>
    /// <param name="notes"></param>
    /// <returns></returns>
    public string Recognize(List<Note> notes, bool sorted = false)
    {
        List<ChordsType> types;
        // tri, fonctionne avec Note.CompareTo()
        if (!sorted)
        {
            notes.Sort(); 
        }
        return "TODO";
    }

}

/// <summary>
/// Enumerations et règles accords
/// https://www.scales-chords.com/chord-namer/piano?notes=C;D;G&key=&bass=C
/// </summary>
public enum ChordsType
{
    CMAJOR, // major third
    CMINOR, // minor third
    C7, // 7th
    C9, // 2th
    C11, // 4th
    C13, // 6th
    CSUS, // no third
    CSUS2, // 2th instead of 3rd
    CSUS4, // 4th instead of 3rd
}