﻿using UnityEngine;
using UnityEngine.UI;


namespace LastBastion.Game.Managers
{
    /// <summary>
    /// Component that manages Summary scene behaviours.
    /// </summary>
    public class SummaryPreManager : MonoBehaviour
    {

        #region Private fields
        [SerializeField] private Button endSceneButton;
        [SerializeField] private Button backToMainMenuButton;
        #endregion


        #region MonoBehaviour methods
        // Use this for initialization
        void Start()
        {
            endSceneButton.onClick.AddListener((UnityEngine.Events.UnityAction)(() => { GameManager.instance.LoadNextLevel(); }));
            backToMainMenuButton.onClick.AddListener(() => { GameManager.instance.BackToMainMenu(); });
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion
    }
}