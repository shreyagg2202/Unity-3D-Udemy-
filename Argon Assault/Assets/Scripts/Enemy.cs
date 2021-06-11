using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    void ProcessHit()
    {
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
