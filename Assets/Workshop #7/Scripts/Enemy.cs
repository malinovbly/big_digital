using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Enemy : MonoBehaviour
{
    public GameObject cubePiecePrefab;
    public float explodeForce = 500f;

    AudioSource enemyHitSound;
    
    [SerializeField] TextMeshProUGUI textScore;

    void Start()
    {
        textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();
        enemyHitSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ExplodeCube();
            AddScore();
        }
    }

    private void AddScore()
    {
        Progress.Instance.PlayerInfo.Score += 10;
        textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();
        if (Progress.Instance.PlayerInfo.Score == 100)
        {
            SceneManager.LoadScene("Workshop #7");
        }
    }

    private void ExplodeCube()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int z = 0; z < 4; z++)
                {
                    Vector3 piecePosition = transform.position + new Vector3(x, y, z) * 0.5f;
                    GameObject piece = Instantiate(cubePiecePrefab, piecePosition, Quaternion.identity);
                    Rigidbody pieceRigidbody = piece.GetComponent<Rigidbody>();
                    pieceRigidbody.AddExplosionForce(explodeForce, transform.position, 5f);
                }
            }
        }
        PlayHitSound();
        Destroy(gameObject);
    }

    private void PlayHitSound()
    {
        GameObject tempAudio = new GameObject("TempAudio");
        AudioSource audioSource = tempAudio.AddComponent<AudioSource>();
        audioSource.clip = enemyHitSound.clip;
        audioSource.Play();
        Destroy(tempAudio, audioSource.clip.length);
    }
}