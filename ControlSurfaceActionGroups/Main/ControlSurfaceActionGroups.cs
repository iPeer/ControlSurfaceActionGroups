using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlSurfaceActionGroups.Main
{
    class ControlSurfaceActionGroups : PartModule
    {

        public enum Mode
        {
            PITCH_OFF = 0,
            PITCH_ON = 1,
            PITCH_TOGGLE = 2,
            YAW_OFF = 3,
            YAW_ON = 4,
            YAW_TOGGLE = 5,
            ROLL_OFF = 6,
            ROLL_ON = 7,
            ROLL_TOGGLE = 8,
            ALL_OFF = 9,
            ALL_ON = 10,
            ALL_TOGGLE = 11,
            DEPLOY_INVERT = 12
        }

        [KSPAction("Pitch: OFF")]
        public void pitchOFF(KSPActionParam p)
        {
            setControl(Mode.PITCH_OFF, p);
        }

        [KSPAction("Pitch: ON")]
        public void pitchON(KSPActionParam p)
        {
            setControl(Mode.PITCH_ON, p);
        }

        [KSPAction("Pitch: TOGGLE")]
        public void pitchTOGGLE(KSPActionParam p)
        {
            setControl(Mode.PITCH_TOGGLE, p);
        }

        [KSPAction("Yaw: OFF")]
        public void yawOFF(KSPActionParam p)
        {
            setControl(Mode.YAW_OFF, p);
        }

        [KSPAction("Yaw: ON")]
        public void yawON(KSPActionParam p)
        {
            setControl(Mode.YAW_ON, p);
        }

        [KSPAction("Yaw: TOGGLE")]
        public void yawTOGGLE(KSPActionParam p)
        {
            setControl(Mode.YAW_TOGGLE, p);
        }

        [KSPAction("Roll: OFF")]
        public void rollOFF(KSPActionParam p)
        {
            setControl(Mode.ROLL_OFF, p);
        }

        [KSPAction("Roll: ON")]
        public void rollON(KSPActionParam p)
        {
            setControl(Mode.ROLL_ON, p);
        }

        [KSPAction("Roll: TOGGLE")]
        public void rollTOGGLE(KSPActionParam p)
        {
            setControl(Mode.ROLL_TOGGLE, p);
        }

        [KSPAction("All: OFF")]
        public void allOFF(KSPActionParam p)
        {
            setControl(Mode.ALL_OFF, p);
        }

        [KSPAction("All: ON")]
        public void allON(KSPActionParam p)
        {
            setControl(Mode.ALL_ON, p);
        }

        [KSPAction("All: TOGGLE")]
        public void allTOGGLE(KSPActionParam p)
        {
            setControl(Mode.ALL_TOGGLE, p);
        }
        [KSPAction("Invert: TOGGLE")]
        public void invertTOGGLE(KSPActionParam p)
        {
            setControl(Mode.DEPLOY_INVERT, p);
        }

        public void setControl(Mode mode, KSPActionParam p)
        {
            ModuleControlSurface mcs = this.part.Modules.GetModules<ModuleControlSurface>().First();
            if (mcs == null) { return; }

            if (mode == Mode.PITCH_OFF)
                mcs.ignorePitch = true;
            else if (mode == Mode.PITCH_ON)
                mcs.ignorePitch = false;
            else if (mode == Mode.PITCH_TOGGLE)
                mcs.ignorePitch = !mcs.ignorePitch;
            else if (mode == Mode.YAW_OFF)
                mcs.ignoreYaw = true;
            else if (mode == Mode.YAW_ON)
                mcs.ignoreYaw = false;
            else if (mode == Mode.YAW_TOGGLE)
                mcs.ignoreYaw = !mcs.ignoreYaw;
            else if (mode == Mode.ROLL_OFF)
                mcs.ignoreRoll = true;
            else if (mode == Mode.ROLL_ON)
                mcs.ignoreRoll = false;
            else if (mode == Mode.ROLL_TOGGLE)
                mcs.ignoreRoll = !mcs.ignoreRoll;
            else if (mode == Mode.ALL_OFF)
                mcs.ignoreRoll = mcs.ignoreYaw = mcs.ignorePitch = true;
            else if (mode == Mode.ALL_ON)
                mcs.ignoreRoll = mcs.ignoreYaw = mcs.ignorePitch = false;
            else if (mode == Mode.ALL_TOGGLE)
            {
                mcs.ignorePitch = !mcs.ignorePitch;
                mcs.ignoreRoll = !mcs.ignoreRoll;
                mcs.ignoreYaw = !mcs.ignoreYaw;
            }
            else if (mode == Mode.DEPLOY_INVERT)
                mcs.deployInvert = !mcs.deployInvert;
        }

    }
}
