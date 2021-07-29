﻿using System;
using ABXY.Layers.ThirdParty.Melanchall.DryWetMidi.Core;

namespace ABXY.Layers.ThirdParty.Melanchall.DryWetMidi.Devices
{
    /// <summary>
    /// Provides data for the <see cref="InputDevice.EventReceived"/> event.
    /// </summary>
    public sealed class MidiEventReceivedEventArgs : EventArgs
    {
        #region Constructor

        public MidiEventReceivedEventArgs(MidiEvent midiEvent)
        {
            Event = midiEvent;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets MIDI event received by <see cref="InputDevice"/>.
        /// </summary>
        public MidiEvent Event { get; }

        #endregion
    }
}
