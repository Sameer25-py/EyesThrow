using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static Action HitEye;
        public static Action HitDart;
        private       int    _score = 0;


        public GameObject   MainMenu, Instructions, Settings, Ingame, Pause, GameOver;
        public TMP_Text     Score1,   Score2,       Score3;
        public Eye          Eye;
        public DartLauncher DartLauncher;

        private void OnEnable()
        {
            HitEye  += OnEyeHit;
            HitDart += OnHitDart;
        }

        private void OnHitDart()
        {
            GameOver.SetActive(true);
            Eye.ResetRotate();
            DartLauncher.IsGameStarted = false;
            DartLauncher.DestroyAllDarts();
        }

        private void UpdateScore()
        {
            Score1.text = _score.ToString();
            Score2.text = _score.ToString();
            Score3.text = _score.ToString();
        }

        private void OnEyeHit()
        {
            _score += 1;
            UpdateScore();
        }

        public void StartGame()
        {
            _score = 0;
            UpdateScore();
            DartLauncher.SpawnDart();
            MainMenu.SetActive(false);
            Eye.StartRotate();
            DartLauncher.IsGameStarted = true;
        }

        public void ShowSettings()
        {
            MainMenu.SetActive(false);
            Settings.SetActive(true);
        }

        public void ShowInstructions()
        {
            MainMenu.SetActive(false);
            Instructions.SetActive(true);
        }

        public void HideMenus()
        {
            MainMenu.SetActive(true);
            Instructions.SetActive(false);
            Settings.SetActive(false);
        }

        public void PauseGame()
        {
            Pause.SetActive(true);
            Eye.StopRotate();
            DartLauncher.StopCurrentDart();
            DartLauncher.IsGameStarted = false;
        }

        public void ResumeGame()
        {
            Pause.SetActive(false);
            Eye.StartRotate();
            DartLauncher.ResumeLaunch();
            DartLauncher.IsGameStarted = true;
        }

        public void RestartGame()
        {
            Pause.SetActive(false);
            GameOver.SetActive(false);
            Eye.ResetRotate();
            DartLauncher.IsGameStarted = false;
            DartLauncher.DestroyAllDarts();
            StartGame();
        }

        public void GoToHome()
        {
            Pause.SetActive(false);
            GameOver.SetActive(false);
            Eye.ResetRotate();
            DartLauncher.IsGameStarted = false;
            DartLauncher.DestroyAllDarts();
            MainMenu.SetActive(true);
        }
    }
}