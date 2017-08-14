﻿using UnityEngine;
using UnityEngine.Assertions;


namespace LastBastion.Game.Managers
{
    /// <summary>
    /// Component that represents static decals that exist on scene.
    /// </summary>
    public class DecalsStaticManager : MonoBehaviour
    {
        #region Private fields
        [SerializeField] private GameObject decalsLight;
        [SerializeField] private GameObject decalsHard;
        [SerializeField] private bool wasActivated = false;
        #endregion


        #region Public fields & properties
        /// <summary>Has the decals manager been activated?</summary>
        public bool WasActivated
        {
            get { return wasActivated; }
            set { wasActivated = value; }
        }
        #endregion


        #region MonoBehaviour methods
        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            Assert.IsNotNull(decalsLight);
        }

        // Use this for initialization
        void Start()
        {
            if (decalsLight != null) decalsLight.SetActive(false);
            if (decalsHard != null) decalsHard.SetActive(false);
        }
        #endregion


        #region Public methods
        /// <summary>
        /// Activates decals set based on current player's biofeedback state.
        /// </summary>
        public void ActivateDecals()
        {
            if (WasActivated || GameManager.instance.ActiveRoom.GetComponentInChildren<LightManager>().LightsOn) return;

            // activate decals set based on player's biofeedback:
            switch (LevelManager.instance.PlayerBiofeedback.ArousalCurrentState)
            {
                // if player's arousal is high, activate extra decals set:
                case Biofeedback.DataState.High:
                    decalsLight.SetActive(true);
                    if (decalsHard != null) decalsHard.SetActive(true);
                    wasActivated = true;
                    break;

                // activate decals set:
                case Biofeedback.DataState.Medium:
                case Biofeedback.DataState.Low:
                    decalsLight.SetActive(true);
                    wasActivated = true;
                    break;

                default: break;
            }

            // save info about event:
            if (GameManager.instance.AnalyticsEnabled) LevelManager.instance.AddGameEvent(Analytics.EventType.Decals);
        }
        #endregion
    }
}
