using System.Collections.Generic;

/// <summary>
/// Event d'une chanson (une ou plusieurs notes, avec un d�but une fin et un volume).
/// </summary>
public class Event
{
    public List<Note> notes; // ensemble de notes jou� en m�me temps
    public float attack; // currentTime pour d�but note
    public float release; // currentTime lach�
    public float velocity; // volume
    private static int ID = 0;
    private int id; // id unique event

    /// <summary>
    /// Cr�e un event � partir d'une note et d'une dur�e.
    /// </summary>
    /// <param name="notes"></param>
    /// <param name="duration"></param>
    public Event(List<Note> notes, float duration)
    {
        this.notes = notes;
        this.attack = Game.CurrentTime;
        this.release = Game.CurrentTime + duration;
        this.id = ID++;
    }

    /// <summary>
    /// Cr�e un event � partir d'une note, d'un temps d'attack et de release.
    /// </summary>
    /// <param name="notes"></param>
    /// <param name="attack"></param>
    /// <param name="release"></param>
    public Event(List<Note> notes, float attack, float release)
    {
        this.notes = notes;
        this.attack = attack;
        this.release = release;
        this.id = ID++;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Event);
    }

    /// <summary>
    /// Deux Events identiques si id1 == id2
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Event other)
    {
        return other != null &&
               id == other.id;
    }

    /// <summary>
    /// Evenement unique : attack + id
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return (int)attack + id;
    }

    /// <summary>
    /// Trier par temps d'attack
    /// </summary>
    /// <returns></returns>
    public float GetCurrentTime()
    {
        return attack;
    }
}
