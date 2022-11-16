using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    public void setCharacter(GameObject character)
    {
        GameData.instance.character = character;
    }
}
