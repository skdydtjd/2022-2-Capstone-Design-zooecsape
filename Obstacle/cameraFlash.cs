using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraFlash : MonoBehaviour
{
    // Flash Image
    public bool changed;
    public Image mFlashImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(0f, 0f, 0f, 255f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changed)
        {
            mFlashImage.color = flashColour;
        }
        else
        {
            mFlashImage.color = Color.Lerp(mFlashImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        // Change back to false
        changed = false;
    }
}
