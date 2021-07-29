﻿using System;
using System.Collections.Generic;
using ABXY.Layers.ThirdParty.Melanchall.DryWetMidi.Core;

namespace ABXY.Layers.ThirdParty.Melanchall.DryWetMidi.Devices
{
    internal sealed class PlaybackEventsComparer : IComparer<PlaybackEvent>
    {
        #region IComparer<PlaybackEvent>

        public int Compare(PlaybackEvent x, PlaybackEvent y)
        {
            var timeDifference = x.RawTime - y.RawTime;
            if (timeDifference != 0)
                return Math.Sign(timeDifference);

            var xChannelEvent = x.Event as ChannelEvent;
            var yChannelEvent = y.Event as ChannelEvent;

            if (xChannelEvent == null || yChannelEvent == null)
                return 0;

            if (!(xChannelEvent is NoteEvent) && yChannelEvent is NoteEvent)
                return -1;

            if (xChannelEvent is NoteEvent && !(yChannelEvent is NoteEvent))
                return 1;

            return 0;
        }

        #endregion
    }
}