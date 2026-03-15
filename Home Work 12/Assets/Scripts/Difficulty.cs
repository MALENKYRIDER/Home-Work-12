public class Difficulty
{
    public Difficulty(DifficultyType type)
    {
        Type = type;

        switch (type)
        {
            case DifficultyType.Easy:
                Attempts = 10;
                MinWordLength = 3;
                MaxWordLength = 5;
                break;
            case DifficultyType.Normal:
                Attempts = 8;
                MinWordLength = 4;
                MaxWordLength = 6;
                break;
            case DifficultyType.Hard:
                Attempts = 6;
                MinWordLength = 6;
                MaxWordLength = 10;
                break;
        }
    }
        
    public DifficultyType Type { get; }
    public int Attempts { get; private set; }
    public int MinWordLength { get; private set; }
    public int MaxWordLength { get; private set; }

    public override string ToString() => Type.ToString();
}
    
public enum DifficultyType
{
    Easy,
    Normal,
    Hard
}