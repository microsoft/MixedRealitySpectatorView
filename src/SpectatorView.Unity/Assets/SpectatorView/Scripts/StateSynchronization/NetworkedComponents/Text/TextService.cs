﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Microsoft.MixedReality.SpectatorView
{
    internal class TextService : ComponentBroadcasterService<TextService, TextObserver>
    {
        public static readonly ShortID ID = new ShortID("UTX");

        public override ShortID GetID() { return ID; }


        private void Start()
        {
            StateSynchronizationSceneManager.Instance.RegisterService(this, new ComponentBroadcasterDefinition<TextBroadcaster>(typeof(Text)));
        }

        public AssetId GetFontId(Font font)
        {
            var fontAssets = FontAssetCache.Instance;
            if (fontAssets == null)
            {
                return AssetId.Empty;
            }
            else
            {
                return fontAssets.GetAssetId(font);
            }
        }

        public Font GetFont(AssetId assetId)
        {
            var fontAssets = FontAssetCache.Instance;
            if (fontAssets == null)
            {
                return null;
            }
            else
            {
                return fontAssets.GetAsset(assetId);
            }
        }
    }
}
