using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject gameData;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.FindGameObjectWithTag("GameData");
        totalHealthBar.fillAmount = gameData.GetComponent<GameData>().heroHealth /10;
    }

    // Update is called once per frame
    void Update()
    {
        currHealthBar.fillAmount = gameData.GetComponent<GameData>().heroHealth / 10;
    }
}
