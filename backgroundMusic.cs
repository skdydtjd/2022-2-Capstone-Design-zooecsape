using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{
    public AudioSource stage;
    public AudioSource boss;
    public AudioSource personal;

    static backgroundMusic _instance;

    public static backgroundMusic Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stage.Play();
        personal.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
