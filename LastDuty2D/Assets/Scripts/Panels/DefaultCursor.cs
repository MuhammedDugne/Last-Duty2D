using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCursor : MonoBehaviour
{
    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0f;
        light.transform.position = cursorPosition;
    }
}
