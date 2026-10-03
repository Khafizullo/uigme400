using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    private bool _menuActive = false;

    [Header("UI Panels")]
    [SerializeField] private GameObject _settingsMenuVisualPanel; // Assign the UI graphics folder here
    [SerializeField] private Image _blackOverlay;                  // Assign the image from GlobalOverlayCanvas

    [Header("Audio")]
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _musicSlider;

    [Header("Brightness")]
    [SerializeField] private Slider _brightnessSlider;

    void Start()
    {
        // Apply saved or default slider settings immediately on frame one
        AdjustVolume();
        AdjustBrightness();

        // Ensure the visual settings panel is hidden when the game boots up
        _menuActive = false;
        _settingsMenuVisualPanel.SetActive(false);

        // Ensure the global overlay canvas itself stays active to apply brightness changes
        _blackOverlay.gameObject.SetActive(true);
    }

    void Update()
    {
        // This always runs because SettingsManager is on the root level and never deactivates
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        _menuActive = !_menuActive;
        _settingsMenuVisualPanel.SetActive(_menuActive);

        // Optional: Pauses mini-game time when the settings/pause menu is open
        Time.timeScale = _menuActive ? 0f : 1f;
    }

    public void AdjustVolume()
    {
        if (_audioMixer == null || _musicSlider == null) return;

        float sliderVal = _musicSlider.value;
        if (sliderVal <= 0) sliderVal = 0.0001f; // Prevent log10 math errors at 0

        // Converts linear slider into a smooth, natural logarithmic audio scale
        float dbValue = Mathf.Log10(sliderVal) * 20;
        _audioMixer.SetFloat("BG_Music", dbValue);
    }

    public void AdjustBrightness()
    {
        if (_blackOverlay == null || _brightnessSlider == null) return;

        // Changes the alpha layer of the global overlay image dynamically
        Color tempColor = _blackOverlay.color;
        tempColor.a = _brightnessSlider.value;
        _blackOverlay.color = tempColor;
    }
}