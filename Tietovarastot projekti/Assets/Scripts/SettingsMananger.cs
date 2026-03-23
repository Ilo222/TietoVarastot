using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    // Referenssi TMP_Dropdown-komponenttiin hyppyn‰pp‰imen valitsemiseksi
    [SerializeField] TMP_Dropdown jumpKeyInput;

    // Referenssi Slider-komponenttiin ‰‰nenvoimakkuuden s‰‰t‰miseksi
    [SerializeField] Slider volumeSlider;

    // Referenssi Slider-komponenttiin hiiren herkkyyden s‰‰t‰miseksi
    [SerializeField] Slider sensitivitySlider;

    // Referenssi TMP_Dropdown-komponenttiin grafiikka-asetusten s‰‰t‰miseksi
    [SerializeField] TMP_Dropdown graphicsDropdown;

    // Oletusarvot (selkeyden vuoksi m‰‰ritelty t‰nne)
    private const int DEFAULT_JUMP = 0;
    private const float DEFAULT_VOLUME = 0.5f;
    private const float DEFAULT_SENSITIVITY = 1.0f;
    private const int DEFAULT_GRAPHICS = 0;

    private void Start()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        jumpKeyInput.value = PlayerPrefs.GetInt("JumpKey", DEFAULT_JUMP);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", DEFAULT_VOLUME);
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", DEFAULT_SENSITIVITY);
        graphicsDropdown.value = PlayerPrefs.GetInt("Graphics", DEFAULT_GRAPHICS);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("JumpKey", jumpKeyInput.value);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
        PlayerPrefs.SetInt("Graphics", graphicsDropdown.value);

        PlayerPrefs.Save();

        Debug.Log("Asetukset tallennettu");
    }

    public void ResetSettings()
    {
        // Tyhjent‰‰ kaikki PlayerPrefs-arvot
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        // Palauttaa UI:n oletusarvoihin heti
        jumpKeyInput.value = DEFAULT_JUMP;
        volumeSlider.value = DEFAULT_VOLUME;
        sensitivitySlider.value = DEFAULT_SENSITIVITY;
        graphicsDropdown.value = DEFAULT_GRAPHICS;

        Debug.Log("Asetukset palautettu oletusarvoihin");
    }
}