using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    int score = 1;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        float x = Random.Range(-2.5f, 2.5f);
        float y = Random.Range(4.5f, 3.8f);

        transform.position = new Vector3(x, y, 0);

        int type = Random.Range(1, 8);

        if(type == 1)
        {

        }
        else if(type == 2)
        {

        }
        else if(type == 3)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * 0.05f;
        if(transform.position.y < -3.6f)
        {
            GameManager.Instance.GameOver();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
