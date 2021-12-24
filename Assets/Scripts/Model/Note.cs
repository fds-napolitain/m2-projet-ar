using System;

/// <summary>
/// Note.
/// </summary>
[System.Serializable]
public class Note : IComparable<Note>
{
	public NoteName name; // ex: C
	public NoteTone tone; // ex: 4

	public Note(NoteName name, NoteTone tone)
    {
		this.name = name;
		this.tone = tone;
    }

    /// <summary>
    /// Une note x est inférieur à une note y si sa hauteur est inférieur à la note y.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(Note other)
    {
        if (tone < other.tone || tone == other.tone && name < other.name)
        {
            return -1;
        }
        else if (tone == other.tone && name == other.name)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    public override bool Equals(object obj)
    {
        return obj is Note note &&
               name == note.name &&
               tone == note.tone;
    }

    public override int GetHashCode()
    {
        return (int)name * 100 + (int)tone;
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
        switch (tone)
        {
            case NoteTone.TONE0:
                result += "0";
                break;
            case NoteTone.TONE1:
                result += "1";
                break;
            case NoteTone.TONE2:
                result += "2";
                break;
            case NoteTone.TONE3:
                result += "3";
                break;
            case NoteTone.TONE4:
                result += "4";
                break;
            case NoteTone.TONE5:
                result += "5";
                break;
            case NoteTone.TONE6:
                result += "6";
                break;
            case NoteTone.TONE7:
                result += "7";
                break;
        }
        return result;
    }

    /// <summary>
    /// Transpose par demi tons
    /// </summary>
    /// <param name="semitones"></param>
    public Note Transpose(int semitones)
    {
        int st = Math.Abs(semitones) % 12;
        int o = (int)Math.Truncate(Math.Abs(semitones) / 12.0);
        return semitones > 0 ? new Note(name + st, tone + o) : new Note(name - st, tone - o);
    }
}

/// <summary>
/// Liste des demi tons.
/// </summary>
[System.Serializable]
public enum NoteName
{
	C,
	Db,
	D,
	Eb,
	E,
	F,
	Gb,
	G,
	Ab,
	A,
	Bb,
	B,
}

/// <summary>
/// Tonalité de la note.
/// </summary>
[System.Serializable]
public enum NoteTone
{
	TONE0,
	TONE1,
	TONE2,
	TONE3,
	TONE4,
	TONE5,
	TONE6,
	TONE7,
}
