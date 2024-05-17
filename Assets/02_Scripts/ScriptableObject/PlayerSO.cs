using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Player", order = 0)]
public class PlayerSO : ScriptableObject
{
    public Sprite playerSprite;
    public GameObject playerObj;
    public float speed;
}
