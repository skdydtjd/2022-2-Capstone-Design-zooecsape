using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShaking : MonoBehaviour
{
    public Camera mainCamera;
    Vector3 cameraPos;

    [SerializeField][Range(0f, 10f)] float shakeRange = 10f;
    [SerializeField][Range(0f, 10f)] float duration = 10f;

    float t;
    float x;
    Vector3 s;
    Vector3 e;
    Vector3 sp;
    Vector3 mp;
    Vector3 ep;

    public void start()
    {
        s = this.transform.eulerAngles;
        e = new Vector3(this.transform.eulerAngles.x - 20f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        sp = this.transform.position;
        mp = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 15f);
        Debug.Log(mp);
        ep = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 30f);
        cameraPos = mainCamera.transform.position;
        InvokeRepeating("StartShake", 0f, 1f);
        Invoke("StopShake", duration);
    }

    void StartShake()
    {
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(e), Time.deltaTime * 0.3f);
        this.transform.position = Vector3.Lerp(this.transform.position, ep, 10 * Time.deltaTime / Vector3.Distance(sp, ep));
    }

    void StopShake()
    {
        CancelInvoke("StartShake");
        mainCamera.transform.position = cameraPos;
    }
}