using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    

    // Singleton
    static private ScoreKeeper instance;
    static public ScoreKeeper Instance 
    {
        get 
        {
            if (instance == null)
            {
                Debug.LogError("There is no GameManager instance in the scene.");
            }
            return instance;
        }
    }
    [SerializeField] private int pointsPerPickup;
    private int scoreA;
    private int scoreB;

    public int ScoreA
    {
        get
        {
            return scoreA;
        }
    }

    public int ScoreB
    {
        get
        {
            return scoreB;
        }
    }

    void Awake()
    {
        if (instance != null) 
        {
            // destroy duplicates
            Destroy(gameObject);            
        }
        else 
        {
            instance = this;
        }        
    }

    public void scoreIncreaseA()
    {
        scoreA += pointsPerPickup;
    }

    public void scoreIncreaseB()
    {
        scoreB += pointsPerPickup;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
