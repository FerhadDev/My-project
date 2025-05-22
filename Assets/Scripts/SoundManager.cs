using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;
    public AudioClip BackGround;
    public AudioClip LightAtack;
    public AudioClip Heavyatack;

    void Start()
    {
        Music.clip = BackGround;
        Music.Play();
    }
    public void SFXSound(AudioClip Clip)
    {
        SFX.PlayOneShot(Clip);
    }
}
