using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationOn : MonoBehaviour
{
    [SerializeField] private GameObject systemManager;
    void Awake()
    {
        if (SystemManager.instance == null)
        {
            Instantiate(systemManager);
        }
        Destroy(gameObject);
    }
}
