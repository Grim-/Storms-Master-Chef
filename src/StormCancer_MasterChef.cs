using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutwardModTemplate
{
    /* ~~~ Initial Setup ~~~
     * 
     * 1. Double click on "Properties" in the Solution Explorer panel to the left
     * 2. Click on the "Application" tab
     * 3. Change your "Assembly Name" and "Default Namespace" to something unique for your mod.
     * 4. Right click the namespace "OutwardModTemplate" above and rename it to what you chose for your Namespace.
     * 5. Right click "MyMod" below and rename it, generally you use what you chose for your Assembly Name.
     * 6. Read the rest of the comments in this file and make changes as needed.
     */

    [BepInPlugin(GUID, NAME, VERSION)]
    public class StormCancer_MasterChef : BaseUnityPlugin
    {
        // Choose a GUID for your project. Change "myname" and "mymod".
        public const string GUID = "stormcancer.epicurean";
        // Choose a NAME for your project, generally the same as your Assembly Name.
        public const string NAME = "StormCancer-MasterChef";
        // Increment the VERSION when you release a new version of your mod.
        public const string VERSION = "1.0.0";

        // For accessing your BepInEx Logger from outside of this class (MyMod.Log)
        internal static ManualLogSource Log;

        // If you need settings, define them like so:
        public static ConfigEntry<bool> ExampleConfig;

        // Awake is called when your plugin is created. Use this to set up your mod.
        internal void Awake()
        {
            Log = this.Logger;
            Log.LogMessage($"Hello world from {NAME} {VERSION}!");

            new Harmony(GUID).PatchAll();
        }
    }


}
