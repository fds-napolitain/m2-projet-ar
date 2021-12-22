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

    public bool Equals(Event other)
    {
        return other != null &&
               id == other.id;
    }

    public override int GetHashCode()
    {
        return (int)attack + id;
    }

    public float GetCurrentTime()
    {
        return attack;
    }
}

/// <summary>
/// Cr�ation de 0 d'une sorted list.
/// </summary>
public class SortedEvents
{
    private List<Event> events;

    /// <summary>
    /// Initialise une sorted list d'events custom.
    /// </summary>
    public SortedEvents()
    {
        events = new List<Event>();
    }

    /// <summary>
    /// Ajoute un event dans la liste de mani�re tri�e par ordre de attack+id
    /// </summary>
    /// <param name="item"></param>
    public void AddEvent(Event item)
    {
        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].GetCurrentTime() > item.GetCurrentTime()) // ne peut �tre �gal
            {
                events.Insert(i, item); // ins�re l'item � sa place
                return;
            }
        }
        events.Add(item); // ajoute l'item si la liste est vide
    }

    /// <summary>
    /// Supprime un �l�ment de liste.
    /// </summary>
    /// <param name="item"></param>
    public void RemoveEvent(Event item)
    {
        events.Remove(item);
    }

    /// <summary>
    /// Recherche par dichotomie par intervalle de temps
    /// </summary>
    /// <param name="currentTime"></param>
    /// <param name="deltaTime"></param>
    /// <returns></returns>
    public List<Event> GetEvents(float currentTime, float deltaTime)
    {
        int index = events.Count / 2;
        int step = events.Count / 4;
        while (events[index].GetCurrentTime() < currentTime + deltaTime || events[index].GetCurrentTime() > currentTime - deltaTime)
        {
            if (step == 0)
            {
                return new List<Event>();
            }
            if (events[index].GetCurrentTime() > currentTime)
            {
                index += step;
            }
            else
            {
                index -= step;
            }
            step /= 2;
        }
        List<Event> result = new List<Event>();
        while (events[index - 1].GetCurrentTime() == currentTime)
        {
            index--;
        }
        while (events[index].GetCurrentTime() == currentTime)
        {
            result.Add(events[index]);
            index++;
        }
        return result;
    }

    /// <summary>
    /// Comparaison entre deux events :
    /// - 1 si x > y
    /// - -1 si x < y
    /// - 0 sinon
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public int Compare(Event x, Event y)
    {
        if (x.GetCurrentTime() < y.GetCurrentTime())
        {
            return -1;
        }
        else if (x.GetCurrentTime() > y.GetCurrentTime())
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
