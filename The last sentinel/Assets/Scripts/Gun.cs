using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour {
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public int maxAmmo = 100;
    public int maxCapacity = 10;
    private int currentAmmo = -1;
    public float reloadTime = 1f;
    public Camera fpsCamera;
    private bool isReloading = false;
    private float nextTimeToFire = 0f;

    public GameObject bullet;
    private AudioSource gunShot;

    private ParticleSystem explosion;
    bool isPlaying = false;

    public Text reloElement;
    public Text score;
    private int scoreNumber;
    public Text bullets;

    void OnEnable() {
        isReloading = false;
    }
    void Start() {
        if (currentAmmo == -1)
            currentAmmo = maxCapacity;
        gunShot = GetComponent<AudioSource>();
        explosion = GetComponent<ParticleSystem>();
        reloElement.text = "Reloading . . .";
        reloElement.enabled = false;
        scoreNumber = 0;
        score.text = "Score : " + scoreNumber.ToString();
        score.enabled = true;
        bullets.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
        bullets.enabled = true;
       
    }
    // Update is called once per frame
    void Update() {

       
        bullets.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
        bullets.enabled = true;
        if (isReloading)
            return;
        if ((currentAmmo <= 0 && maxAmmo > 0) || Input.GetKeyDown("r")) {
            reloElement.enabled = true;
            StartCoroutine(reload());
            return;
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            Instantiate(bullet, position, transform.rotation);
            gunShot.Play();
            shoot();
        }
        if (!isPlaying)
        {
            explosion.Stop();
        }
        else
        {
            explosion.Play();
            isPlaying = false;
        }
    }
    IEnumerator reload() {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxCapacity;
        maxAmmo -= maxCapacity;
        isReloading = false;
        reloElement.enabled = false;
    }
    void shoot() {
        RaycastHit hitInfo;
        currentAmmo--;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hitInfo, range)) {
            // Debug.LogError(hitInfo.transform.name);
            bullet.transform.LookAt(hitInfo.point);
            Debug.LogError(currentAmmo);
            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null) {
                target.TakeDamage(damage);
            }
            if(target.health <= 0f)
            {
                scoreNumber += 10;
                score.text = "Score : " + scoreNumber.ToString();
                target.GetComponent<Animator>().SetBool("died", true);
                score.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            isPlaying = true;
        }
    }
}
