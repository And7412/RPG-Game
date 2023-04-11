using System.Collections.Generic;

namespace RPG.Metagame.Player
{
    public class PlayerAttributes
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

        public void AddSkill(AttributeName name, int count)
        {
            var skill = _skills[name];
            skill.AddPoints(count);
        }

        public int GetPoints(AttributeName name)
        {
            return _skills[name].Value;
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
        Strength,
        Endurance,
        Intelligence,
        Agility,
        Speed,
        Genius,
        Diligence
    }
}