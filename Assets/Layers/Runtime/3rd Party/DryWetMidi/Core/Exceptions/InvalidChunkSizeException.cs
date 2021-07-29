﻿using System;

namespace ABXY.Layers.ThirdParty.Melanchall.DryWetMidi.Core
{
    /// <summary>
    /// The exception that is thrown when the actual size of a MIDI file chunk differs from
    /// the one declared in its header.
    /// </summary>
    /// <remarks>
    /// <para>Note that this exception will be thrown only if <see cref="ReadingSettings.InvalidChunkSizePolicy"/>
    /// is set to <see cref="InvalidChunkSizePolicy.Abort"/> for the <see cref="ReadingSettings"/>
    /// used for reading a MIDI file.</para>
    /// </remarks>
    public sealed class InvalidChunkSizeException : MidiException
    {
        #region Constructors

        internal InvalidChunkSizeException(Type chunkType, long expectedSize, long actualSize)
            : base($"Actual size ({actualSize}) of a chunk of {chunkType} type differs from the one declared in the chunk's header ({expectedSize}).")
        {
            ChunkType = chunkType;
            ExpectedSize = expectedSize;
            ActualSize = actualSize;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the type of a chunk caused this exception.
        /// </summary>
        public Type ChunkType { get; }

        /// <summary>
        /// Gets the expected size of a chunk written in its header.
        /// </summary>
        public long ExpectedSize { get; }

        /// <summary>
        /// Gets the actual size of a chunk.
        /// </summary>
        public long ActualSize { get; }

        #endregion
    }
}
