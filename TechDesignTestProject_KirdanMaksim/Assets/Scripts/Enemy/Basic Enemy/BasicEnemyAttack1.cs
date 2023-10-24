using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAttack1 : MonoBehaviour
{
    [Header("Технические данные:")]
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _playerTransform;
    private EnemyHealth _enemyHealth;

    //bool для корутины
    [SerializeField] private bool _playerInSight;
    private bool _coroutineIsStarted = false;

    private void Start()
    {
        _enemyHealth = _enemy.GetComponent<EnemyHealth>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //поворот в сторону игрока
        Vector3 diference = _playerTransform.position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        //синергия с существом
        if(_enemyHealth._health > 1)
        {
            transform.position = _enemy.transform.position;
        }
        

        if(_enemyHealth._health < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //запуск корутины которая атакует игрока(доделай)
        if (collision.tag == "Player")
        {
            _playerInSight = true;
            if (_coroutineIsStarted == false)
            {
                StartCoroutine("AttackCoroutine");
                _coroutineIsStarted = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playerInSight = false;
        }
    }

    private void Attack()
    {
        PlayerHealth._healthPoints -= 10;
        Debug.Log(PlayerHealth._healthPoints);
    }

    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(2f);
        while(true)
        {
            if(_playerInSight)
                Attack();
            yield return new WaitForSeconds(2f);
        }
    }
}
