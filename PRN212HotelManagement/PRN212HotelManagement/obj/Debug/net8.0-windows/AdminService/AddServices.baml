   M S B A M L   `   `   `  ����  PRN212HotelManagement'    !PRN212HotelManagement.AddServices   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add Service��5   	   $	��350��6   $	��400��6*   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��Type:��6   $��0��6!   $��0��6.   $��5q�6>   $��Center=�6I   �� 5   
   -   5         ��Name$ ServiceTypeTextBox��5      $��0��6.   $��1��6;   $��5q�6K   �� 5   
   $��Name:��6   $��1��6!   $��0��6.   $��5q�6>   $��Center=�6I   �� 5   
   -   5        $ ServiceNameTextBox��5      $��1��6.   $��1��6;   $��5q�6K   �� 5   
   $��Description:��6   $��2��6(   $��0��65   $��5q�6E   $��Center=�6P   �� 5   
   -   5        $ ServiceDescriptionTextBox��5      $��2��65   $��1��6B   $��5q�6R   �� 5   
   $��Price:��6   $��3��6"   $��0��6/   $��5q�6?   $��Center=�6J   �� 5   
   -   5        $ ServicePriceTextBox��5      $��3��6/   $��1��6<   $��5q�6L   �� 5    
   $��Status:��6   $��4��6#   $��0��60   $��5q�6@   $��Center=�6K   �� 5!   
   -   5         ��Name$ ServiceStatusComboBox��5!      $��4��62   $��1��6?   $��5q�6O   .@�5"      �� $��	Available��6   �� 5#      $��Unavailable��6   5$      �� 5'   
   -   5        $	��Add��5'      $��5��6   $��2��6,   $��Right=�6@   $��5q�6\   $
��10,5q�6g   5(      5)      5*      