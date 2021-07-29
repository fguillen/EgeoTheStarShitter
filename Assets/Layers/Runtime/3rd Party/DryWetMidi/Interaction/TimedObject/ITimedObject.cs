﻿namespace ABXY.Layers.ThirdParty.Melanchall.DryWetMidi.Interaction
{
    /// <summary>
    /// Represents an object that has start time.
    /// </summary>
    public interface ITimedObject
    {
        #region Properties

        /// <summary>
        /// Gets start time of an object.
        /// </summary>
        long Time { get; }

        #endregion
    }
}
