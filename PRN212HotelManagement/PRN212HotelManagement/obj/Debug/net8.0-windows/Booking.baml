   M S B A M L   `   `   `  ����P  LPRN212HotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PRN212HotelManagementPRN212HotelManagement  5   	   #    PRN212HotelManagement.Booking   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PRN212HotelManagement     5   	     � Title$  Booking��5   	   $	��500��6   $	��800��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� ���#3AA9AD.+�5      �� $��Manage Bookings��6   $��24(�6/   $
��Bold"�6=   $��10q�6O   $��Center=�6[   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5      �� $ Vertical=�6   $��5q�60   .+�5      �� $��	User Name��6   $
��Bold"�6-   $��5q�6?   $��Center=�6J   �� 5      -   5         ��Name$ txtSearchUserName��5      $	��150��65   $��5q�6A   5      �� 5!      $ Vertical=�6   $��5q�60   .+�5"      �� $��	Room Name��6   $
��Bold"�6-   $��5q�6?   $��Center=�6J   �� 5#      -   5        $ txtSearchRoomName��5#      $	��150��65   $��5q�6A   5$      �� 5&      $ Vertical=�6   $��5q�60   .+�5'      �� $��Booking Status��6   $
��Bold"�62   $��5q�6D   $��Center=�6O   �� 5(      -   5        $ txtSearchBookingStatus��5(      $	��150��6:   $��5q�6F   5)      �� 5+      -   5         ��Name$ 	btnSearch��5+      $��Search��6(   $	��100��69   $��40��6E   $��5q�6Q   ���#3AA9AD
�������6q   5,      &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ dataGridBookings��5/      $��2��6-      AutoGenerateColumns$ False��6:   $��10q�6V      
IsReadOnly$
 True��6b   
�������   Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Booking ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	BookingId+6W     52      $	 	User Name��6%   $
 * 6Z    68   �� *User.UserName+6Z     53      $	 	Room Name��6%   $
 * 6Z    68   �� *Room.RoomName+6Z     54      $	 
Start Date��6%   $
 * 6]    69   �� *BookingStartDay+6]     55      $	 End Date��6%   $
 * 6Y    67   �� *BookingEndDay+6Y     56      $	 Status��6%   $

 Auto 6W    65   �� *BookingStatus+6W     57      $	 Total Price��6%   $
 * 6Y    6:   �� *
TotalPrice+6Y   59      �� 5<   
   $��3��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5=      �� -   5        $ btnAddBooking��5=      $��Add Booking��6,   $	��100��6B   $��5q�6N   
��� � �
�������6   �� 5>      -   5        $ btnEditBooking��5>      $��Edit Booking��6-   $	��100��6D   $��5q�6P   ���#3AA9AD
�������6�   �� 5?      -   5        $ btnDeleteBooking��5?      $��Delete Booking��6/   $	��100��6H   $��5q�6T   
���  ��
�������6p   5@      � 5C   
   -	   5         �Name$ 	popupGrid��5C      $y�	Collapsed=�6"   ���	#80000000$��4��6P   .+�5D      �� 
������� �� Padding$ 20q�6(   $	��100q�65   ._�5E      �  5F      �� 5G      $
��Auto �6(   �� 5H      $
��Auto �6(   �� 5I      $
��Auto �6(   �� 5J      $
��Auto �6(   �� 5K      $
��Auto �6(   �� 5L      $
��Auto �6(   �� 5M      $��* �6(   .+�5Q      �� $��
User Name:��6    $��0��62   $��5q�6?   �� 5R      -
   5         ��Name$ comboUserName��5R      $��0��66   $��5q�6C   $	��300��6N   5T      �� 5W      $��
Room Name:��6    $��1��62   $��5q�6?   �� 5X      -   5        $ comboRoomName��5X      $��1��66   $��5q�6C   $	��300��6N   5Z      �� 5]      $��Start Date:��6    $��2��63   $��5q�6@   (  "System.Windows.Controls.DatePicker  5^      -   5          Name$ 	dateStart��5^   !   $��2��64   $��5q�6A   $	��300��6L   �� 5a      $��	End Date:��6    $��3��61   $��5q�6>     5b      -   5        $ dateEnd��5b   !   $��3��62   $��5q�6?   $	��300��6J   �� 5e      $��Booking Status:��6    $��4��67   $��5q�6D   �� 5f      -   5        $ comboBookingStatus��5f      $��4��6;   $��5q�6H   $	��300��6S   .@�5g      �� $��Pending��6'   �� 5h      $��	Confirmed��6'   �� 5i      $��	Completed��6'   �� 5j      $��Canceled��6'   5k      �� 5n      $��Booking Type:��6    $��5��65   $��5q�6B   �� 5o      -   5        $ txtBookingType��5o      $��5��66   $��5q�6C   $	��300��6N   �� 5r      $��Total Price:��6    $��6��64   $��5q�6A   �� 5s      -   5        $ txtTotalPrice��5s      $��6��65   $��5q�6B   $	��300��6M   �� 5v      $��7��6!   $ 
Horizontal=�6.   $��Center=�6G   $��10q�6d   .+�5w      �� -   5        $ btnSaveBooking��5w   !   $
��Save��69   $	��100��6H   $��5q�6T   ���#3AA9AD
�������6t   �� 5x      -   5        $ btnCancelBooking��5x   !   $��Cancel��6;   $	��100��6L   $��5q�6X   ���#3AA9AD
�������6x   5y      5z      5{      5|      5}      5~      