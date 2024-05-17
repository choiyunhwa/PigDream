using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoller : MonoBehaviour
{
    private RawImage img;
    [SerializeField] private float x, y = 0.0f;
    private void Awake()
    {
        img = GetComponent<RawImage>();
    }
    
    private void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * Time.deltaTime, img.uvRect.size);
    }
}
