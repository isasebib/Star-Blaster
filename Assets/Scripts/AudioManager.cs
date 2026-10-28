using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")] 
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0, 1)] float shootingVolume;

    [Header("Damage SFX")] 
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0, 1)] float damageVolume;

    [Header("Dying SFX")] 
    [SerializeField] AudioClip dyingClip;
    [SerializeField] [Range(0, 1)] float dyingVolume;




    public void PlayShootingSFX()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }

    public void PlayDamageSFX()
    {
        if (damageClip != null)
        {
            AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, damageVolume);
        }
    }


    public void PlayDyingSFX()
    {
        if (dyingClip != null)
        {
            AudioSource.PlayClipAtPoint(dyingClip, Camera.main.transform.position, dyingVolume);
        }
    }


}
