   M S B A M L   `   `   `  ����  PRN212HotelManagement-    'PRN212HotelManagement.TransactionWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Transaction History��5   	   $	��700��6%   $	��800��62   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� -   5         ��Name$ txtSearchBookingId��5      $	��200��62   �� 5      -   5         ��Name$ 	btnSearch��5      $��Search��6(   $	��100��69   $��5q�6E   6P   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridTransactions��5         AutoGenerateColumns$ False��61   $��	0,0,0,604q�6M      
IsReadOnly$
 True��6`   
�������$��1��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Transaction ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *TransactionId+6_     5      $	 
Booking ID��6%   $

 Auto 6W    69   �� *	BookingId+6W     5      $	 User ID��6%   $

 Auto 6Q    66   �� *UserId+6Q     5      $	 Event Description��6%   $
 * 6e    6@   �� *EventDescription+6e     5      $	 Transaction Type��6%   $
 * 6c    6?   �� *TransactionType+6c     5      $	 Amount��6%   $
 * 6[    65   �� *TransactionAmount+6[     5      $	 
Event Date��6%   $
 * 6W    69   �� *	EventDate+6W     5      $	 
Start Time��6%   $
 * 6f    69   �� *Booking.BookingStartTime+6f     5      $	 End Time��6%   $
 * 6b    67   �� *Booking.BookingEndTime+6b     5      $	 Status��6%   $
 * 6[    65   �� *TransactionStatus+6[   5!      5#      5$      