﻿#pragma checksum "E:\Stage 2 Cert_IV_Programming\Mobile_Application\GitHub\camcan_repository\CamCan\QuestionPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2AEE1BFAD49AC1E5A916C234472C63EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace CamCan {
    
    
    public partial class QuestionPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.MediaElement mediaElement1;
        
        internal System.Windows.Controls.Button answer0;
        
        internal System.Windows.Controls.Button answer1;
        
        internal System.Windows.Controls.Button answer2;
        
        internal System.Windows.Controls.Button answer3;
        
        internal System.Windows.Controls.TextBlock questionText;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/CamCan;component/QuestionPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.mediaElement1 = ((System.Windows.Controls.MediaElement)(this.FindName("mediaElement1")));
            this.answer0 = ((System.Windows.Controls.Button)(this.FindName("answer0")));
            this.answer1 = ((System.Windows.Controls.Button)(this.FindName("answer1")));
            this.answer2 = ((System.Windows.Controls.Button)(this.FindName("answer2")));
            this.answer3 = ((System.Windows.Controls.Button)(this.FindName("answer3")));
            this.questionText = ((System.Windows.Controls.TextBlock)(this.FindName("questionText")));
        }
    }
}
