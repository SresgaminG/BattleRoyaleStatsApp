using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace BattleRoyaleStatsDisplayWinApp
{
    public class ArmaMuteHelper
    {
        #region Variables

        private const string appName = "arma";
        public Keys MuteKey { get; private set; }

        private IKeyboardMouseEvents m_GlobalHook { get; set; }

        #endregion

        #region Public Methods

        public void SetupGlobalKey(Keys keyValue = Keys.F1)
        {
            Unsubscribe();

            this.MuteKey = keyValue;

            Subscribe();
        }

        #endregion

        #region Private Methods

        private void Subscribe()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyUp += GlobalHookKeyUp;
        }

        private void Unsubscribe()
        {
            if (m_GlobalHook == null) return;

            m_GlobalHook.KeyUp -= GlobalHookKeyUp;

            //It is recommened to dispose it
            m_GlobalHook.Dispose();
        }

        private void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == MuteKey && Control.ModifierKeys == Keys.None)
                SresgaminG.Arma3.Mute.MuteUnmute(appName);
        }

        #endregion
    }
}
