   M S B A M L   `   `   `  ����P  LPRN212HotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PRN212HotelManagementPRN212HotelManagement  5   	   !    PRN212HotelManagement.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PRN212HotelManagement     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � AllowsTransparency$
 True��6R   
������  � Title$ Login��5   	   $	��500��6   $	��800��6$   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��1.5* �6   .+�5   
   �� -   5        $-��'pack://application:,,,/Images/close.png��5      $��1��6A    K� ZIndex$ 1��6Q      imgClose#��[  6z   �� 5   
    �� CornerRadius$ 	10 0 0 10��6   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      � 	 � Color$	 #3AA9AD��6#   
 � Offset$
 0Q�63   � 5      $	 #3AA9AD��6#   $
 1Q�63   5      ._�5      � .+�5      �� .+�5      �  � Points �    -1��� ;X�����#4EB1B66:   � 5      ' �    �� �� ���� ��
�����#4EB1B66?   A� 5      $��250 450 0 0q�6   $��40��63   $��40��6>   ���#4EB1B66J   A� 5      $��
50 450 0 0q�6   $��20��62   $��20��6=   ���#4EB1B66I   5      �� 5!      $��Center=�6   .+�5"      �� $��Sign Up��6      	titleText#��[ 6/   �� 5#      $>��8Enter your personal info and create new account to login��6      
normalText#��[ 6`    J� Opacity$	 0.8Q�6�   $��20 30q�6�   �� 5$      -   5        $��Sign Up��5$       
 button#��[ 6/   6O   5%      5&      5'      �� 5)   
   -   5        ���#ffffff$��1��5)   &   $ 	0 10 10 0��66   ._�5*      �� $��Center=�6   .+�5+      �� $��Sign in to Hotel App��6   #��[ 68   ���#3AB19B6[   �� 5,      $��Use your account info: ��6   #��[ 6;   ���#878787$��	0 70 0 15q�6t   �� 5.      $��1q�6   ���#acb0af$
��70 7q�6C   $ 5��6Q   ._�5/      � $	��7 9q�6    50      �� 51      $
��auto �6/   �� 52      $��* �6/   .+�55      �� $0��*pack://application:,,,/Images/Account2.png��6    $��20��6T   �� 56      -   5         ��Name$ textAccount��56   $   $��Username��6[     textHint#��[ 6k   �� 57      -   5         ��Name$ 
txtAccount��57   "     textBox#��[ 6[   6|   58      59      �� 5;      $��1q�6   ���#acb0af$
��70 7q�6C   $ 5��6Q   ._�5<      � $	��7 9q�6    5=      �� 5>      $
��auto �6/   �� 5?      $��* �6/   .+�5B      �� $,��&pack://application:,,,/Images/Lock.png��6    $��20��6P   �� 5C      -   5        $ textPassword��5C   $   $��Password��6]   #��[ 6m   G� 5D      -   5         G�Name$ txtPassword��5D   &   #��[ 6i   6�   5E      5F      �� 5H      -   5        $��Sign In��5H        
mainButton#��[ 6@   5J      5K      5M      5N      