﻿#pragma checksum "..\..\..\ManageRoomStaff.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F11CC868032BFE4E6B1637DBAF4BF807617104B1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PRN212HotelManagement {
    
    
    /// <summary>
    /// ViewRoom
    /// </summary>
    public partial class ViewRoom : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\ManageRoomStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Profile;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\ManageRoomStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Rooms;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\ManageRoomStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Bookings;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\ManageRoomStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Logout;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\ManageRoomStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchRoomName;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\ManageRoomStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchRoomType;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\ManageRoomStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSearchRoomStatus;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\ManageRoomStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\ManageRoomStaff.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridRooms;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PRN212HotelManagement;component/manageroomstaff.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ManageRoomStaff.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_Profile = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\ManageRoomStaff.xaml"
            this.btn_Profile.Click += new System.Windows.RoutedEventHandler(this.btn_Profile_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_Rooms = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.btn_Bookings = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\ManageRoomStaff.xaml"
            this.btn_Bookings.Click += new System.Windows.RoutedEventHandler(this.btn_Bookings_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Logout = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\ManageRoomStaff.xaml"
            this.btn_Logout.Click += new System.Windows.RoutedEventHandler(this.btn_Logout_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtSearchRoomName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtSearchRoomType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cmbSearchRoomStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\ManageRoomStaff.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dataGridRooms = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
