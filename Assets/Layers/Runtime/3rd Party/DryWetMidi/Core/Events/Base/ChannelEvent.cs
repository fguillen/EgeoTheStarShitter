﻿using ABXY.Layers.ThirdParty.Melanchall.DryWetMidi.Common;

namespace ABXY.Layers.ThirdParty.Melanchall.DryWetMidi.Core
{
    /// <summary>
    /// Represents a MIDI file channel event.
    /// </summary>
    public abstract class ChannelEvent : MidiEvent
    {
        #region Fields

        /// <summary>
        /// Parameters of the MIDI channel event.
        /// </summary>
        internal readonly byte[] _parameters;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelEvent"/> with the specified parameters count.
        /// </summary>
        /// <param name="eventType">The type of event.</param>
        /// <param name="parametersCount">Count of the parameters for this channel event.</param>
        protected ChannelEvent(MidiEventType eventType, int parametersCount)
            : base(eventType)
        {
            _parameters = new byte[parametersCount];
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets channel for this event.
        /// </summary>
        public FourBitNumber Channel { get; set; }

        /// <summary>
        /// Gets or sets the parameter's value at the specified index.
        /// </summary>
        /// <param name="index">Index of the parameter.</param>
        /// <returns>Value of parameter at the specified index.</returns>
        protected SevenBitNumber this[int index]
        {
            get { return (SevenBitNumber)_parameters[index]; }
            set { _parameters[index] = value; }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Reads content of a MIDI event.
        /// </summary>
        /// <param name="reader">Reader to read the content with.</param>
        /// <param name="settings">Settings according to which the event's content must be read.</param>
        /// <param name="size">Size of the event's content.</param>
        /// <exception cref="InvalidChannelEventParameterValueException">An invalid value for channel
        /// event's parameter was encountered.</exception>
        internal sealed override void Read(MidiReader reader, ReadingSettings settings, int size)
        {
            for (int i = 0; i < _parameters.Length; i++)
            {
                var parameter = reader.ReadByte();
                if (parameter > SevenBitNumber.MaxValue)
                {
                    switch (settings.InvalidChannelEventParameterValuePolicy)
                    {
                        case InvalidChannelEventParameterValuePolicy.Abort:
                            throw new InvalidChannelEventParameterValueException(GetType(), parameter);
                        case InvalidChannelEventParameterValuePolicy.ReadValid:
                            parameter &= SevenBitNumber.MaxValue;
                            break;
                        case InvalidChannelEventParameterValuePolicy.SnapToLimits:
                            parameter = SevenBitNumber.MaxValue;
                            break;
                    }
                }

                _parameters[i] = parameter;
            }
        }

        /// <summary>
        /// Writes content of a MIDI event.
        /// </summary>
        /// <param name="writer">Writer to write the content with.</param>
        /// <param name="settings">Settings according to which the event's content must be written.</param>
        internal sealed override void Write(MidiWriter writer, WritingSettings settings)
        {
            writer.WriteBytes(_parameters);
        }

        /// <summary>
        /// Gets the size of the content of a MIDI event.
        /// </summary>
        /// <param name="settings">Settings according to which the event's content must be written.</param>
        /// <returns>Size of the event's content.</returns>
        internal sealed override int GetSize(WritingSettings settings)
        {
            return _parameters.Length;
        }

        #endregion
    }
}