/// <summary>
/// Note.
/// </summary>
[System.Serializable]
public class Note
{
	public NoteName name; // ex: C
	public NoteTone tone; // ex: 4

	public Note(NoteName name, NoteTone tone)
    {
		this.name = name;
		this.tone = tone;
    }

    public override bool Equals(object obj)
    {
        return obj is Note note &&
               name == note.name &&
               tone == note.tone;
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
/// Tonalit? de la note.
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
