using System.Collections.Generic;
using DefaultNamespace;

public class Game
{
    private WordBank _wordBank;
    private Word _currentWord;
    private Difficulty _difficulty;

    private List<char> _guessedLetters = new List<char>();
    private List<char> _wrongLetters = new List<char>();

    public int AttemptsLeft { get; private set; }

    public Game(Difficulty difficulty)
    {
        _difficulty = difficulty;
        _wordBank = new WordBank();
        _currentWord = _wordBank.Generate(difficulty);
        AttemptsLeft = difficulty.Attempts;
    }

    public string Mask
    {
        get
        {
            return _currentWord.GetMask(_guessedLetters.ToArray());
        }
    }

    public string WrongLetters
    {
        get
        {
            return string.Join(" ", _wrongLetters.ToArray());
        }
    }

    public bool Guess(char letter)
    {
        if (_guessedLetters.Contains(letter))
            return false;

        _guessedLetters.Add(letter);

        if (!_currentWord.Contains(letter))
        {
            AttemptsLeft--;
            _wrongLetters.Add(letter);
            return false;
        }

        return true;
    }

    public bool IsWin()
    {
        return !Mask.Contains("*");
    }

    public bool IsLose()
    {
        return AttemptsLeft <= 0;
    }
}