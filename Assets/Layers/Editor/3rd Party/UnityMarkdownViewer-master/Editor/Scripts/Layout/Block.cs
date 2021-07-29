﻿using System;
using UnityEngine;

namespace ABXY.Layers.Editor.ThirdParty.Editor.Scripts.Layout
{
    public abstract class Block
    {
        public string   ID      = null;
        public Rect     Rect    = new Rect();
        public Block    Parent  = null;
        public float    Indent  = 0.0f;

        public abstract void Arrange( Context context, Vector2 anchor, float maxWidth );
        public abstract void Draw( Context context );

        public Block( float indent )
        {
            Indent = indent;
        }

        public virtual Block Find( string id )
        {
            return id.Equals( ID, StringComparison.Ordinal ) ? this : null;
        }
    }
}
