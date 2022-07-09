using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    private bool m_ReadyForInput;
    private GridMovement m_Player;

    void Start() {
        m_Player = FindObjectOfType<GridMovement>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if(moveInput.sqrMagnitude > 0.5)
        {
            if(m_ReadyForInput)
            {
                m_ReadyForInput = false;
                m_Player.Move(moveInput);

            }
        }
        else
        {
            m_ReadyForInput = true;
        }
    }
}
