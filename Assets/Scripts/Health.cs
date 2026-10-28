using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] bool isPlayer;
    CameraShake cameraShake;
    AudioManager audioManager;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    int finalScore;

    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager = FindAnyObjectByType<AudioManager>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();  
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitParticles();
            damageDealer.Hit();

            if(isPlayer)
            {
                cameraShake.Play();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        audioManager.PlayDamageSFX();

        if(health<=0)
        {
            if (!isPlayer)
            {
                scoreKeeper.addScore();
                Destroy(gameObject);
            }
                

            if(isPlayer)
            {
                levelManager.LoadGameOver(1.5f);
                Destroy(gameObject);
            }
                
            audioManager.PlayDyingSFX();
            
        }
    }



    public int GetHealth()
    {
        return health;
    }

    void PlayHitParticles()
    {
        if (hitParticles != null)
        {
            ParticleSystem particles = Instantiate(hitParticles, transform.position, Quaternion.identity);
            Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }


    void Update()
    {

    }


}
