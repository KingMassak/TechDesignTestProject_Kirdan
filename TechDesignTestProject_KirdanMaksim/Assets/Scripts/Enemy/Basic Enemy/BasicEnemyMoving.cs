using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMoving : MonoBehaviour
{
    [Header("Харакатеристики существа:")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rangeOfPatrol = 5f;
    [SerializeField] private float _aggroDistance = 5f;
    [SerializeField] private float _stopAggroDistance = 20f;
    [SerializeField] private float _stopDistanceBetweenEnemyAndPlayer = 2f;

    [Header("Технические данные:")]
    [SerializeField] private Transform _pointOfEnemy;
    private Transform _playerTransform;
    private Rigidbody2D rb;
    

    // Переменные типа Bool, отвечающие за состояние существа:
    private bool _chill = false;
    private bool _angry = false;
    private bool _goBack = false;

    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.drag = 20;
    }

    
    void Update()
    {
        //Условия передвижения
        if(Vector2.Distance(transform.position, _pointOfEnemy.position) < _rangeOfPatrol && _angry == false)
        {
            _chill = true;
        }

        if(Vector2.Distance(transform.position, _playerTransform.position) < _aggroDistance)
        {
            _angry = true;
            _chill = false;
            _goBack = false;
        }
        else if (Vector2.Distance(_pointOfEnemy.position, _playerTransform.position) > _stopAggroDistance)
        {
            _goBack = true;
            _angry = false;
        }

        if (_chill)
        {
            Chill();
        }
        if (_angry)
        {
            Angry();
        }
        if (_goBack)
        {
            GoBack();
        }
    }

    private void Chill()
    {

    }

    private void Angry()
    {
        if (Vector2.Distance(transform.position, _playerTransform.position) > _stopDistanceBetweenEnemyAndPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
        }
        
    }

    private void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, _pointOfEnemy.position, _speed * Time.deltaTime);
    }

}
