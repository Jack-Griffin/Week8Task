using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{   
    // Singleton
    static private UIManager instance;
    static public UIManager Instance 
    {
        get 
        {
            if (instance == null) 
            {
                Debug.LogError("There is not UIManager in the scene.");
            }            
            return instance;
        }
    }

    [SerializeField] private TMP_Text ScoreAText;
    [SerializeField] private TMP_Text ScoreBText;
    [SerializeField] private string scoreFormat = "Score: {0}";
    private int scoreA;
    private int scoreB;

    void Awake() 
    {
        if (instance != null)
        {
            // there is already a UIManager in the scene, destory this one
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        ScoreAText.text = string.Format(scoreFormat, ScoreKeeper.Instance.ScoreA);
        ScoreBText.text = string.Format(scoreFormat, ScoreKeeper.Instance.ScoreB);
    }
}
