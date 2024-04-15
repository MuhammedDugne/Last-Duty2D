using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    [SerializeField] private GameObject _box;
    private float   boxHealth = 100f;
    private int     randomNumber;     
    [SerializeField] private GameObject _speed;
    [SerializeField] private GameObject _damage;
    [SerializeField] private GameObject _health;
    public AudioSource _boxSource;
    public AudioClip boxDamage;

    public void boxDamageVoice()
    {
        _boxSource.clip = boxDamage;
        _boxSource.volume = PlayerPrefs.GetFloat("game");
        _boxSource.Play();
    }

    public void takeDamage(float damage)
    {
        boxHealth -= damage;
        if (boxHealth <= 0)
            crushBox();
        else
            StartCoroutine("Vibrate");
    }

    void crushBox()
    {
        randomNumber = Random.Range(1, 11);
        if (randomNumber >= 1 && randomNumber <= 4)
        {
            _speed.transform.position = _box.transform.position;
            _speed.SetActive(true);
        }

        else if (randomNumber >= 5 && randomNumber <= 6)
        {
            _health.transform.position = _box.transform.position;
            _health.SetActive(true);
        }

        else if (randomNumber >= 7 && randomNumber <= 10)
        {
            _damage.transform.position = _box.transform.position;
            _damage.SetActive(true);
        }
        _box.SetActive(false);
    }

    public void objectActiveFalse(string name)
    {
        if (name == "speed")
            _speed.SetActive(false);
        else if (name == "damage_plus")
            _health.SetActive(false);
        if (name == "heath")
            _damage.SetActive(false);
    }

    IEnumerator Vibrate()
    {
        boxDamageVoice();
        // Zamanla titreşim efekti
        float duration = 0.2f;
        float magnitude = 0.05f;

        Vector3 originalPos = transform.position;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = originalPos.x + Mathf.Sin(Time.time * 100) * magnitude;
            transform.position = new Vector3(x, originalPos.y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPos;
    }
}
