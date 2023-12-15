using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using lethal_company_unlimited_sprint.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lethal_company_unlimited_sprint
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class sprintBase: BaseUnityPlugin
    {
        private const string modGUID = "archa.lethal_company_unlimited_sprint";
        private const string modName = "Unlimited Sprint";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static sprintBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("Unlimited Sprint initialized.");

            harmony.PatchAll(typeof(sprintBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}
