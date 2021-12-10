using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Met à jour la vélocité des doigts en fonction de leurs positions et d'un interval clé en secondes.
/// </summary>
public class VelocityFinger : MonoBehaviour
{
    private const float INTERVAL_VELOCITY = 0.05f;
    private Rigidbody m_rigidbody;
    private Queue<float> oldPositions = new Queue<float>();
    private Queue<float> oldTimes = new Queue<float>();
    private float interval = 0f;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float now = m_rigidbody.position[1];
        oldPositions.Enqueue(now);
        oldTimes.Enqueue(Time.deltaTime);
        interval += Time.deltaTime;
        if (interval >= INTERVAL_VELOCITY)
        {
            float old = oldPositions.Dequeue();
            velocity = Mathf.Abs((now - old) / interval);
            interval -= oldTimes.Dequeue();
        }
    }
}
