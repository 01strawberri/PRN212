   M S B A M L   `   `   `  ����P  LPRN212HotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PRN212HotelManagementPRN212HotelManagement  5   	   $    PRN212HotelManagement.AdminWPF   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PRN212HotelManagement     5   	     � Title$  Admin Dashboard��5   	   $	��450��6!   $
��1000��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���#3AA9AD �� Orientation$ 
Horizontal=�67   .+�5      �� -   5         ��Name$ btn_Profile��5      $��Profile��6*   $��91��6<   $��40��6G   $��5q�6S   
������ 
�������$��0q�5   (   6<   �� 5      -   5        $ btn_Bookings��5      $��Bookings��6+   $��92��6>   $��40��6I   $��5q�6U   
������ 
�������$��0q�5   (   �� 5      -   5        $ btn_ManageRoom��5      $��Manage Room��6-   $	��124��6C   $��40��6O   
������ 
�������$��0q�5   (   6<   �� 5      -   5        $ btn_ManageUser��5      $	��129��6-   $��40��69   $��5q�6E   
������ 
�������$��0q�5   (   $��Manage Users��6<   6S   �� 5      -   5        $ btn_ManageService��5      $��Manage Services��60   $	��108��6J   $��40��6V   $��5q�6b   
������ 
�������$��0q�5   (   �� 5      -   5        $ btn_Transaction��5      $��Transaction��6.   $	��100��6D   $��40��6P   $��5q�6\   
������ 
�������$��0q�5   (   $��Right=�6<   �� 5      -   5        $ 
btn_Logout��5      $��Logout��6)   $	��100��6:   $��40��6F   $��5q�6R   
������ 
�������$��0q�5   (   $��Right=�6<   6X   5      � 5!   
   $��1��6   $��22,43,18,93q�6   
������� � ColumnDefinitions 5"      �� 5#      $	��200 �6#   �� 5$      $��* �6#   .+�5(      �� $��0��6   $��10q�6)   .+�5)      �� $	��150��6   $	��150��6%    �� CornerRadius$ 75��62   ._�5*      �� $��/Images/profile.png��6   5+      �� 5,      $��Admin Profile��6   $��20(�5-      $
��Bold"�5.      $��Center=�5/      $��0,0,0,10q�50      51      � 54      $��1��6   $��20,10q�6#    55      �� 56      $
��Auto �6$   �� 57      $
��Auto �6$   �� 58      $
��Auto �6$   �� 59      $
��Auto �6$    5;      �� 5<      $	��120 �6'   �� 5=      $��* �6'   .+�5A      �� $��0��6   $��2��6&   ���#f5f5f5$	��0,5q�5C      $ 5��5D      ._�5E      � $
��10,8q�6    5F      �� 5G      $	��120 �6/   �� 5H      $��* �6/   .+�5J      �� $��	Username:��6$   $��SemiBold"�5K   $   $��Center=�5L   $   �� 5M      -   5         ��Name$ txtUsername��5M   $   $��1��5N   $   $��Center=�5O   $   5P      5Q      �� 5T      $��1��6   $��2��6&   ���#f5f5f5$	��0,5q�5V      $ 5��5W      ._�5X      � $
��10,8q�6    5Y      �� 5Z      $	��120 �6/   �� 5[      $��* �6/   .+�5]      �� $��	Password:��6$   $��SemiBold"�5^   $   $��Center=�5_   $   �� 5`      -	   5        $ txtPassword��5`   $   $��1��5a   $   $��********��5b   $   $��Center=�5c   $   �� 5d      -
   5        $��1��5d   !   $��Change Password��5e   !   ���#3AA9AD
�������$
��Left=�5h   !   $��269,-6,0,-7q�5i   !   $	��111��5j   !   6-   5k      5l      �� 5o      $��3��6   $��2��6&   ���#f5f5f5$��0,0,0,16q�5q      $ 5��5r      ._�5s      � $
��10,8q�6    5t      �� 5u      $	��120 �6/   �� 5v      $��* �6/   .+�5x      �� $��Email:��6$   $��SemiBold"�5y   $   $��Center=�5z   $   �� 5{      -   5        $ txtEmail��5{   $   $��1��5|   $   $��Center=�5}   $   �� 5~      -   5        $ btn_ChangeEmail��5~   !   $��1��5   !   $��Update Email��5�   !   $
��Left=�5�   !   $��	300,1,0,0q�5�   !   $��80��5�   !   5�      5�      �� 5�      $��2��6   $��2��6&   ���#f5f5f5$	��0,5q�5�      $ 5��5�      ._�5�      � $
��10,8q�6    5�      �� 5�      $	��120 �6/   �� 5�      $��* �6/   .+�5�      �� $��Phone:��6$   $��SemiBold"�5�   $   $��Center=�5�   $   �� 5�      -   5        $ txtPhone��5�   $   $��1��5�   $   $��Center=�5�   $   �� 5�      -   5        $ btn_ChangePhone��5�   !   $��1��6:   $��Update PhoneNumber��6J   $
��Left=�6g   $��	254,0,0,0q�6�   $��30��6�   $��Center=�6�   $	��126��6�   5�      5�      �� 5�      $��3��6   $��2��6&   ���#f5f5f5$��
0,47,0,-37q�5�      $ 5��5�      ._�5�      � $
��10,8q�6    5�      �� 5�      $	��2.5 �6/   �� 5�      $	��7.5 �6/   �� 5�      $	��110 �6/   �� 5�      $��* �6/   .+�5�      �� $��Role:��6$   $��SemiBold"�5�   $   $��Center=�5�   $   $
��Left=�6?   $	��120��6Z   $��3��6f   �� 5�      -   5        $ txtRole��5�   $   $��3��5�   $   $	��Top=�5�   $   $��0,16,0,0q�6<   5�      5�      5�      5�      5�      5�      