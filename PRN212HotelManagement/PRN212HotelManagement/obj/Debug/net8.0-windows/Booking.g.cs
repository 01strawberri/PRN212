﻿#pragma checksum "..\..\..\Booking.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55F5E66425903196A59686502ABE7B9919972A48"
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
    /// Booking
    /// </summary>
    public partial class Booking : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchUserName;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchRoomName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchBookingStatus;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridBookings;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddBooking;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditBooking;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteBooking;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid popupGrid;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboUserName;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboRoomName;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateStart;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateEnd;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBookingStatus;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBookingType;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTotalPrice;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSaveBooking;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\Booking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelBooking;
        
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
            System.Uri resourceLocater = new System.Uri("/PRN212HotelManagement;component/booking.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Booking.xaml"
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
            this.txtSearchUserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtSearchRoomName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtSearchBookingStatus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.dataGridBookings = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnAddBooking = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\Booking.xaml"
            this.btnAddBooking.Click += new System.Windows.RoutedEventHandler(this.btnAddBooking_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnEditBooking = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\Booking.xaml"
            this.btnEditBooking.Click += new System.Windows.RoutedEventHandler(this.btnEditBooking_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnDeleteBooking = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.popupGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.comboUserName = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.comboRoomName = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.dateStart = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 13:
            this.dateEnd = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 14:
            this.comboBookingStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            this.txtBookingType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.txtTotalPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.btnSaveBooking = ((System.Windows.Controls.Button)(target));
            return;
            case 18:
            this.btnCancelBooking = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

