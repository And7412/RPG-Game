using RPG.Metagame;
using RPG.Metagame.Heroes;
using RPG.Metagame.Heroes.Player;

public class HeroStatCalculator<T> where T: HeroConfig
{
    private HeroLevel _level;
    private int _difficulty;
    private int _armorFactorHealth = 0;
    private int _armorFactorStamina = 0;
    private const int ConstantFactor = 5000;
    private int _health;
    private int _stamina;
    
    public HeroStatCalculator(HeroLevel level, Difficulty difficulty)
    {
        _level = level;
        _difficulty = (int)difficulty;
    }
    
    //public int Calculate(T config, PlayerAttributes attributes)//Is the name correct?
    //{
    //    _stamina = _level.Level * config.MaxStamina + (attributes.GetPoints(AttributeName.Agility)*10) + _armorFactorStamina;
    //    _stamina *= (ConstantFactor/_difficulty );
    //    return _stamina;
    //}
    public int SetMaxHealth(T config)
    {
        _health = _level.Level * config.MaxHealth + _armorFactorHealth;
        _health *= ConstantFactor / _difficulty;
        return _health;
    }

    public int SetMaxHealth(T config, PlayerAttributes attributes)
    {
        _health = _level.Level * config.MaxHealth + _armorFactorHealth + attributes.GetPoints(AttributeName.Endurance) * 10;
        _health *= ConstantFactor / _difficulty;
        return _health;
    }

    public int SetMaxStamin(T config)
    {
        _stamina = _level.Level * config.MaxStamina + _armorFactorStamina;
        return _stamina;
    }

    public int SetMaxStamin(T config, PlayerAttributes attributes)
    {
        _stamina = _level.Level * config.MaxStamina + _armorFactorStamina + attributes.GetPoints(AttributeName.Endurance)*10;
        return _stamina;
    }
}