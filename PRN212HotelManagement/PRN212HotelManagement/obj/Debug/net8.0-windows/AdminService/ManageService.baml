   M S B A M L   `   `   `  ����P  LPRN212HotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PRN212HotelManagementPRN212HotelManagement  5   	   )    #PRN212HotelManagement.ManageService   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PRN212HotelManagement     5   	     � Title$  ManageService��5   	   $	��450��6   $	��800��6,   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ServicesDataGrid��5
         AutoGenerateColumns$ False��6-      
IsReadOnly$
 True��6I   $��10,10,10,50q�6[      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	ServiceId+6O     5      $
 Type��6%   $	 100 6S    63   �� *ServiceType+6S     5      $
 Name��6%   $	 150 6S    63   �� *ServiceName+6S     5      $ Description��6%   $	 200 6a    6:   �� *ServiceDescription+6a     5      $ Price��6%   $	 100 6U    64   �� *ServicePrice+6U     5      $ Status��6%   $	 100 6W    65   �� *ServiceStatus+6W   5      �� 5   
   -   5        $��Add Service��5      $
��Left=�6'   $��Bottom=�6B   $��
212,0,0,20q�6]   6q   �� 5   
   -   5        $��Edit Service��5      $
��Left=�6(   $��Bottom=�6C   $��
355,0,0,20q�6x   �� 5   
   -   5        $��Delete Service��5      $��Right=�6*   $��Bottom=�6F   $��
0,0,213,20q�6a   6u   5      5      