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
