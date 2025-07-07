using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    float speed;
    GameObject enemy;

    public enum type
    {
        Crow,
        normal
    }
    type m_type;

    public type Type
    {
        get
        { return m_type; }
        set
        { m_type = value; }
    }


    public MonsterBase(float spd, type t)
    {
        speed = spd;
        m_type = t;
    }
}
