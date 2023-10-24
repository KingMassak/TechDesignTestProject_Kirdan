using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAtributes : MonoBehaviour
{
    [Header("Главные атрибуты и их значение")]
    public int _strength = 30;
    public int _agility = 30;
    public int _intelligence = 30;
    public int _vitality = 30;
    public int _spirit = 30;
    public int _charm = 30;
    public int _luck = 30;

    [Header("Дополнительные атрибуты")]
    public float _criticalСhance = 0;
    public float _criticalDamage = 1;
    public float _haste = 1;
    public float _evasion = 0;
    public float _armorPenetrationRating = 0;
    public float _hit = 0.4f;
    public float _restoreMagic = 0.5f;
    public float _restoreHealth = 0.5f;
    public float _restoreStamina = 0.5f;
    public float _allMagicResistance = 0;
    public float _darkMagicResistance = 0;
    public float _holyMagicResistance = 0;
    public float _lightMagicResistance = 0;
    public float _spiritismResistance = 0;
    public float _naturePowerResistance = 0;
    public float _fireMagicResistance = 0;
    public float _iceMagicResistance = 0;
    public float _concentration = 0.4f;
    public float _blockingChance = 0.3f;
    public int _masteryOfControl = 10;
    public int _blocking = 10;
    public int _spellPower = 10;
    public int _attackPower = 10;
    public int _protection = 10;
}
