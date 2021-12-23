using System.Collections.Generic;

/// <summary>
/// Enumerations et règles accords
/// https://www.scales-chords.com/chord-namer/piano?notes=C;D;G&key=&bass=C
/// </summary>
public enum ChordsType
{
    CMAJOR, // major third
    CMAJOR7, // 7th
    CMAJOR9, // 2th
    CMAJOR11, // 4th
    CAUG, // 5th + 1
    CMINOR, // minor third
    CMINOR7, // minor third
    CDIM, // 5th - 1
    CSUS, // no third
    CSUS2, // 2th instead of 3rd
    CSUS4, // 4th instead of 3rd
    NONE,
}

public class Chords
{
    // CONST
    private static bool[][] TYPES = new bool[][] 
    {
        // ==========   C     Db      D     Eb     E      F     Gb     G     Ab     A      Bb     B  =========
        new bool[] { true, false, false, false, true, false, false, true, false, false, false, false }, // C major
        new bool[] { true, false, false, false, true, false, false, true, false, false, false, true }, // C major 7
        new bool[] { true, false, true, false, true, false, false, true, false, false, false, true }, // C major 9
        new bool[] { true, false, false, false, true, true, false, true, false, false, false, true }, // C major 11
        new bool[] { true, false, false, false, true, false, false, false, true, false, false, false }, // C aug
        new bool[] { true, false, false, true, false, false, false, true, false, false, false, false }, // C minor
        new bool[] { true, false, false, true, false, false, false, true, false, false, true, false }, // C minor 7
        new bool[] { true, false, false, true, false, false, true, false, false, false, false, false }, // C dim
        new bool[] { true, false, false, false, false, false, false, true, false, false, false, false, false }, // Csus
        new bool[] { true, false, true, false, false, false, false, true, false, false, false, false, false }, // Csus2
        new bool[] { true, false, false, false, false, true, false, true, false, false, false, false, false }, // Csus4
    };

    // VAR
    public List<Note> notes = new List<Note>();

    // ==================== METHODS =======================
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
    public ChordsType Recognize(List<Note> notes, bool sorted = false)
    {
        bool[] t = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
        // tri, fonctionne avec Note.CompareTo()
        if (!sorted)
        {
            notes.Sort(); 
        }
        // creation d'un tableau boolean pour comparer avec le dictionnaire
        for (int i = 0; i < notes.Count; i++)
        {
            t[(int)notes[i].name] = true;
        }
        // transposer la base note
        // comparer
        for (int i = 0; i < TYPES.Length-1; i++) // iterer la liste des accords -1 (NONE)
        {
            bool flag = true;
            for (int j = 0; j < 12; j++)
            {
                if (t[j] != TYPES[i][j]) // si l'accord n'est pas bon flag = false
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true) // si l'accord était le bon retourner l'énum correspondante
            {
                return (ChordsType)i;
            }
        }
        return ChordsType.NONE; // cas par défaut (NONE)
    }

}
