using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class VelocityFing : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private Queue<float> oldPos = new Queue<float>();
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
        var now = m_rigidbody.position[1];
        oldPos.Enqueue(now);
        oldTimes.Enqueue(Time.deltaTime);
        interval += Time.deltaTime;
        if (interval >= 0.05f)
        {
            var old = oldPos.Dequeue();
            velocity = Mathf.Abs((now - old) / interval);
            interval -= oldTimes.Dequeue();
        }
    }
}
