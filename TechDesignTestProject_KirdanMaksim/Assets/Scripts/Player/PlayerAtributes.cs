using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtributes : MonoBehaviour
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
    public float _criticalСhance = 0.3f;
    public float _criticalDamage = 1f;
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
    public float _blockingChance = 0.05f;
    public int _spellPower = 10;
    public int _attackPower = 10;
    public int _protection = 10;

    [Header("Основные ресурсы персонажа, " +
    "а так же их состояние (включены или нет)")]
    public int _basicHealth = 30;
    public int _basicMana = 60;
    public int _basicStamina = 120;

    public int _maxEvilness = 60;
    public bool _EvilnessActive = false;

    public int _maxLightness = 60;
    public bool _LightnessActive = false;

    public int _basicSpiritism = 60;
    public bool _spiritismActive = false;

    public int _maxRage = 100;
    public bool _rageActive = false;

    public int _maxBattleTrance = 100;
    public bool _battleTranceActive = false;

    public int _maxMagicRunes = 3;
    public bool _MagicRunes = false;

    [Header("Навыки")]
    public int _masteryOfControl = 10;
    public int _blocking = 10;
    public int _blacksmithing = 1;
    public int _engineering = 1;
    public int _сarpentry = 1; //столярное дело
    public int _tailoring = 1; //портняжное дело
    public int _fishing = 1;
    public int _cooking = 1;
    public int _alchemy = 1;
    public int _skinning = 1;
    public int _inscription = 1;
    public int _jewelry = 1; //ювелирное дело
    public int _sculptural = 1;
    public int _mining = 1;
    public int _leatherworking = 1;
    public int _herbalism = 1;
    public int _longBlades = 1;
    public int _shortBlades = 1;
    public int _bluntWeapons = 1; //дробящее оружие
    public int _chainWeapons = 1; //цепное оружие
    public int _shaftWeapons = 1; //древковое оружие
    public int _staffsMagic = 1;
    public int _staffsPhysic = 1;
    public int _wands = 1;
    public int _handWeapons = 1;
    public int _axes = 1;
    public int _archery = 1;
    public int _crossbowShooting = 1;
    public int _throwing = 1;
    public int _trading = 1;
    public int _stealing = 1;
    public int _conviction = 1; // убеждение
    public int _reconciliation = 1; //примирение
    public int _centralRunesKnowledge = 1;
    public int _northRunesKnowledge = 1;

    //Тёмная магия
    public int _necromancy = 1;
    public int _changeOfDarkness = 1;
    public int _bloodyControl = 1;
    public int _flute = 1;

    //Светлая магия
    public int _purification = 1;
    public int _buffOfLigthness = 1;
    public int _spiritOfLightness = 1;
    public int _zither = 1;

    //Святая магия
    public int _holynessOfSoul = 1;
    public int _retribution = 1;
    public int _vowOfSilence = 1;

    //"Восточный" спиритизм
    public int _controlyOfSouls = 1;
    public int _soulChakras = 1;
    public int _unityWithNature = 1;
    public int _erhu = 1;

    //Друидизм
    public int _naturePower = 1;

    private void FixedUpdate()
    {
        additionalAttributes();
    }

    private void additionalAttributes()
    {
        _hit = (float)(4f * _agility + 2f * _intelligence + _spirit + _luck) / 4f / 200f;
        _criticalСhance = (float)(3f * _strength + 2f * _agility + _intelligence + _spirit + _luck) / 5f / 320f;
        _haste = (float)(3f * _agility + _spirit + _luck) / 3f / 50f;
        _criticalDamage = (float)(4f * _spirit + 2f * _agility + _intelligence + _strength + _luck) / 5f / 250f;
        _evasion = (float)(3f * _agility + _intelligence + _charm + 2f * _vitality + _luck) / 5f / 480f;
        _armorPenetrationRating = (float)(2f * _agility + 3f * _intelligence + _spirit + _luck) / 4f / 350f;
        _restoreMagic = (float)(2f * _intelligence + 5f * _spirit + _luck) / 3f / 90f;
        _restoreHealth = (float)(2f * _strength + 5f * _vitality + _luck) / 3f / 90f;
        _restoreStamina = (float)(2f * _strength + 5f * _agility + _luck) / 3f / 90f;
        _allMagicResistance = (float)(2f * _vitality + 5f * _spirit + _charm + _luck) / 4f / 450f;
        _concentration = (float)(3f * _spirit + _luck) / 2f / 400f;
        _blockingChance = (float)(_intelligence + 5f * _vitality + 3f * _agility + _charm + _luck) / 5f / 500f;
        _spellPower = (3 * _intelligence + _spirit + _luck) / 3;
        _attackPower = (3 * _strength + 2 * _agility + _luck) / 3;
        _protection = (4 * _vitality + _strength + _luck) / 3;
    }
}
