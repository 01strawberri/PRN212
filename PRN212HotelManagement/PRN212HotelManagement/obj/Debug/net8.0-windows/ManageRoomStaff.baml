   M S B A M L   `   `   `  ����P  LPRN212HotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PRN212HotelManagementPRN212HotelManagement  5   	   +    %PRN212HotelManagement.ManageRoomStaff   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PRN212HotelManagement     5   	     � Title$  ManageRoomStaff��5   	   $	��700��6!   $	��800��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���#3AA9AD �� Orientation$ 
Horizontal=�67   .+�5      �� -   5         ��Name$ btn_Profile��5      $��Profile��6*   $��91��6<   $��40��6G   $��5q�6S   
������ 
�������$��0q�5       64   �� 5      -   5        $ btn_Bookings��5      $��Bookings��6+   $��92��6>   $��40��6I   $��5q�6U   
������ 
�������$��0q�5       64   �� 5      -   5        $ btn_ManageRoom��5      $��Manage Rooms��6-   $	��124��6D   $��40��6P   
������ 
�������$��0q�5       64   �� 5      -   5        $ btn_ManageUser��5      $	��129��6-   $��40��69   $��5q�6E   
������ 
�������$��0q�5       $��Manage Users��64   6K   �� 5      -   5        $ btn_ManageService��5      $��Manage Services��60   $	��108��6J   $��40��6V   $��5q�6b   
������ 
�������$��0q�5       �� 5      -   5        $ btn_Transaction��5      $��Transaction��6.   $	��100��6D   $��40��6P   $��5q�6\   
������ 
�������$��0q�5        $��Right=�64   �� 5!      -   5        $ 
btn_Logout��5!      $��Logout��6)   $	��100��6:   $��40��6F   $��5q�6R   
������ 
�������$��0q�5"       $��Right=�64   6P   5#      �� 5&   
   ���#a36361$��
0,0,10,476q�6*   $��2��6>   .+�5'      �� $��Manage Rooms��6   $��24(�6,   $
��Bold"�6:   $��10q�6L   $��Center=�6X   
�������6u   5(      �� 5+   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   $��
0,81,0,237q�6X   $��2��6l   .+�5,      �� $ Vertical=�6   $��5q�60   .+�5-      �� $��	Room Name��6   $
��Bold"�6-   $��5q�6?   $��Center=�6J   �� 5.      -   5         ��Name$ txtSearchRoomName��5.      $	��150��65   $��5q�6A   5/      �� 51      $ Vertical=�6   $��5q�60   .+�52      �� $��	Room Type��6   $
��Bold"�6-   $��5q�6?   $��Center=�6J   �� 53      -	   5        $ txtSearchRoomType��53      $	��150��65   $��5q�6A   54      �� 56      $ Vertical=�6   $��5q�60   .+�57      �� $��Room Status��6   $
��Bold"�6/   $��5q�6A   $��Center=�6L   �� 58      -
   5         ��Name$ cmbSearchRoomStatus��58      $	��150��68   $��5q�6D   .@�59      �� $	��All��6#   �� 5:      $��	Available��6#   �� 5;      $��Maintenance��6#   �� 5<      $��Using��6#   5=      5>      �� 5?      $��0,10,0,0q�6   .+�5@      �� -   5        $ 	btnSearch��5@      $��Search��6,   $	��100��6=   $��40��6I   $��5q�6U   ���#3AA9AD
�������6�   5A      5C      &   System.Windows.Controls.DataGrid  5F   
   -   5          Name$ dataGridRooms��5F      $��2��6*      AutoGenerateColumns$ False��67   $��10,163,10,10q�6S      
IsReadOnly$
 True��6i   
�������	   Columns	 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Room ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *RoomId+6Q     5I      $
 	Room Name��6%   $ * 6U    68   �� *
RoomName+6U     5J      $
 	Room Type��6%   $ * 6U    68   �� *
RoomType+6U     5K      $
 Description��6%   $ * 6^    6:   �� *RoomDescription+6^     5L      $
 Status��6%   $
 Auto 6T    65   �� *
RoomStatus+6T     5M      $
 Price Per Hour��6%   $
 Auto 6p    6=   �� * RoomPrices[0].RoomPricePerHour+6p     5N      $
 Price Per Day��6%   $
 Auto 6n    6<   �� *RoomPrices[0].RoomPricePerDay+6n   4  .System.Windows.Controls.DataGridTemplateColumn  5O      $
 Change Status��6)   $
 Auto 6@      CellTemplate 5P      �� 5Q      .R�5R      �� -   5        $	��100��5R   T   .@�5S   "   �� $��	Available��6/   �� 5T   "   $��Maintenance��6/   �� 5U   "   $��Using��6/   5W      5X      5Z      5\      5]      5^      