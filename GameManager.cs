using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Candy;
    public GameObject Popcorn;
    public GameObject Hamburger;
    public GameObject Pizza;
    public GameObject Dount;
    public GameObject Honey;
    public GameObject Cupcake;

    int level = 0;
    int score = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeFood()
    {
        Instantiate(Candy);
        Instantiate(Popcorn);
        Instantiate(Hamburger);
        Instantiate(Pizza);
        Instantiate(Dount);
        Instantiate(Honey);
        Instantiate(Cupcake);

        if(level == 1)
        {
            Instantiate(Popcorn);
        }
        else if(level == 2)
        {
            Instantiate(Hamburger);
        }
        else if(level == 3)
        {
            Instantiate(Pizza);
        }
        else if (level == 4)
        {
            Instantiate(Dount);
        }
        else if(level == 5)
        {
            Instantiate(Honey);
        }
        else if(level == 6)
        {
            Instantiate(Cupcake);
        }


    }

    public void GameOver()
    {

    }
}
