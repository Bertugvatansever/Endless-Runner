using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    public Text audioText;
    public Slider audioSlider;
    public Button characterselectButton;
    public GameObject characterselectMenu;
    public Button backButton;
    public Button playButton;
    public Button quitButton;
    public Button optionsButton;
    public string playgameLevel;
    public string ninjaSelect;
    public string playerSelect;

    private void Start()
    {
        audioSlider.gameObject.SetActive(true);
        audioSlider.gameObject.SetActive(false);
    }
    public void PlayGame()
    {
        Application.LoadLevel(playgameLevel);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OptionsMenu()
    {
        playButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        characterselectButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
        audioSlider.gameObject.SetActive(true);
        audioText.gameObject.SetActive(true);
    }
    public void BacktoMainMenu()
    {
        playButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        characterselectButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
        audioSlider.gameObject.SetActive(false);
        audioText.gameObject.SetActive(false);
    }
    public void CharacterSelect()
    {
        characterselectMenu.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        characterselectButton.gameObject.SetActive(false);
    }
    public void NinjaSelect()
    {
        ninjaSelect = "true";
        PlayerPrefs.SetString("ninjaSelect", ninjaSelect);
        playerSelect ="false";
        PlayerPrefs.SetString("playerSelect", playerSelect);
    }
    public void PlayerSelect()
    {
        playerSelect = "true";
        PlayerPrefs.SetString("ninjaSelect", ninjaSelect);
        ninjaSelect = "false";
        PlayerPrefs.SetString("playerSelect", playerSelect);
    }
    public void ApplyCharacterSelect()
    {
        characterselectMenu.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        characterselectButton.gameObject.SetActive(true);
    }

}
