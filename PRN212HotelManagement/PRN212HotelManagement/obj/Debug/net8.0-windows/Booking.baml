   M S B A M L   `   `   `  ����P  LPRN212HotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PRN212HotelManagementPRN212HotelManagement  5   	   #    PRN212HotelManagement.Booking   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PRN212HotelManagement     5   	     � Title$  Booking��5   	   $	��700��6   $	��800��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   ���#3AA9AD �� Orientation$ 
Horizontal=�67   .+�5      �� -   5         ��Name$ btn_Profile��5      $��Profile��6*   $��91��6<   $��40��6G   $��5q�6S   
������ 
�������$��0q�6�   6�   �� 5      -   5        $ 	btn_Rooms��5      $��Rooms��6(   $��92��68   $��40��6C   $��5q�6O   
������ 
�������$��0q�6�   �� 5      -   5        $ btn_Bookings��5      $��Bookings��6+   $��92��6>   $��40��6I   $��5q�6U   
������ 
�������$��0q�6�   6�   �� 5      -   5        $ 
btn_Logout��5      $��Logout��6)   $	��100��6:   $��40��6F   $��5q�6R   
������ 
�������$��0q�6�   $��Right=�6�   6�   5      �� 5    
   $��1��6   ���#a36361.+�5!      �� $��Manage Bookings��6   $��24(�6/   $
��Bold"�6=   $��10q�6O   $��Center=�6[   
�������6x   5"      &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ dataGridBookings��5%      $��3��6-      AutoGenerateColumns$ False��6:   $��10q�6V      
IsReadOnly$
 True��6b   
�������   Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Booking ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6W   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 69   �� *	BookingId+6W     5(      $ 	User Name��6%   $	 * 6Z   
 68   �� *User.UserName+6Z     5)      $ 	Room Name��6%   $	 * 6Z   
 68   �� *Room.RoomName+6Z     5*      $ 
Start Date��6%   $	 * 6]   
 69   �� *BookingStartDay+6]     5+      $ End Date��6%   $	 * 6Y   
 67   �� *BookingEndDay+6Y     5,      $ Status��6%   $
	 Auto 6W   
 65   �� *BookingStatus+6W     5-      $ Total Price��6%   $	 * 6Y   
 6:   �� *
TotalPrice+6Y   5/      �� 52   
   $��4��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�53      �� -   5        $ btnAddBooking��53      $��Add Booking��6,   $	��100��6B   $��5q�6N   
��� � �
�������6   �� 54      -   5        $ btnViewDetail��54      $��View Detail��6,   $	��100��6B   $��5q�6N   
����  �
�������6~   �� 55      -   5        $ btnUpdateBooking��55      $��Update Booking��6/   $	��100��6H   $��5q�6T   
��� ���
�������6�   56      � 59   
   -	   5         �Name$ 	popupGrid��59      $y�	Collapsed=�6"   ���	#80000000$��5��6P   .+�5:      �� 
������� �� CornerRadius$ 10��6(   $	��500��6:   $	��700��6F    �� Padding$ 20q�6S   ._�5;      �  5<      �� 5=      $
��Auto �6(   �� 5>      $��* �6(   �� 5?      $
��Auto �6(   .+�5C      �� $��Add/Edit Booking��6    $��20(�68   $
��Bold"�6F   $��Center=�6X   $��0,0,0,10q�6u   �� 5F      $��10q�6!   .+�5G      �� $��
User Name:��6$   $	��0,5q�66   �� 5H      -
   5         ��Name$ comboUserName��5H   #   $��30��6:   $��0,0,0,10q�6F    �� DisplayMemberPath$ UserName��6X    �� SelectedValuePath$ UserId��6u   �� 5J      $��
Room Name:��6$   $	��0,5q�66   �� 5K      -   5        $ comboRoomName��5K   #   $��30��6:   $��0,0,0,10q�6F   $ RoomName��6X   $ RoomId��6u   6�   �� 5M      $��Booking Type:��6$   $	��0,5q�69   �� 5N      -   5        $ comboBookingType��5N   #   $��30��6=   $��0,0,0,10q�6I   .@�5O      �� $��By Hour��6+   �� 5P      $��By Day��6+   5Q      �� 5S      $��Start Date:��6$   $	��0,5q�67   (  "System.Windows.Controls.DatePicker  5T      -   5          Name$ 	dateStart��5T   %   $��0,0,0,10q�68   6J   �� 5V      $��	End Date:��6$   $	��0,5q�65     5W      -   5        $ dateEnd��5W   %   $��0,0,0,10q�66   6H   �� 5Z      -   5        $ btnAddService��5Z   !   $��Add Service��68   $	��100��6N   $��30��6Z   
����  �
�������$	��0,5q�6�   6�   �� 5]      -   5         ��Name$ listBoxSelectedServices��5]   "   $��50��6C   $��10q�6O    �� SelectionMode$ Multiple=�6[   $ 	ServiceId��6t   ��5^      �� 5_   "   .R�5`   &   �� $ 
Horizontal=�61   .+�5a   *   �� $��5q�6Q   ��64   �� *ServiceName+6Q   �� 5b   *   -   5        $��Remove��5b   1   $��60��6B   $��5q�6M   6X   5c   '   5d   #   5f      �� 5i      $��Total Price:��6$   $	��0,5q�68   �� 5j      -   5         ��Name$ txtTotalPrice��5j   "    �� 
IsReadOnly$
 True��69   $��30��6K   $��0,0,0,10q�6W   5k      � 5n      -   5         �Name$ popupAddService��5n      $��Center=�65    � 	StaysOpen$ False��6H   $	��300��6Z   $	��400��6f   .��5o      �� 
�������
���   �$��1q�6H   $ 10��6\   $ 10q�6n   ._�5p      �� .+�5q   "   �� $��Select Services��6,   $��16(�6C   $
��Bold"�6Q   $��Center=�6c   $��10q�6�   �� 5t   "   -   5        $ listBoxAvailableServices��5t   *   $ ServiceName��5u      $ 	ServiceId��5v      $	��250��5w      $��10q�6#   �� 5z   "   $ 
Horizontal=�6-   $��Center=�6F   $��10q�6c   .+�5{   &   �� -   5        $	��Add��5{   -   $	��100��6;   $��5q�6G   6R   �� 5|   &   -   5        $��Cancel��5|   -   $	��100��6>   $��5q�6J   6U   5}   #   5~      5      5�      �� 5�      $��2��6!   $ 
Horizontal=�6.   $��Center=�6G   $
��0,10q�6d   .+�5�      �� -   5        $ btnSaveBooking��5�   !   $
��Save��69   $	��100��6H   $��30��6T   
��� � �
�������6�   �� 5�      -   5        $ btnCancelBooking��5�   !   $��Cancel��6;   $	��100��6L   $��30��6X   
���  ��
�������6�   5�      5�      5�      5�      5�      5�      