using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterManager : MonoBehaviour
{

    public CharacterDatabase characterDB;
    public TMP_Text nameText;
    public Image artworkSprite;
    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("selectedOption"))
        {
            load();
        }else
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextOption()
    {
        selectedOption++;
        if(selectedOption >= characterDB.character.Length)
        {
            selectedOption = 0;
        }
    }
    public void UpdateCharacter(int SelectedOption)
    {
        Character character = characterDB.GetCharacter(SelectedOption);
        nameText.text = character.characterName;
    }

    public void save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
