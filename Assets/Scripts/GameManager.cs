using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance { get; private set; }  
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI textStart;
    [SerializeField] private TextMeshProUGUI textTryAgain;
   

    private void Awake()
    {
        Instance = this;
    }
    public void onClick_StartButton()
    {
     
        canvas.enabled = false;
        BallController.Instance.OnStart();

    }

    public void onGameOver()
    {
        canvas.enabled=true;
        textStart.enabled = false;
        textTryAgain.enabled = true;
       

    }
}
