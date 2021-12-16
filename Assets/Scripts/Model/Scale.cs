using System.Collections.Generic;

/// <summary>
/// Gamme : note de base + gamme associée
/// </summary>
public class Scale
{
	private const int NOTE_NUMBERS = 7;
	public NoteName note;
	public ScaleType scale;
	public NoteType[] types = new NoteType[NOTE_NUMBERS];

	/// <summary>
	/// Default constructeur
	/// </summary>
	public Scale()
	{
		SetScale(NoteName.C, ScaleType.NONE);
    }

	/// <summary>
    /// Parametized constructor : base note and its scale.
    /// </summary>
    /// <param name="note"></param>
    /// <param name="scale"></param>
	public Scale(NoteName note, ScaleType scale)
	{
		SetScale(note, scale);
	}

	/// <summary>
    /// Called everytime to change a scale.
    /// </summary>
    /// <param name="scale"></param>
	public void SetScale(NoteName name, ScaleType scale)
    {
		this.note = name;
		this.scale = scale;
		switch (scale)
		{
			case ScaleType.NONE: // toutes les notes
				types[(0 + (int)note) % NOTE_NUMBERS] = NoteType.ANY;
				types[(1 + (int)note) % NOTE_NUMBERS] = NoteType.ANY; // D + D = E (NOTE2 becomes NOTE3 in C,D,E,F,G,A,B)
				types[(2 + (int)note) % NOTE_NUMBERS] = NoteType.ANY;
				types[(3 + (int)note) % NOTE_NUMBERS] = NoteType.ANY;
				types[(4 + (int)note) % NOTE_NUMBERS] = NoteType.ANY;
				types[(5 + (int)note) % NOTE_NUMBERS] = NoteType.ANY;
				types[(6 + (int)note) % NOTE_NUMBERS] = NoteType.ANY;
				break;
			case ScaleType.MAJOR: // gamme majeure
				types[(0 + (int)note) % NOTE_NUMBERS] = NoteType.MAJOR;
				types[(1 + (int)note) % NOTE_NUMBERS] = NoteType.MAJOR;
				types[(2 + (int)note) % NOTE_NUMBERS] = NoteType.MAJOR;
				types[(3 + (int)note) % NOTE_NUMBERS] = NoteType.MAJOR;
				types[(4 + (int)note) % NOTE_NUMBERS] = NoteType.MAJOR;
				types[(5 + (int)note) % NOTE_NUMBERS] = NoteType.MAJOR;
				types[(6 + (int)note) % NOTE_NUMBERS] = NoteType.MAJOR;
				break;
			case ScaleType.MINOR: // gamme mineure
				types[(0 + (int)note) % NOTE_NUMBERS] = NoteType.MAJOR;
				types[(1 + (int)note) % NOTE_NUMBERS] = NoteType.MAJOR;
				types[(2 + (int)note) % NOTE_NUMBERS] = NoteType.MINOR;
				types[(3 + (int)note) % NOTE_NUMBERS] = NoteType.MAJOR;
				types[(4 + (int)note) % NOTE_NUMBERS] = NoteType.MAJOR;
				types[(5 + (int)note) % NOTE_NUMBERS] = NoteType.MINOR;
				types[(6 + (int)note) % NOTE_NUMBERS] = NoteType.MINOR;
				break;
		}
	}
}

/// <summary>
/// Gammes théorique.
/// </summary>
public enum ScaleType
{
	NONE,
	MAJOR,
	MINOR,
}
