using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace ForceStamina
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]

    public class ForceStamina : BaseUnityPlugin
    {
        private const string PluginGuid = "radsi.ultrakill.forcestamina";
        private const string PluginName = "Force Stamina";
        private const string PluginVersion = "1.0.0.0";

        private ConfigEntry<KeyCode> Toggle;

        GameObject Player;
        bool toggle = false;

        public void Start()
        {
            Toggle = Config.Bind("Binds", "forcestamina toggle", KeyCode.L, "");
        }
        public void Update()
        {
            if (Player != null)
            {
                if (Input.GetKeyDown(Toggle.Value))
                {
                    toggle = !toggle;
                }
                if (toggle)
                {
                    var s = Player.gameObject.GetComponent<NewMovement>();
                    if (s.boostCharge > 100f)
                    {
                        s.boostCharge = 100f;
                    }
                }
            }
            ObjCheck();
        }
        private void ObjCheck()
        {
            if (Player == null)
            {
                Player = GameObject.Find("Player");
            }
        }
    }
}


