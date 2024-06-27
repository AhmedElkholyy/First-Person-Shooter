using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public AudioSource shootingAudio;

    private bool isShooting = false;
    private bool isShootingSoundPlaying = false;
    private bool isMuzzleFlashPlaying = false;

    private void Start()
    {
        StopMuzzleFlash();
        muzzleFlash.Stop();
    }

    private void Update()
    {
         if (transform.position.y < 1)
        {
            ReloadScene();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
            PlayShootingSound();
        }

        if (isShooting && Input.GetButton("Fire1"))
        {
            ShootRaycast();
            PlayMuzzleFlash();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
            StopShootingSound();
            StopMuzzleFlash();
        }
    }

    private void ShootRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            

            if (hit.transform.CompareTag("Enemy"))
            {
                EnemyController enemy = hit.transform.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    
                    enemy.TakeDamage(20);
                }
               
            }
           
        }
        
    }

    private void PlayMuzzleFlash()
    {
        if (!isMuzzleFlashPlaying)
        {
            muzzleFlash.Play();
            isMuzzleFlashPlaying = true;
        }
    }

    private void StopMuzzleFlash()
    {
        if (isMuzzleFlashPlaying)
        {
            muzzleFlash.Stop();
            isMuzzleFlashPlaying = false;
        }
    }

    private void PlayShootingSound()
    {
        if (!isShootingSoundPlaying)
        {
            shootingAudio.loop = true;
            shootingAudio.Play();
            isShootingSoundPlaying = true;
        }
    }

    private void StopShootingSound()
    {
        if (isShootingSoundPlaying)
        {
            shootingAudio.Stop();
            isShootingSoundPlaying = false;
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
