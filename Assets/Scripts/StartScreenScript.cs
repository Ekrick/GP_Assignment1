using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenScript : MonoBehaviour
{
    [SerializeField] CharacterStats _player1;
    [SerializeField] CharacterStats _player2;
    public void StartGame()
    {
        Cursor.visible = false;
        _player1.gameObject.SetActive(true);
        _player2.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
