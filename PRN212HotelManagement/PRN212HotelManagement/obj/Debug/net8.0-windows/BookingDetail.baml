   M S B A M L   `   `   `  ����P  LPRN212HotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PRN212HotelManagementPRN212HotelManagement  5   	   )    #PRN212HotelManagement.BookingDetail   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PRN212HotelManagement     5   	     � Title$  Booking Detail��5   	   $	��600��6    $	��900��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Booking Detail��6!   $��24(�67   $
��Bold"�6E   $��Center=�6W   $��10q�6t   
�������6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridBookingDetails��5      $��1��63      AutoGenerateColumns$ False��6@   $��10q�6\      
IsReadOnly$
 True��6h   
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Booking ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	BookingId+6W     5      $ 	User Name��6%   $ * 6U    68   �� *
UserName+6U     5      $ 	Room Name��6%   $ * 6U    68   �� *
RoomName+6U     5      $ Booking Type��6%   $ * 6[    6;   �� *BookingType+6[     5      $ Booking Status��6%   $ * 6_    6=   �� *BookingStatus+6_     5      $ 
Start Date��6%   $ * 6]    69   �� *BookingStartDay+6]     5      $ End Date��6%   $ * 6Y    67   �� *BookingEndDay+6Y     5      $ Total Price��6%   $ * 6Y    6:   �� *
TotalPrice+6Y     5      $ Service Name��6%   $ * 6[    6;   �� *ServiceName+6[     5      $ Service Price��6%   $ * 6]    6<   �� *ServicePrice+6]   5!      �� 5"   
   $��2��6   $��Center=�6"   $��10q�6?   .+�5#      �� -   5        	 ��Name$	 btnBack��5#      $
��Back��6&   $	��100��65   $��40��6A   ���#3AA9AD
�������6u   5$      5%      5'      