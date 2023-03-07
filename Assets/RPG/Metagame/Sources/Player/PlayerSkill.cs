namespace RPG.Metagame.Player
{
    public class PlayerSkill
    {
        public readonly Skill Strength = new Skill(SkillName.Strength);
        public readonly Skill Endurance = new Skill(SkillName.Endurance);
        public readonly Skill Intelligence = new Skill(SkillName.Intelligence);
        public readonly Skill Agility = new Skill(SkillName.Agility);
        public readonly Skill Speed = new Skill(SkillName.Speed);
        public readonly Skill Genius = new Skill(SkillName.Genius);
        public readonly Skill Diligence= new Skill(SkillName.Diligence);

        public PlayerSkill(int strength, int endurance, int intelligence, int agility, int speed, int genius, int diligence)
        {
            Strength.SetValue(strength);
            Endurance.SetValue(endurance);
            Intelligence.SetValue(intelligence);
            Agility.SetValue(agility);
            Speed.SetValue(speed);
            Genius.SetValue(genius);
            Diligence.SetValue(diligence);
        }

        public void addSkill(SkillName skill,int Count)
        {
            switch (skill)
            {
                case SkillName.Strength:
                    Strength.SetValue(Count);
                    break;
                case SkillName.Endurance:
                    Endurance.SetValue(Count);
                    break;
                case SkillName.Intelligence:
                    Intelligence.SetValue(Count);
                    break;
                case SkillName.Agility:
                    Agility.SetValue(Count);
                    break;
                case SkillName.Speed:
                    Speed.SetValue(Count);
                    break;
                case SkillName.Genius:
                    Genius.SetValue(Count);
                    break;
                case SkillName.Diligence:
                    Diligence.SetValue(Count);
                    break;
            }
        }

        public int HowManyPoint(SkillName name)
        {
            switch (name)
            {
                case SkillName.Null:
                    return 0;
                case SkillName.Strength:
                    return Strength.HowManyPoint();
                case SkillName.Endurance:
                    return Endurance.HowManyPoint();
                case SkillName.Intelligence:
                    return Intelligence.HowManyPoint();
                case SkillName.Agility:
                    return Agility.HowManyPoint();
                case SkillName.Speed:
                    return Speed.HowManyPoint();
                case SkillName.Genius:
                    return Genius.HowManyPoint();
                case SkillName.Diligence:
                    return Diligence.HowManyPoint();
                default:
                    return 0;
            }
        }
        public class Skill
    {
        public int Value;
        public SkillName SkillName;

        public Skill(SkillName name)
        {
            SkillName = name;
        }

        public void AddValue()
        {
            Value++;
        }

        public void AddValue(int count)
        {
            Value += count;
        }
        public void SetValue(int count)
        {
            Value = count;
        }

        public int HowManyPoint()
        {
            return Value;
        }
    }
        public enum SkillName
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
}