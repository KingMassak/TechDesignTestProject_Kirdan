using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Характеристики здоровья существа")]
    public int _health = 30;
    [SerializeField] private float _takeDamageDelay = 0.1f;
    private float _takeDamageDelayTimer = 0f;
    private BasicEnemyAtributes _BEA;

    private SpriteRenderer _rend;

    private void Start()
    {
        _BEA = gameObject.GetComponent<BasicEnemyAtributes>();
        _rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(_health < 1)
        {
            Destroy(gameObject);
        }

        if (_takeDamageDelayTimer >= 0)
        {
            _takeDamageDelayTimer -= Time.deltaTime;
        }
    }

    private void ToNormalColor()
    {
        _rend.color = Color.white;
    }

    public void TakeDamage(float _hitChance, float _critChance, float _critDamage, int _strength, int _agility, int _weaponDamage)
    {
        if (_takeDamageDelayTimer < 0)
        {
            _takeDamageDelayTimer = _takeDamageDelay;
            if (Random.Range(0f, 1f) < _hitChance)
            {
                if (Random.Range(0f, 1f) > _BEA._evasion) //уклонение берётся базовое, если надо, то меняй
                {
                    if (Random.Range(0f, 1f) > _BEA._blockingChance) //рассчёт без блока, блок тоже базовый
                    {
                        if (Random.Range(0f, 1f) < _critChance) //рассчёт с критом
                        {
                            int _damage = ((int)(_weaponDamage + _strength + _agility + _critDamage / 3)) - _BEA._protection;
                            if(_damage > 0)
                            {
                                _health -= _damage;
                                Debug.Log("Enemy -" + _damage);
                                _rend.color = Color.red;
                                Invoke("ToNormalColor", 0.4f);
                            }
                            else
                            {
                                Debug.Log("Не пробил!");
                            }
                            
                        }
                        else //без крита
                        {
                            int _damage = (_weaponDamage + _strength + _agility / 3) - _BEA._protection;
                            if (_damage > 0)
                            {
                                _health -= _damage;
                                Debug.Log("Enemy -" + _damage);
                                _rend.color = Color.red;
                                Invoke("ToNormalColor", 0.4f);
                            }
                            else
                            {
                                Debug.Log("Не пробил!");
                            }
                            
                        }
                    }
                    else //рассчёт с блоком
                    {
                        if (Random.Range(0f, 1f) < _critChance) //рассчёт с критом
                        {
                            int _damage = ((int)(_weaponDamage + _strength + _agility * _critDamage / 3)) - (_BEA._protection + _BEA._blocking);
                            if (_damage > 0)
                            {
                                _health -= _damage;
                                Debug.Log("Enemy -" + _damage);
                                _rend.color = Color.red;
                                Invoke("ToNormalColor", 0.4f);
                            }
                            else
                            {
                                Debug.Log("Не пробил!");
                            }
                        }
                        else //без крита
                        {
                            int _damage = (_weaponDamage + _strength + _agility / 3) - (_BEA._protection + _BEA._blocking);
                            if (_damage > 0)
                            {
                                _health -= _damage;
                                Debug.Log("Enemy -" + _damage);
                                _rend.color = Color.red;
                                Invoke("ToNormalColor", 0.4f);
                            }
                            else
                            {
                                Debug.Log("Не пробил!");
                            }
                        }
                    }
                }
            }

        }
    }

    public void TakeDamageLong(float _delay, float _hitChance, float _critChance, float _critDamage, int _strength, int _agility, int _weaponDamage)
    {
        
        if(_takeDamageDelayTimer < 0)
        {
            _takeDamageDelayTimer = _takeDamageDelay;
            if (Random.Range(0f, 1f) < _hitChance)
            {
                if (Random.Range(0f, 1f) > _BEA._evasion) //уклонение берётся базовое, если надо, то меняй
                {
                    if (Random.Range(0f, 1f) > _BEA._blockingChance) //рассчёт без блока, блок тоже базовый
                    {
                        if (Random.Range(0f, 1f) < _critChance) //рассчёт с критом
                        {
                            int _damage = (int)(((_weaponDamage + _strength + _agility * _critDamage / 3) - _BEA._protection) * _delay);
                            if (_damage > 0)
                            {
                                _health -= _damage;
                                Debug.Log("Enemy -" + _damage);
                                _rend.color = Color.red;
                                Invoke("ToNormalColor", 0.4f);
                            }
                            else
                            {
                                Debug.Log("Не пробил!");
                            }
                        }
                        else //без крита
                        {
                            int _damage = (int)(((_weaponDamage + _strength + _agility / 3) - _BEA._protection) * _delay);
                            if (_damage > 0)
                            {
                                _health -= _damage;
                                Debug.Log("Enemy -" + _damage);
                                _rend.color = Color.red;
                                Invoke("ToNormalColor", 0.4f);
                            }
                            else
                            {
                                Debug.Log("Не пробил!");
                            }
                        }
                    }
                    else //рассчёт с блоком
                    {
                        if (Random.Range(0f, 1f) < _critChance) //рассчёт с критом
                        {
                            int _damage = (int)(((_weaponDamage + _strength + _agility * _critDamage / 3) - (_BEA._protection + _BEA._blocking)) * _delay);
                            if (_damage > 0)
                            {
                                _health -= _damage;
                                Debug.Log("Enemy -" + _damage);
                                _rend.color = Color.red;
                                Invoke("ToNormalColor", 0.4f);
                            }
                            else
                            {
                                Debug.Log("Не пробил!");
                            }
                        }
                        else //без крита
                        {
                            int _damage = (int)(((_weaponDamage + _strength + _agility / 3) - (_BEA._protection + _BEA._blocking)) * _delay);
                            if (_damage > 0)
                            {
                                _health -= _damage;
                                Debug.Log("Enemy -" + _damage);
                                _rend.color = Color.red;
                                Invoke("ToNormalColor", 0.4f);
                            }
                            else
                            {
                                Debug.Log("Не пробил!");
                            }
                        }
                    }
                }
            }
        }
    }
}
