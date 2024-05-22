﻿using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    [SerializeField] private LayerMask playerCollisionLayer;
    [SerializeField] private LayerMask shieldCollisionLayer;

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 2.5f * SpawnManager.instance.speedScaling; // 속도 스케일링
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsLayerMatched(shieldCollisionLayer, other.gameObject.layer)) { return; }

        if (IsLayerMatched(playerCollisionLayer.value, other.gameObject.layer))
        {
            SoundManager.instance.PlayItemSound();
            PlayerShield playerCoroutine = other.gameObject.GetComponent<PlayerShield>();
            playerCoroutine.ActivateShield();
        }
        gameObject.SetActive(false);
    }

    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}