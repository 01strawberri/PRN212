   M S B A M L   `   `   `  ����P  LPRN212HotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PRN212HotelManagementPRN212HotelManagement  5   	   /    )PRN212HotelManagement.ViewBookingForAdmin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PRN212HotelManagement     5   	     � Title$  ViewBookingForAdmin��5   	   $	��450��6%   $	��800��62   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   ���#3AA9AD �� Orientation$ 
Horizontal=�67   .+�5      �� -   5         ��Name$ btn_Profile��5      $��Profile��6*   $��91��6<   $��40��6G   $��5q�6S   
������ 
�������$��0q�5   (   6<   �� 5      -   5        $ btn_Bookings��5      $��Bookings��6+   $��92��6>   $��40��6I   $��5q�6U   
������ 
�������$��0q�5   (   6<   �� 5      -   5        $ btn_ManageRoom��5      $��Manage Rooms��6-   $	��124��6D   $��40��6P   
������ 
�������$��0q�5   (   6<   �� 5      -   5        $ btn_ManageUser��5      $	��129��6-   $��40��69   $��5q�6E   
������ 
�������$��0q�5   (   $��Manage Users��6<   6S   �� 5      -   5        $ btn_ManageService��5      $��Manage Services��60   $	��108��6J   $��40��6V   $��5q�6b   
������ 
�������$��0q�5    (   6<   �� 5!      -   5        $ btn_Transaction��5!      $��Transaction��6.   $	��100��6D   $��40��6P   $��5q�6\   
������ 
�������$��0q�5"   (   6<   �� 5#      -   5        $ 
btn_Logout��5#      $��Logout��6)   $	��100��6:   $��40��6F   $��5q�6R   
������ 
�������$��0q�5$   (   $��Right=�6<   6X   5%      �� 5(   
   $��1��6   $ 
Horizontal=�6"   $
��Left=�6;   $��10q�6V   .+�5)      �� $ Vertical=�6   $��5q�60   .+�5*      �� $��Search by Status��6   $
��Bold"�64   $��5q�6F   $��Center=�6Q   �� 5+      -   5         ��Name$ txtSearchStatus��5+      $	��200��63   $��5q�6?   5,      �� 5.      -	   5        $ 	btnSearch��5.      $��Search��6(   $	��100��69   $��40��6E   $��5q�6Q   ���#3AA9AD
�������6�   5/      &   System.Windows.Controls.DataGrid  52   
   -
   5          Name$ dataGridBookings��52      $��2��6-      AutoGenerateColumns$ False��6:   $��10q�6V      
IsReadOnly$
 True��6b   
�������   Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Booking ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	BookingId+6W     55      $	 	User Name��6%   $
 * 6Z    68   �� *User.UserName+6Z     56      $	 	Room Name��6%   $
 * 6Z    68   �� *Room.RoomName+6Z     57      $	 
Start Date��6%   $
 * 6]    69   �� *BookingStartDay+6]     58      $	 End Date��6%   $
 * 6Y    67   �� *BookingEndDay+6Y     59      $	 Status��6%   $

 Auto 6W    65   �� *BookingStatus+6W     5:      $	 Total Price��6%   $
 * 6Y    6:   �� *
TotalPrice+6Y   5<      �� 5?   
   $��3��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5@      �� -   5        $ btnBack��5@      $
��Back��6&   $	��100��65   $��5q�6A   ���#3AA9AD
�������6t   5A      5B      5C      