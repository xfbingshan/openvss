// jqfn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zfmg	
// bczc	 By downloading, copying, installing or using the software you agree to this license.
// gpwd	 If you do not agree to this license, do not download, install,
// dhzb	 copy or use the software.
// gxyc	
// dkjs	                          License Agreement
// vktl	         For OpenVss - Open Source Video Surveillance System
// ubgh	
// ydnj	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// owpt	
// xutw	Third party copyrights are property of their respective owners.
// ptxm	
// zzcl	Redistribution and use in source and binary forms, with or without modification,
// scjo	are permitted provided that the following conditions are met:
// wtlr	
// iohe	  * Redistribution's of source code must retain the above copyright notice,
// ioez	    this list of conditions and the following disclaimer.
// tqnj	
// heei	  * Redistribution's in binary form must reproduce the above copyright notice,
// rmcc	    this list of conditions and the following disclaimer in the documentation
// mglv	    and/or other materials provided with the distribution.
// zvpv	
// tymu	  * Neither the name of the copyright holders nor the names of its contributors 
// lxkj	    may not be used to endorse or promote products derived from this software 
// monb	    without specific prior written permission.
// oxsj	
// msen	This software is provided by the copyright holders and contributors "as is" and
// ybxj	any express or implied warranties, including, but not limited to, the implied
// qjec	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cmen	In no event shall the Prince of Songkla University or contributors be liable 
// yjgv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dsyj	(including, but not limited to, procurement of substitute goods or services;
// uuwc	loss of use, data, or profits; or business interruption) however caused
// zbop	and on any theory of liability, whether in contract, strict liability,
// ocjg	or tort (including negligence or otherwise) arising in any way out of
// qcxr	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.EllipseDetection
{
    public partial class VsEllipseDetectionSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsEllipseDetectionSetupPage()
        {
            InitializeComponent();
        }

        #region VsICoreAnalyzerPage Members

        bool VsICoreAnalyzerPage.Apply()
        {
            return true;
        }

        bool VsICoreAnalyzerPage.Completed
        {
            get { return completed; }
        }

        void VsICoreAnalyzerPage.Display()
        {
            this.trackBar1.Focus();
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerPage.GetConfiguration()
        {
            VsEllipseDetectionConfiguration cfg = new VsEllipseDetectionConfiguration();

            cfg.Threshold = this.trackBar1.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsEllipseDetectionConfiguration cfg = (VsEllipseDetectionConfiguration)config;

            if (cfg != null)
            {
                this.trackBar1.Value = cfg.Threshold;
            }
        }

       #endregion

        // Update state
        private void UpdateState()
        {
            completed = true;

            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateState();
        }
    }
}