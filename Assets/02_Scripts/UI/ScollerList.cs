using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScollerList : MonoBehaviour
{

    [Header("Character Infor")]
    public Image choiceImg;
    public TMP_Text text;

    [Header("ListView")]
    public GameObject content;
    public GameObject scrollbar;
    private float scrollPos = 0;
    private float[] pos;

    public List<PlayerSO> playerInfor;

    private void Awake()
    {
        foreach (var player in playerInfor)
        {
            GameObject obj = new GameObject("choice");
            RectTransform rect = obj.AddComponent<RectTransform>();
            obj.transform.SetParent(content.transform, false);
            rect.sizeDelta = new Vector2(300, 300);
            Image image = obj.AddComponent<Image>();
            image.sprite = player.playerSprite;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        pos = new float[content.transform.childCount];
        float distance = 1f / (pos.Length - 1);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            float scale = Mathf.Lerp(0.8f, 1f, Mathf.Clamp01(1f - Mathf.Abs(scrollPos - pos[i]) / (distance / 2)));
            content.transform.GetChild(i).localScale = new Vector2(scale, scale);

            choiceImg.sprite = playerInfor[i].playerSprite;

            
        }        
    }
    public void CallPlayerEvent(PlayerSO player)
    {
        //GameManager.Instance.playerEvent?.Invoke(player);
    }

}

