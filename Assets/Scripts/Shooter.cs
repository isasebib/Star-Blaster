using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Base Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 3f;
    [SerializeField] float projectileLifeTime = 2f;
    [SerializeField] float baseFireRate = 0.2f;

    [Header("AI Variables")]
    [SerializeField] bool useAI;
    [SerializeField] float minFireRate = 0.2f;
    [SerializeField] float fireRateVariance = 0.3f;

    [HideInInspector] public bool isFiring;
    Coroutine fireCoroutine;
    AudioManager audioManager;

    void Start()
    {
        if(useAI)
            isFiring = true;

        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(RapidFire());            
        }
        else if (!isFiring && fireCoroutine != null)
        {   
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator RapidFire()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            projectile.transform.rotation = transform.rotation;

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            projectileRB.linearVelocity = transform.up * projectileSpeed;

            Destroy(projectile, projectileLifeTime);

            float waitTime = baseFireRate;

            if (useAI)
            {
                waitTime = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
                waitTime = Mathf.Clamp(waitTime, minFireRate, float.MaxValue);
            }

            audioManager.PlayShootingSFX();

            yield return new WaitForSeconds(waitTime);
        }
    }

    
}
