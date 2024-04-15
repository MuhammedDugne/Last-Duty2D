using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioSource enemy;
    /* public AudioClip enemyAnounceVoice;
    public AudioClip enemyDamageVoice;
    public AudioClip enemyDestroyVoice;
    public AudioClip bossAnounceVoice;
    public AudioClip bossDamageVoice;
    public AudioClip bossDestroyVoice;
    public AudioClip gateOpenVoice; */
    public AudioClip earthquake;
    private float enemyHealth = 100f;
    private float bossHealth = 10f;
    public bool isDeadBoss = false;
    private ShakeCamera shake;

    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.FindWithTag("Virtual");
        Rigidbody2D camRb = cam.GetComponent<Rigidbody2D>();
        shake = camRb.GetComponent<ShakeCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D otherCollider = collision.collider;
        GameObject ammo = otherCollider.gameObject;
        Debug.Log(ammo.name);
        if (ammo.name == "ammo(Clone)")
        {
            GameObject soldier = GameObject.Find("Soldier");
            Rigidbody2D rbSoldier = soldier.GetComponent<Rigidbody2D>();
            Fire stats = rbSoldier.GetComponent<Fire>();
            if (gameObject.name == "enemy")
                enemyTakeDamage(stats._damage);
            else if (gameObject.name == "boss")
                bossTakeDamage(stats._damage);
        }
    }

    private void enemyTakeDamage(float damage)
    {
        enemyHealth -= damage;
        /* if (enemyHealth <= 0)
        {
            enemy.clip = enemyDestroyVoice;
            enemy.Play();
        }
        else
        {
            enemy.clip = enemyDamageVoice;
            enemy.Play();
        } */
    }

    private void bossTakeDamage(float damage)
    {
        bossHealth -= damage;
        if (bossHealth <= 0)
        {
            isDeadBoss = true;
            shake.StartShakeCoroutine(12f, 10.0f);
            enemy.clip = earthquake;
            enemy.Play();
            StartCoroutine(WaitForShakeToEnd());
            /* enemy.clip = bossDestroyVoice;
            enemy.Play(); */
        }
        /* else
        {
            enemy.clip = bossDamageVoice;
            enemy.Play();
        } */
    }

    private IEnumerator WaitForShakeToEnd()
    {
        while (shake.getisShaking())
            yield return null;
        Destroy(gameObject);
    }
}
