using UnityEngine;
using UnityEngine.UI;
public class VolumeSettings : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public void SetAudioVolume()
    {
        AudioManager.Instance.ChangeVolume(volumeSlider.value);
    }
}
