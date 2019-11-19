﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Contributed by USYD Team - Hrithvik (Jacob) Sood, John Tran, Tom Derrick, Aydin Ucan, Aayush Jindal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.SpectatorView.ProjectGrandmaster;

namespace Microsoft.MixedReality.SpectatorView.ProjectGrandmaster
{
    public class BoardButtons : MonoBehaviour
    {
        GameObject manager;
        BoardInformation boardInformation;

        void Awake()
        {
            manager = GameObject.Find("GameManager");
            boardInformation = manager.GetComponent<BoardInformation>();
        }

        // Reset button
        public void Reset()
        {
            boardInformation.ResetState();
        }

        public void Undo()
        {
            // Undo to the last move
            boardInformation.UndoState();

            // If playing against a bot, undo again so it's back to your turn
            if (boardInformation.AIEnabled) { boardInformation.UndoState(); }
        }
    }
}