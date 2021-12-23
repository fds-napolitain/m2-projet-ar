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
    // CHORDS
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
    private const int TYPES_NUMBER = 11; // a incrémenter si on change TYPES
    public static List<Note> currentChords = new List<Note>();

    // ATTRIBUTES
    public NoteName name;
    public ChordsType chords;

    public Chords(NoteName name, ChordsType chords)
    {
        this.name = name;
        this.chords = chords;
    }

    public override string ToString()
    {
        string result = "";
        switch (name)
        {
            case NoteName.C:
                result += "C";
                break;
            case NoteName.Db:
                result += "Db";
                break;
            case NoteName.D:
                result += "D";
                break;
            case NoteName.Eb:
                result += "Eb";
                break;
            case NoteName.E:
                result += "E";
                break;
            case NoteName.F:
                result += "F";
                break;
            case NoteName.Gb:
                result += "Gb";
                break;
            case NoteName.G:
                result += "G";
                break;
            case NoteName.Ab:
                result += "Ab";
                break;
            case NoteName.A:
                result += "A";
                break;
            case NoteName.Bb:
                result += "Bb";
                break;
            case NoteName.B:
                result += "B";
                break;
        }
        switch (chords)
        {
            case ChordsType.CMAJOR:
                result += " major";
                break;
            case ChordsType.CMAJOR7:
                result += " major 7";
                break;
            case ChordsType.CMAJOR9:
                result += " major 9";
                break;
            case ChordsType.CMAJOR11:
                result += " major 11";
                break;
            case ChordsType.CAUG:
                result += " augmented";
                break;
            case ChordsType.CMINOR:
                result += " minor";
                break;
            case ChordsType.CMINOR7:
                result += " minor 7";
                break;
            case ChordsType.CDIM:
                result += " diminued";
                break;
            case ChordsType.CSUS:
                result += " suspended";
                break;
            case ChordsType.CSUS2:
                result += " suspended + 2";
                break;
            case ChordsType.CSUS4:
                result += " suspended + 4";
                break;
            case ChordsType.NONE:
                break;
        }
        return result.Length > 1 ? result : "";
    }

    /// <summary>
    /// Appelle Note.Transpose sur chaque notes.
    /// </summary>
    /// <param name="notes"></param>
    /// <param name="semitones"></param>
    public static List<Note> Transpose(List<Note> notes, int semitones)
    {
        List<Note> result = new List<Note>();
        for (int i = 0; i < notes.Count; i++)
        {
            result.Add(notes[i].Transpose(semitones));
        }
        return result;
    }

    /// <summary>
    /// Need a sorted List<Note>
    /// Transpose to a C chord.
    /// </summary>
    /// <returns></returns>
    private static int TransposeToBase(List<Note> notes)
    {
        return (int)notes[0].name;
    }

    /// <summary>
    /// Reconnait les accords à partir d'une listes de notes jouées.
    /// </summary>
    /// <param name="notes"></param>
    /// <returns></returns>
    public static Chords Recognize(List<Note> notes, bool sorted = false)
    {
        bool[] t = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
        // tri, fonctionne avec Note.CompareTo()
        if (!sorted)
        {
            notes.Sort();
        }
        // transposer la base note
        int s = TransposeToBase(notes);
        List<Note> transposed = Transpose(notes, -s);
        // creation d'un tableau boolean pour comparer avec le dictionnaire
        for (int i = 0; i < notes.Count; i++)
        {
            t[(int)transposed[i].name] = true;
        }
        // comparer
        for (int i = 0; i < TYPES_NUMBER; i++) // iterer la liste des accords
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
                return new Chords(notes[0].name, (ChordsType)i);
            }
        }
        return new Chords(notes[0].name, ChordsType.NONE); // cas par défaut (NONE)
    }
}
