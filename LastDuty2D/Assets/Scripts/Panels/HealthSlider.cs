using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _energySlider;
    public PlayerStatManager playerStat;
    // Start is called before the first frame update
    void Start()
    {
        playerStat = GetComponent<PlayerStatManager>();
        _healthSlider.value = 1;
        _energySlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _healthSlider.value = playerStat._health / 100.0f;
        _energySlider.value = playerStat._energy / 100.0f;
    }
}
