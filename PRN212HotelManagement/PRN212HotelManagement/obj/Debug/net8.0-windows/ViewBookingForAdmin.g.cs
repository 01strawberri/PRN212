﻿#pragma checksum "..\..\..\ViewBookingForAdmin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "663DA862672C58D6798E58692597E0B52A6342D7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PRN212HotelManagement;
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
    /// ViewBookingForAdmin
    /// </summary>
    public partial class ViewBookingForAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\ViewBookingForAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Profile;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\ViewBookingForAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Bookings;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\ViewBookingForAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_ManageRoom;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\ViewBookingForAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_ManageUser;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\ViewBookingForAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_ManageService;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\ViewBookingForAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Transaction;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\ViewBookingForAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Logout;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\ViewBookingForAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchStatus;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\ViewBookingForAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\ViewBookingForAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridBookings;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\ViewBookingForAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PRN212HotelManagement;component/viewbookingforadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ViewBookingForAdmin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_Profile = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\ViewBookingForAdmin.xaml"
            this.btn_Profile.Click += new System.Windows.RoutedEventHandler(this.btn_Profile_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_Bookings = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\ViewBookingForAdmin.xaml"
            this.btn_Bookings.Click += new System.Windows.RoutedEventHandler(this.btn_Bookings_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_ManageRoom = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\ViewBookingForAdmin.xaml"
            this.btn_ManageRoom.Click += new System.Windows.RoutedEventHandler(this.btn_ManageRoom_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_ManageUser = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\ViewBookingForAdmin.xaml"
            this.btn_ManageUser.Click += new System.Windows.RoutedEventHandler(this.btn_ManageUser_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_ManageService = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\ViewBookingForAdmin.xaml"
            this.btn_ManageService.Click += new System.Windows.RoutedEventHandler(this.btn_ManageService_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_Transaction = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\ViewBookingForAdmin.xaml"
            this.btn_Transaction.Click += new System.Windows.RoutedEventHandler(this.btn_Transaction_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_Logout = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\ViewBookingForAdmin.xaml"
            this.btn_Logout.Click += new System.Windows.RoutedEventHandler(this.btn_Logout_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtSearchStatus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\ViewBookingForAdmin.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dataGridBookings = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\ViewBookingForAdmin.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

