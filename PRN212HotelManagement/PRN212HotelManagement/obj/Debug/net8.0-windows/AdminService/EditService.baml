   M S B A M L   `   `   `  ����  PRN212HotelManagement4    .PRN212HotelManagement.AdminService.EditService   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Edit Service��5   	   $	��400��6   $	��400��6+   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��Type:��6   $��0��6!   $��0��6.   $��Center=�6>   �� 5   
   -   5         ��Name$ ServiceTypeTextBox��5      $��0��6.   $��1��6;   $��5q�6K   �� 5   
   $��Name:��6   $��1��6!   $��0��6.   $��Center=�6>   �� 5   
   -   5        $ ServiceNameTextBox��5      $��1��6.   $��1��6;   $��5q�6K   �� 5   
   $��Description:��6   $��2��6(   $��0��65   $��Center=�6E   �� 5   
   -   5        $ ServiceDescriptionTextBox��5      $��2��65   $��1��6B   $��5q�6R   �� 5   
   $��Price:��6   $��3��6"   $��0��6/   $��Center=�6?   �� 5   
   -   5        $ ServicePriceTextBox��5      $��3��6/   $��1��6=   $��5q�6M   �� 5!   
   $��Status:��6   $��4��6#   $��0��60   $��Center=�6@   �� 5"      -   5         ��Name$ ServiceStatusComboBox��5"      $��4��66   $��1��6C   $��5q�6S   .@�5#      �� $��	Available��6   �� 5$      $��Unavailable��6   5%      �� 5(      -   5        $
��Save��5(      $��5��6$   $��1��61   $��Right=�6A   $��5q�6]   $��80��5)      6   �� 5*      -   5        $��Cancel��5*      $��6��6&   $��1��63   $��Right=�6C   $��5q�6_   $��80��5+      6   5,      5-      