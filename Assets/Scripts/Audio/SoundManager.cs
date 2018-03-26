using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : GenericSingleton<SoundManager> {

    #region Properties
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip positiveSfx;
    public AudioClip negativeSfx;
    public AudioClip optionSwitchSfx;
    #endregion

    public enum SFX
    {
        POSITIVE,
        NEGATIVE,
        OPTIONSWITCH
    }

    public void PlaySfx(SFX s)
    {
        switch (s)
        {
            case SFX.POSITIVE:
                {
                    sfxSource.clip = positiveSfx;
                    sfxSource.Play();
                    break;
                }
            case SFX.NEGATIVE:
                {
                    sfxSource.clip = negativeSfx;
                    sfxSource.Play();
                    break;
                }
            case SFX.OPTIONSWITCH:
                {
                    sfxSource.clip = optionSwitchSfx;
                    sfxSource.Play();
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
