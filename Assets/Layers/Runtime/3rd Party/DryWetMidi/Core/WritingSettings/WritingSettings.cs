﻿using System;
using System.ComponentModel;
using System.Text;
using ABXY.Layers.ThirdParty.Melanchall.DryWetMidi.Common;

namespace ABXY.Layers.ThirdParty.Melanchall.DryWetMidi.Core
{
    /// <summary>
    /// Settings according to which MIDI data should be written.
    /// </summary>
    public class WritingSettings
    {
        #region Fields

        private CompressionPolicy _compressionPolicy = CompressionPolicy.NoCompression;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets compression rules for the writing engine. The default is
        /// <see cref="Core.CompressionPolicy.NoCompression"/>.
        /// </summary>
        /// <remarks>
        /// <para>You can specify <see cref="CompressionPolicy.Default"/> to use basic compression rules.
        /// <see cref="CompressionPolicy"/> is marked with <see cref="FlagsAttribute"/> so you can
        /// combine separate rules as you want.</para>
        /// </remarks>
        /// <exception cref="InvalidEnumArgumentException"><paramref name="value"/> specified an invalid value.</exception>
        public CompressionPolicy CompressionPolicy
        {
            get { return _compressionPolicy; }
            set
            {
                ThrowIfArgument.IsInvalidEnumValue(nameof(value), value);

                _compressionPolicy = value;
            }
        }

        /// <summary>
        /// Gets or sets collection of custom meta events types.
        /// </summary>
        /// <remarks>
        /// <para>Types within this collection must be derived from the <see cref="MetaEvent"/>
        /// class and have parameterless constructor. No exception will be thrown
        /// while writing a MIDI file if some types don't meet these requirements.</para>
        /// </remarks>
        public EventTypesCollection CustomMetaEventTypes { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="Encoding"/> that will be used to write the text of a
        /// text-based meta event. The default is <see cref="Encoding.ASCII"/>.
        /// </summary>
        public Encoding TextEncoding { get; set; } = SmfConstants.DefaultTextEncoding;

        #endregion
    }
}
