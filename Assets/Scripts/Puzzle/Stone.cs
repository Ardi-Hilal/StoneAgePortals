using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public GameObject WinUI;
    public bool m_OnRune;

   public bool Move(Vector2 direction)
   {
    if(StoneBlocked(transform.position, direction))
    {
        return false;
    }
    else
    {
        transform.Translate(direction);
        Test();
        return true;
    }
   }

   bool StoneBlocked(Vector3 position, Vector2 direction)
   {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if(wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }

        GameObject[] stones = GameObject.FindGameObjectsWithTag("Stone");
        foreach (var stone in stones)
        {
            if(stone.transform.position.x == newPos.x && stone.transform.position.y == newPos.y)
            {
                Stone st = stone.GetComponent<Stone>();
                if(st && st.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
   }

   void Test()
   {
    GameObject[] runes = GameObject.FindGameObjectsWithTag("Rune");
    foreach (var rune in runes)
    {
        if(transform.position.x == rune.transform.position.x && transform.position.y == rune.transform.position.y)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
            m_OnRune = true;
            Time.timeScale = 0;
            WinUI.SetActive(true);
            Cursor.visible = true;
            return;
            
        }
    }
    GetComponent<SpriteRenderer>().color = Color.white;
    m_OnRune = false;
   }
}
