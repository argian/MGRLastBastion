﻿using LastBastion.Game.ObjectInteraction;
using System.Collections.Generic;
using UnityEngine;


namespace LastBastion.Game.Managers
{
    /// <summary>
    /// Component that manages behaviour of child RuneHolder objects.
    /// </summary>
    public class RunesManager : MonoBehaviour
    {
        #region Private fields
        [SerializeField] private List<RuneHolder> runeHolders;
        private int collectedRunes;
        #endregion


        #region Public fields & properties
        /// <summary>Amount of collected runes.</summary>
        public int CollectedRunes { get { return collectedRunes; } }
        #endregion


        #region MonoBehaviour methods
        // Use this for initialization
        void Start()
        {
            collectedRunes = 0;
            runeHolders.AddRange(GetComponentsInChildren<RuneHolder>());
        }
        #endregion


        #region Public methods
        /// <summary>
        /// Counts each collected rune.
        /// </summary>
        public void CollectRune()
        {
            collectedRunes++;
        }

        /// <summary>
        /// Activates all runes orbs if they are enabled.
        /// </summary>
        public void ActivateOrbs()
        {
            foreach(RuneHolder rune in runeHolders)
            {
                rune.ActivateOrb();
            }
        }
        #endregion
    }
}
