﻿using LastBastion.Game.UIControllers;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


namespace LastBastion.Game.Managers
{
    /// <summary>
    /// Component that manages Summary scene behaviours.
    /// </summary>
    public class SummaryManager : MonoBehaviour
    {
        #region Private fields
        [SerializeField] private Button endSceneButton;
        [SerializeField] private Button backToMainMenuButton;
        [SerializeField] private Text timerText;
        [SerializeField] private Text nextLevelText;
        [SerializeField] private AchievementPanelController timeAchievement;
        [SerializeField] private AchievementPanelController runesAchievement;
        [SerializeField] private AchievementPanelController doorsAchievement;
        [SerializeField] private AchievementPanelController lightSwitchAchievement;
        [SerializeField] private int secondsToGo = 120;
        #endregion


        #region MonoBehaviour methods
        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            Assert.IsNotNull(timerText);
            Assert.IsNotNull(nextLevelText);
            Assert.IsNotNull(timeAchievement);
            Assert.IsNotNull(runesAchievement);
            Assert.IsNotNull(doorsAchievement);
            Assert.IsNotNull(lightSwitchAchievement);
        }

        // Use this for initialization
        void Start()
        {
            // update buttons behaviour:
            if (GameManager.instance.DebugMode)
            {
                endSceneButton.onClick.AddListener((UnityEngine.Events.UnityAction)(() => { GameManager.instance.LoadNextLevel(); }));
                endSceneButton.gameObject.SetActive(true);
                backToMainMenuButton.onClick.AddListener(() => { GameManager.instance.BackToMainMenu(); });
                backToMainMenuButton.gameObject.SetActive(true);
            }
            else
            {
                endSceneButton.gameObject.SetActive(false);
                backToMainMenuButton.gameObject.SetActive(false);
            }

            // update achievements data:
            UpdateAchievementsPanels();

            // unlock cursor state after game level:
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // run stopwatch:
            StartCoroutine(Stopwatch());
        }
        #endregion


        #region Public methods
        private void UpdateAchievementsPanels()
        {
            // TEST:
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                                               GameManager.instance.GameTime.Hours,
                                               GameManager.instance.GameTime.Minutes,
                                               GameManager.instance.GameTime.Seconds);
            timeAchievement.UpdateAchievementData("time achik >>", elapsedTime);
            runesAchievement.UpdateAchievementData("runes achik >>", GameManager.instance.CollectedRunes.ToString());
            doorsAchievement.UpdateAchievementData("doors achik >>", GameManager.instance.OpenedDoors.ToString());
            lightSwitchAchievement.UpdateAchievementData("light switch achik >>", GameManager.instance.LightSwitchUses.ToString());
        }

        /// <summary>
        /// Simple coroutine that simulates timer.
        /// </summary>
        /// <returns></returns>
        private IEnumerator Stopwatch()
        {
            int minutes;
            int seconds;
            for (int i = secondsToGo; i >= 0; i--)
            {
                minutes = i / 60;
                seconds = i - (minutes * 60);
                timerText.text = String.Format("{0:00}:{1:00}", minutes, seconds);
                yield return new WaitForSeconds(1.0f);
            }
            nextLevelText.text = "( Loading next scene )";
            timerText.gameObject.SetActive(false);
            // inform that level has ended:
            GameManager.instance.LoadNextLevel();
        }
        #endregion
    }
}