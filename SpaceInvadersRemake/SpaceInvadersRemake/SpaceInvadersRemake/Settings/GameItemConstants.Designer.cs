﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpaceInvadersRemake.Settings {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class GameItemConstants : global::System.Configuration.ApplicationSettingsBase {
        
        private static GameItemConstants defaultInstance = ((GameItemConstants)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new GameItemConstants())));
        
        public static GameItemConstants Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public float AlienShootingFrequency {
            get {
                return ((float)(this["AlienShootingFrequency"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.5, 0.5")]
        public global::Microsoft.Xna.Framework.Vector2 AlienVelocityIncrease {
            get {
                return ((global::Microsoft.Xna.Framework.Vector2)(this["AlienVelocityIncrease"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int PlayerHitpoints {
            get {
                return ((int)(this["PlayerHitpoints"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20, 20")]
        public global::Microsoft.Xna.Framework.Vector2 PlayerVelocity {
            get {
                return ((global::Microsoft.Xna.Framework.Vector2)(this["PlayerVelocity"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int PlayerLives {
            get {
                return ((int)(this["PlayerLives"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.Xna.Framework.Vector2 Shieldpos1 {
            get {
                return ((global::Microsoft.Xna.Framework.Vector2)(this["Shieldpos1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-50, -40")]
        public global::Microsoft.Xna.Framework.Vector2 Shieldpos2 {
            get {
                return ((global::Microsoft.Xna.Framework.Vector2)(this["Shieldpos2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, -40")]
        public global::Microsoft.Xna.Framework.Vector2 Shieldpos3 {
            get {
                return ((global::Microsoft.Xna.Framework.Vector2)(this["Shieldpos3"]));
            }
        }
    }
}