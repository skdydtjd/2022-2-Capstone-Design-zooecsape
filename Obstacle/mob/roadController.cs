using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadController : MonoBehaviour
{
    [SerializeField]
    public enum type
    {
        sides,
        updown,
        circle
    }
    type m_type;

    GameObject pl;
    public GameObject Gameobject;
    [Range(0, 1)]
    public float Move;

    public Vector2 P1;
    public Vector2 P2;
    public Vector2 P3;
    public Vector2 P4;
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gameobject.transform.position = Bezier(P1, P2, Move);
        Move = Mathf.Lerp(0f, 1f, Mathf.PingPong(Time.time * speed, 1f));
    }

    public Vector2 Bezier(
    Vector2 p_1,
    Vector2 p_2,
    float Value)
    {
        Vector2 A = Vector2.Lerp(p_1, p_2, Value);
        return A;
    }
}
