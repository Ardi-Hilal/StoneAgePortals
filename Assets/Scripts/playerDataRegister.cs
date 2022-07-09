using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDataRegister : MonoBehaviour
{
    // ini Script cuma ada buat ngedaftarin Player gameObject ke GameData
    // gua cek dari tadi caranya antara bikin listener OnLoadScene (yg kgk bisa)
    // kalo gak bikin kek ginian
    
    public GameObject gameData;
    
    void Awake() {
        gameData = GameObject.FindGameObjectWithTag("GameData");

        if (gameData != null) {
            gameData.GetComponent<GameData>().CheckPlayer();
    }
    }

}
