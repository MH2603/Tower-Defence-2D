using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;    

    [Header("Sound")]
    public bool isSound;
    public AudioSource audioSound;
    public Button btnSoundOn;
    public Button btnSoundOff;

    [Header("Music")]
    public bool isMusic;
    public AudioSource audioMusic;
    public Button btnMusicOn;   
    public Button btnMusicOff;

    bool isSetUp;

    [Header(" Sound Asset")]
    public AudioClip soundOnOff;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PLayerPrefManager.Sound = PLayerPrefManager.Sound;
        PLayerPrefManager.Music = PLayerPrefManager.Music;

        Init(); 
    }

    public void Init()
    {
        isSound = PLayerPrefManager.Sound;
        isMusic = PLayerPrefManager.Music;

        SetSoundStatus(isSound);
        SetMusicStatus(isMusic);    

        btnSoundOn.onClick.AddListener( () => SetSoundStatus(false) );
        btnSoundOff.onClick.AddListener( () => SetSoundStatus(true) );


        btnMusicOn.onClick.AddListener( () => SetMusicStatus(false) );   
        btnMusicOff.onClick.AddListener ( () => SetMusicStatus(true) );

        audioSound.ignoreListenerPause = true;
        audioSound.ignoreListenerVolume = true;

        isSetUp = true; 
    }

    public void SetSoundStatus(bool status )
    {
        isSound = status;

        ShowSound(soundOnOff, 0.3f);

        PLayerPrefManager.Sound = status;

        btnSoundOn.gameObject.SetActive(status);
        btnSoundOff.gameObject.SetActive(!status);

        
    }

    public void SetMusicStatus(bool status)
    {
        isMusic = status;
        PLayerPrefManager.Music = status;

        btnMusicOn.gameObject.SetActive(status);
        btnMusicOff.gameObject.SetActive(!status);  

        ToggleMusic(status);

        ShowSound(soundOnOff, 0.3f);
    }

    public void ShowSound(AudioClip clip, float volume = 0.5f) // call by methor
    {
        if( PLayerPrefManager.Sound && isSetUp) audioSound.PlayOneShot(clip, volume );
    }

    public void PlaySound(AudioClip clip) // call by event btn
    {
        if (PLayerPrefManager.Sound && isSetUp) audioSound.PlayOneShot(clip);
    }

    public void ToggleMusic(bool status)
    {
        audioMusic.mute = !status;

        if( !status) audioMusic.Pause();    
        else audioMusic.Play(); 
    }

    
}
