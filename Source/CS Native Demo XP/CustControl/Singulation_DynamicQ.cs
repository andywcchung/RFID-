using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CSLibrary.Structures;
using CSLibrary.Constants;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class Singulation_DynamicQ : TabPage
    {
        //private DynamicQAdjustParms dynQAdjust = new DynamicQAdjustParms();
        private DynamicQParms dynQ = new DynamicQParms();
        //private DynamicQThresholdParms dynQThreshold = new DynamicQThresholdParms();

        private SingulationAlgorithm current = SingulationAlgorithm.UNKNOWN;

        /*public DynamicQAdjustParms DynamicQAdjust
        {
            get { return dynQAdjust; }
            set { dynQAdjust = value;}
        }*/

        public DynamicQParms DynamicQ
        {
            get { return dynQ; }
            set { dynQ = value; }
        }

        /*public DynamicQThresholdParms DynamicQThreshold
        {
            get { return dynQThreshold; }
            set { dynQThreshold = value; }
        }*/

        public Singulation_DynamicQ(SingulationAlgorithmParms parms, SingulationAlgorithm alg)
        {
            switch (current = alg)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    if (parms.GetType() == typeof(DynamicQParms))
                    {
                        dynQ = parms as DynamicQParms;
                    }
                    else
                    {
                        dynQ.startQValue = 7;
                        dynQ.minQValue = 0;
                        dynQ.maxQValue = 15;
                        dynQ.thresholdMultiplier = 0;
                        dynQ.retryCount = 0;
                        dynQ.toggleTarget = 1;
                    }
                    break;
                /*case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    if (parms.GetType() == typeof(DynamicQAdjustParms))
                    {
                        dynQAdjust = parms as DynamicQAdjustParms;
                    }
                    else
                    {
                        dynQAdjust.startQValue = 7;
                        dynQAdjust.minQValue = 0;
                        dynQAdjust.maxQValue = 15;
                        dynQAdjust.maxQueryRepCount = 0;
                        dynQAdjust.retryCount = 0;
                        dynQAdjust.toggleTarget = 1;
                    }
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    if (parms.GetType() == typeof(DynamicQThresholdParms))
                    {
                        dynQThreshold = parms as DynamicQThresholdParms;
                    }
                    else
                    {
                        dynQThreshold.startQValue = 7;
                        dynQThreshold.minQValue = 0;
                        dynQThreshold.maxQValue = 15;
                        dynQThreshold.thresholdMultiplier = 0;
                        dynQThreshold.retryCount = 0;
                        dynQThreshold.toggleTarget = 1;
                    }
                    break;*/
            }
            InitializeComponent();
            Refresh();
        }

        public Singulation_DynamicQ(uint startq, uint minq, uint maxq, uint retry, uint toggle, uint maxquery)
        {
            InitializeComponent();

            dynQ.startQValue = startq;
            dynQ.minQValue = minq;
            dynQ.maxQValue = maxq;
            dynQ.retryCount = retry;
            dynQ.toggleTarget = toggle;
            dynQ.thresholdMultiplier = maxquery;
        }

        public override void Refresh()
        {
            base.Refresh();
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    nb_startqvalue.Value = dynQ.startQValue;
                    nb_retry.Value = dynQ.retryCount;
                    nb_minqvalue.Value = dynQ.minQValue;
                    nb_maxqvalue.Value = dynQ.maxQValue;
                    nb_thresholdMultiplier.Value = dynQ.thresholdMultiplier;
                    cb_toggle.Checked = dynQ.toggleTarget != 0;
                    break;
                /*case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    nb_startqvalue.Value = dynQAdjust.startQValue;
                    nb_retry.Value = dynQAdjust.retryCount;
                    nb_minqvalue.Value = dynQAdjust.minQValue;
                    nb_maxqvalue.Value = dynQAdjust.maxQValue;
                    nb_MaxQueryRep.Value = dynQAdjust.maxQueryRepCount;
                    cb_toggle.Checked = dynQAdjust.toggleTarget != 0;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    nb_startqvalue.Value = dynQThreshold.startQValue;
                    nb_retry.Value = dynQThreshold.retryCount;
                    nb_minqvalue.Value = dynQThreshold.minQValue;
                    nb_maxqvalue.Value = dynQThreshold.maxQValue;
                    nb_MaxQueryRep.Value = dynQThreshold.thresholdMultiplier;
                    cb_toggle.Checked = dynQThreshold.toggleTarget != 0;
                    label4.Text = "Multiplier";
                    break;*/
            }
        }

        #region Value Changed
        private void nb_startqvalue_ValueChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.startQValue = (uint)nb_startqvalue.Value;
                    break;
                /*case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.startQValue = (uint)nb_startqvalue.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.startQValue = (uint)nb_startqvalue.Value;
                    break;*/
            }

        }

        private void nb_minqvalue_ValueChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.minQValue = (uint)nb_minqvalue.Value;
                    break;
                /*case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.minQValue = (uint)nb_minqvalue.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.minQValue = (uint)nb_minqvalue.Value;
                    break;*/
            }
        }

        private void nb_retry_ValueChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.retryCount = (uint)nb_retry.Value;
                    break;
                /*case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.retryCount = (uint)nb_retry.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.retryCount = (uint)nb_retry.Value;
                    break;*/
            }
        }

        private void nb_maxqvalue_ValueChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.maxQValue = (uint)nb_maxqvalue.Value;
                    break;
                /*case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.maxQValue = (uint)nb_maxqvalue.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.maxQValue = (uint)nb_maxqvalue.Value;
                    break;*/
            }

        }

        private void nb_MaxQueryRep_ValueChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.thresholdMultiplier = (uint)nb_thresholdMultiplier.Value;
                    break;
                /*case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.maxQueryRepCount = (uint)nb_MaxQueryRep.Value;
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.thresholdMultiplier = (uint)nb_MaxQueryRep.Value;
                    break;*/
            }
        }

        private void cb_toggle_CheckedChanged(object sender, EventArgs e)
        {
            switch (current)
            {
                case SingulationAlgorithm.DYNAMICQ:
                    dynQ.toggleTarget = (uint)(cb_toggle.Checked ? 1 : 0);
                    break;
                /*case SingulationAlgorithm.DYNAMICQ_ADJUST:
                    dynQAdjust.toggleTarget = (uint)(cb_toggle.Checked ? 1 : 0);
                    break;
                case SingulationAlgorithm.DYNAMICQ_THRESH:
                    dynQThreshold.toggleTarget = (uint)(cb_toggle.Checked ? 1 : 0);
                    break;*/
            }
        }
        #endregion

        private void label3_ParentChanged(object sender, EventArgs e)
        {

        }

    }
}
