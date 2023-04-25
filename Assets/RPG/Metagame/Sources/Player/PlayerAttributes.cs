using System.Collections.Generic;
using RPG.Shared.UserData;
using RPG.Shared.UserData.HeroSave;

namespace RPG.Metagame.Player
{
    public class PlayerAttributes : ISavable<HeroAttributesData>
    {
        private readonly Dictionary<AttributeName, Attribute> _skills;

        public PlayerAttributes(int strength, int endurance, int intelligence, int agility, int speed, int genius, int diligence)
        {
            _skills = new Dictionary<AttributeName, Attribute>();
            _skills.Add(AttributeName.Strength, new Attribute(AttributeName.Strength, strength));
            _skills.Add(AttributeName.Agility, new Attribute(AttributeName.Agility, agility));
            _skills.Add(AttributeName.Diligence, new Attribute(AttributeName.Diligence, diligence));
            _skills.Add(AttributeName.Endurance, new Attribute(AttributeName.Endurance, endurance));
            _skills.Add(AttributeName.Intelligence, new Attribute(AttributeName.Intelligence, intelligence));
            _skills.Add(AttributeName.Genius, new Attribute(AttributeName.Genius, genius));
            _skills.Add(AttributeName.Speed, new Attribute(AttributeName.Speed, speed));
        }

        public PlayerAttributes(HeroAttributesData data)
        {
            _skills = new Dictionary<AttributeName, Attribute>();
            _skills.Add(AttributeName.Strength, new Attribute(AttributeName.Strength, data.Strength));
            _skills.Add(AttributeName.Agility, new Attribute(AttributeName.Agility, data.Agility));
            _skills.Add(AttributeName.Diligence, new Attribute(AttributeName.Diligence, data.Diligence));
            _skills.Add(AttributeName.Endurance, new Attribute(AttributeName.Endurance, data.Endurance));
            _skills.Add(AttributeName.Intelligence, new Attribute(AttributeName.Intelligence, data.Intelligence));
            _skills.Add(AttributeName.Genius, new Attribute(AttributeName.Genius, data.Genius));
            _skills.Add(AttributeName.Speed, new Attribute(AttributeName.Speed, data.Speed));
        }

        public void AddSkill(AttributeName name, int count)
        {
            var skill = _skills[name];
            skill.AddPoints(count);
        }

        public int GetPoints(AttributeName name)
        {
            return _skills[name].Value;
        }

        public HeroAttributesData GetForSave()
        {
            return new HeroAttributesData()
            {
                Agility = GetPoints(AttributeName.Agility),
                Diligence = GetPoints(AttributeName.Diligence),
                Endurance = GetPoints(AttributeName.Endurance),
                Genius = GetPoints(AttributeName.Genius),
                Intelligence = GetPoints(AttributeName.Intelligence),
                Speed = GetPoints(AttributeName.Speed),
                Strength = GetPoints(AttributeName.Strength)
            };
        }
    }

    public class Attribute
    {
        public int Value { get; private set; }
        public AttributeName Name { get; }

        public Attribute(AttributeName name)
        {
            Name = name;
        }

        public Attribute(AttributeName name, int value)
        {
            Name = name;
            Value = value;
        }

        public void AddPoint()
        {
            Value++;
        }

        public void AddPoints(int count)
        {
            Value += count;
        }
    }

    public enum AttributeName
    {
        Null,
        Strength,//Сила => Сила удара (+5 урона(физ.) за ед.)
        Endurance,//Выносливость => Здоровье и Выносливость (+10 ед. за ед.)
        Intelligence,//Интеллект => Шанс критического удара (+0,1%) //прирост XP (+0,1% за ед.)
        Agility,//Ловкость => Шанс уклонения (+0,1 % за ед.)
        Speed,//Скорость => Восполнение инициативы (+1 ед. за ур.)
        Genius,//Гениальность => прирост XP (случайным образом выдаться и обратно пропорционален Упорству в большинстве случаев) (+0% при 1 ед.; +10% при 2ед.; +20% при 3)
        Diligence//Трудолюбие => Модификатор к приросту навыков (Выносливость или Сила или Ловкость или Скорость или Интеллект) (2 навыка при 1ед.; 3 навыка при 2; 4 навыка при 3)
    }
}