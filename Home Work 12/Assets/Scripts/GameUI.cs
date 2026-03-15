using System;
using UnityEngine;
using UnityEngine.UI;
using DefaultNamespace;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _wordText;
    [SerializeField] private TMP_Text _attemptsText;
    [SerializeField] private Image _win;
    [SerializeField] private Image _lose;
    [SerializeField] private Button _guessLetterButton;
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private Button _menuWin;
    [SerializeField] private Button _restartWin;
    [SerializeField] private Button _changeDifficultyWin;
    [SerializeField] private Button _menuLose;
    [SerializeField] private Button _restartLose;
    [SerializeField] private Button _changeDifficultyLose;
    [SerializeField] private TMP_Text _wrongLetters;

    private void OnEnable()
    {
        _menuWin.onClick.AddListener(OnMenuClick);
        _restartWin.onClick.AddListener(OnRestartGame);
        _changeDifficultyWin.onClick.AddListener(OnChangeDifficulty);
        _menuLose.onClick.AddListener(OnMenuClick);
        _restartLose.onClick.AddListener(OnRestartGame);
        _changeDifficultyLose.onClick.AddListener(OnChangeDifficulty);
    }

    private void OnDisable()
    {
        _menuWin.onClick.RemoveListener(OnMenuClick);
        _restartWin.onClick.RemoveListener(OnRestartGame);
        _changeDifficultyWin.onClick.RemoveListener(OnChangeDifficulty);
        _menuLose.onClick.RemoveListener(OnMenuClick);
        _restartLose.onClick.RemoveListener(OnRestartGame);
        _changeDifficultyLose.onClick.RemoveListener(OnChangeDifficulty);
    }

    private Game _game;

    private void Start()
    {
        _win.gameObject.SetActive(false);
        _lose.gameObject.SetActive(false);
        
        _guessLetterButton.onClick.AddListener(OnGuessLetter);
        
        var difficulty = new Difficulty(GameSession.DifficultyType);
        _game = new Game(difficulty);

        UpdateUI();
    }

    private void OnGuessLetter()
    {
        if (_input.text.Length == 0)
            return;

        char letter = _input.text.ToLower()[0];
        _game.Guess(letter);
        _input.text = "";
        UpdateUI();

        if (_game.IsWin()) 
            _win.gameObject.SetActive(true);

        if (_game.IsLose()) 
            _lose.gameObject.SetActive(true);
        
        if (_game.IsWin() || _game.IsLose())
            return;
    }

    private void UpdateUI()
    {
        _wordText.text = _game.Mask;
        _attemptsText.text = "Attempts: " + _game.AttemptsLeft;
        _wrongLetters.text = "Wrong Letters: " + _game.WrongLetters;
    }

    private void OnMenuClick()
    {
        SceneManager.LoadScene("EntryPoint");
    }

    private void OnRestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void OnChangeDifficulty()
    {
        SceneManager.LoadScene("Play");
    }
}