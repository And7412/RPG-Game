using RPG.Metagame;
using RPG.Metagame.Heroes;
using RPG.Metagame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlayerStatCreate<T> where T: HeroConfig
{
    private PlayerLevel _level;
    private int _difficulty;
    private int _armorFactorHelse = 0;
    private int _armorFactorStamina = 0;
    private const int ConstantFactor = 5000;
    private int _helse;
    private int _stamina;

    public FinalPlayerStatCreate(int armorFactorStamina, int armorFactorHelse, PlayerLevel level, Difficulty difficulty)
    {
        _armorFactorStamina = armorFactorStamina;
        _armorFactorHelse = armorFactorHelse;
        _level = level;
        _difficulty = (int)difficulty;
    }
    public FinalPlayerStatCreate(PlayerLevel level, Difficulty difficulty)
    {
        _level = level;
        _difficulty = (int)difficulty;
    }
    public int SetMaxStramina(T config, PlayerAttributes attributes)
    {
        _stamina = _level.Level * config.MaxStamina + (attributes.HowManyPoint(AttributeName.Agility)*10) + _armorFactorStamina;
        _stamina = _stamina * (ConstantFactor/_difficulty );
        return _stamina;
    }
    public int SetMaxHelse(T config)
    {
        _helse = _level.Level * config.MaxHealth + _armorFactorHelse;
        _helse = _helse * (ConstantFactor / _difficulty);
        return _helse;
    }
}