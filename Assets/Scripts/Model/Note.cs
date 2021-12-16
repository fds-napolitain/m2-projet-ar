/// <summary>
/// Note.
/// </summary>
[System.Serializable]
public class Note
{
	public NoteName name; // ex: C
	public NoteType type; // ex: MAJOR
	public NoteTone tone; // ex: 4
}

/// <summary>
/// Liste des notes.
/// </summary>
[System.Serializable]
public enum NoteName
{
	C,
	D,
	E,
	F,
	G,
	A,
	B,
}

/// <summary>
/// Note majeures (blanche) ou mineures (noires)
/// </summary>
[System.Serializable]
public enum NoteType
{
	MAJOR,
	MINOR,
	ANY,
	NONE,
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
