using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDust : MonoBehaviour
{
    [SerializeField] private bool createDustOnWalk = true;
    private ParticleSystem dustParticleSystem;

    private void Awake()
    {
        dustParticleSystem = GetComponent<ParticleSystem>();
    }
    public void CreateDustParticles()
    {
        if (createDustOnWalk)
        {
            dustParticleSystem.Stop();
            dustParticleSystem.Play();
        }
    }
}
