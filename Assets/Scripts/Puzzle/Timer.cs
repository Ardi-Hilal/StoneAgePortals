using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject LoseUI;
    float currentTime = 0f;
    float startingTime = 30f;

    [SerializeField] Text countdown;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -=1 * Time.deltaTime;
        countdown.text = currentTime.ToString("0");

        if(currentTime <=0)
        {
            currentTime = 0;
            LoseUI.SetActive(true);
            Cursor.visible = true;
        }

    }
}
