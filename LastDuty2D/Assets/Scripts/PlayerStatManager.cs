using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    public float _health;
    public float _speed;
    public float _energy;
    public bool energyFlag;
    private float _riffleDamage;
    private float _shotgunDamage;



    void Awake()
    {
        _health = 100.0f;
        _speed = 3.0f;
        _riffleDamage = 10.0f;
        _shotgunDamage = 40.0f;
        _energy = 100.0f;
        energyFlag = true;
    }

    void FixedUpdate()
    {
        if (_energy < 100.0f && energyFlag == true)
            _energy += (Time.fixedDeltaTime * 20);
    }

    public void healthChange(float changeValue)
    {
        _health += changeValue;
    }

    public void speedChange()
    {
        _speed += 1.0f;
    }

    public void damageChange(int flag)
    {
        if (_health >= 100 && flag == 0)
        {
            _riffleDamage += (_riffleDamage / 10f);
            _shotgunDamage += (_shotgunDamage / 10f);
        }
        else if (flag == 1)
        {
            _riffleDamage += (_riffleDamage / 4f);
            _shotgunDamage += (_shotgunDamage / 4f);
        }
    }

    public float getDamage(int weapon)
    {
        if (weapon == 1)
            return (_riffleDamage);
        else if (weapon == 2)
            return (_shotgunDamage);
        else
            return 0;
    }
}
