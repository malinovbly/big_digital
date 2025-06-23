using UnityEngine;

public class BulletSpawner7 : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletVelocity = 20f;
    AudioSource bulletSound;

    void Start()
    {
        bulletSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletVelocity;

            bulletSound.Play();
        }
    }
}