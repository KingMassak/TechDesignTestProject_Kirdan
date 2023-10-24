using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Настройки клавиш")]
    [SerializeField] private KeyCode _longSkillAttackKey = KeyCode.Alpha1;

    [Header("Характеристики базовой атаки")]
    [SerializeField] private float _cooldownBasicAttack = 0.5f;
    [SerializeField] private float _angleBox1;
    [SerializeField] private Transform _pointAttack1;
    [SerializeField] private LayerMask _layerMaskEnemy;
    private float _timingCooldownBasicAttack = -1f;
    private float _longLeftClickTimer = 0f;
    [SerializeField] private GameObject _player;
    private PlayerAtributes _playerAtributes;
    [SerializeField] private int _weaponDamage = 10;

    //[Header("Технические данные")]
    //[SerializeField] private Animator _animator;

    private void Start()
    {
        _playerAtributes = _player.GetComponent<PlayerAtributes>();
    }

    
    private void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        if (_timingCooldownBasicAttack < 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (_longLeftClickTimer < 0.5f)
                {
                    _timingCooldownBasicAttack = _cooldownBasicAttack;
                    //_animator.SetTrigger("Attack");
                    Collider2D[] _enemies = Physics2D.OverlapBoxAll(_pointAttack1.position, new Vector2(_angleBox1, _angleBox1), _angleBox1 / 2, _layerMaskEnemy);
                    for (int i = 0; i < _enemies.Length; i++)
                    {
                        _enemies[i].GetComponent<EnemyHealth>().TakeDamage(_playerAtributes._hit, _playerAtributes._criticalСhance, _playerAtributes._criticalDamage, _playerAtributes._strength, _playerAtributes._agility, _weaponDamage);
                    }

                }
                else if (_longLeftClickTimer >= 0.5f && _longLeftClickTimer <= 3.5f)
                {
                    _timingCooldownBasicAttack = _cooldownBasicAttack;
                    //_animator.SetTrigger("Attack");
                    Collider2D[] _enemies = Physics2D.OverlapBoxAll(_pointAttack1.position, new Vector2(_angleBox1, _angleBox1), _angleBox1 / 2, _layerMaskEnemy);
                    for (int i = 0; i < _enemies.Length; i++)
                    {
                        _enemies[i].GetComponent<EnemyHealth>().TakeDamageLong(_longLeftClickTimer, _playerAtributes._hit, _playerAtributes._criticalСhance, _playerAtributes._criticalDamage, _playerAtributes._strength, _playerAtributes._agility, _weaponDamage);
                    }
                }
                _longLeftClickTimer = 0f;
            } 
            else if (Input.GetMouseButton(0))
            {
                _longLeftClickTimer += Time.deltaTime;
                
            }
            
        } 
        else if(_timingCooldownBasicAttack >= 0)
        {
            _timingCooldownBasicAttack -= Time.deltaTime;
        }
        
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_pointAttack1.position, new Vector2(_angleBox1, _angleBox1));
    }
}
