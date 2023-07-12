using UnityEngine;
using UnityEngine.UI;

public class MuteMusicButton : MonoBehaviour
{
    public string muteText = "Mute";
    public string unmuteText = "Unmute";

    private Button button;
    private Text buttonText;

    private AudioManagement audioManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        button = GetComponent<Button>();
        buttonText = button.GetComponentInChildren<Text>();

        audioManager = FindObjectOfType<AudioManagement>();

        if (audioManager != null)
        {
            SetMusicMuted(AudioManagement.musicMuted);

            // Set the button text to "Unmute" if music is muted
            if (AudioManagement.musicMuted)
            {
                buttonText.text = unmuteText;
            }
        }
    }

    public void OnMuteMusicButtonClicked()
    {
        if (audioManager != null)
        {
            if (AudioManagement.musicMuted)
            {
                audioManager.UnmuteMusic();
            }
            else
            {
                audioManager.MuteMusic();
            }

            SetMusicMuted(AudioManagement.musicMuted);
        }
    }

    public void SetMusicMuted(bool muted)
    {
        if (muted)
        {
            buttonText.text = unmuteText;
        }
        else
        {
            buttonText.text = muteText;
        }
    }
}