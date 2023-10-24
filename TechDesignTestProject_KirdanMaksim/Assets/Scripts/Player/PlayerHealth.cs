using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Параметры здоровья игрока")]
    public static int _maxHealthPoints = 30;
    public static int _healthPoints = 10;

    private void Start()
    {
        PlayerAtributes _atributes = gameObject.GetComponent<PlayerAtributes>();
        _maxHealthPoints = (_atributes._basicHealth + _atributes._strength + _atributes._vitality * 2) / 3;
        _healthPoints = _maxHealthPoints;
        Debug.Log(_maxHealthPoints);
    }

    void Update()
    {
        
        if (_healthPoints > _maxHealthPoints)
        {
            _healthPoints = _maxHealthPoints;
        }
        if(_healthPoints < 1)
        {
            Time.timeScale = 0;
        }
    }

    private void EnemyPhysicalAttack(int _weaponDamage, int _strength, int _agility, int _intelligence, int _luck)
    {

    }
}
