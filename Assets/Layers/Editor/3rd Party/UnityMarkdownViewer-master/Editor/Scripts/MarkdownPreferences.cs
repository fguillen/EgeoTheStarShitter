﻿////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ABXY.Layers.Editor.ThirdParty.Editor.Scripts
{
    public static class Preferences
    {
        private static readonly string KeyJIRA = "MG/MDV/JIRA";
        private static readonly string KeyHTML = "MG/MDV/HTML";

        private static string mJIRA        = string.Empty;
        private static bool   mStripHTML   = true;
        private static bool   mPrefsLoaded = false;

        public static string JIRA      { get { LoadPrefs(); return mJIRA; } }
        public static bool   StripHTML { get { LoadPrefs(); return mStripHTML; } }

        private static void LoadPrefs()
        {
            if( !mPrefsLoaded )
            {
                mJIRA        = EditorPrefs.GetString( KeyJIRA, "" );
                mStripHTML   = EditorPrefs.GetBool( KeyHTML, true );
                mPrefsLoaded = true;
            }
        }

#if UNITY_2019_1_OR_NEWER

        public class MarkownSettings : SettingsProvider
        {
            public MarkownSettings( string path, SettingsScope scopes = SettingsScope.User, IEnumerable<string> keywords = null )
                : base( path, scopes, keywords )
            {
            }

            public override void OnGUI( string searchContext )
            {
                DrawPreferences();
            }
        }

        [SettingsProvider]
        static SettingsProvider MarkdownPreferences()
        {
            return new MarkownSettings( "Preferences/Markdown" );
        }
#else
        [PreferenceItem( "Markdown" )]
#endif
        private static void DrawPreferences()
        {
            LoadPrefs();

            EditorGUI.BeginChangeCheck();

            mJIRA      = EditorGUILayout.TextField( "JIRA URL", mJIRA );
            mStripHTML = EditorGUILayout.Toggle( "Strip HTML", mStripHTML );

            EditorGUI.EndChangeCheck();

            if( GUI.changed )
            {
                EditorPrefs.SetString( KeyJIRA, mJIRA );
                EditorPrefs.SetBool( KeyHTML, mStripHTML );
            }
        }
    }
}