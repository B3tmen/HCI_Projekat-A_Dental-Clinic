   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DentalClinicGUI.Views.Doctor.Pages"DentalClinicGUI.Views.Doctor.Pages  5      9    3DentalClinicGUI.Views.Doctor.Pages.AppointmentsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      <local0clr-namespace:DentalClinicGUI.Views.Doctor.Pages  5        N� Title$  AppointmentsPage��5         AppFontFamily N� 
FontFamily# �   6    .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"     BackgroundColor#���  6;   $��	10,10,0,0q�6j   $
��Auto��6}   .+�5        FontAwesome5.ImageAwesome  $��15��6      Icon$ Solid_Search=�6+      
Foreground �#2980b9$��10,0,0,0q�6T   �� 5      $	��200��6   $
��Left=�6"   $��10,0,0,0q�6=     SearchPlaceholderText)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6O     	TextColor#���  5        StaticUnderlineColor#���  6?     UnderlineColor.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush# �  6t   ��5   �   �� *
SearchText+	 �� UpdateSourceTrigger$	 PropertyChanged=�5   �   5      �� 5   
   $��0��6   $��1��6"   $��	10,0,10,0q�62   $ 
Horizontal=�6E   .+�5         $��15��6   $ Regular_CalendarAlt=�6+    �#2980b9$��10,0,0,0q�6[   �� 5!      $
��Auto��6     TotalAppointmentsTextBlock#���  6&   $��Center=�6Z   $��10,0,0,0q�6u   #���  6�   �� 5"      $
��Auto��6   $��Center=�6N   $��10,0,0,0q�6i   #���  6{   ��6&   �� *AppointmentsTodayCount+6{   5#      �� 5%   
   $ 
Horizontal=�6   $��0��6.   $��2��6;   $��Right=�6K   .+�5&      �� $��0,0,10,0q�6   $
��Auto��6'   $��Right=�64   #���  5'        ButtonBackgroundColor#���  6:   ���#bdc3c7��5&   P   �� *RefreshCommand+��5(      �� 5)      $ 
Horizontal=�6!   .+�5*        $��20��6+   $��0,0,10,0q�67   $ 
Solid_Sync=�6I     IconForegroundColor# �  6[   �� 5+       	 RefreshButtonText#��� 	 6$   6R   5,      5.      �� 50      $��0,0,10,0q�6   $
��Auto��6'   $��Right=�64   #���  51   	   #���  62   ���#bdc3c7��50   P   �� *AddAppointmentCommand+��52      �� 53      $ 
Horizontal=�6!   .+�54        $��20��6+   $��0,0,10,0q�67   $ Solid_UserPlus=�6I   # �  6_   �� 55       
 AddAppointmentButtonText#��� 
 6$   6Y   56      58      59      &   System.Windows.Controls.DataGrid  5>   
   $��1��6   $��3��6    $��10 10 10 10q�64   $
��Auto��6I   
   AutoGenerateColumns$
 False��6�      
IsReadOnly$
 True��6�     TableBackgroundColor#���  5?        TableBorderBrushColor#���  6G   #���  6}   ��5>   V   �� *AppointmentsCollection+ �� SelectedItem 6�   �� *SelectedAppointment+ � 	Resources 5A      )  #System.Windows.Controls.DataGridRow �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  TableRowHoverColor��%�   '        �� 5C      "  6   .�5D      ��  � ��# �  63   �� 5F       � ��# �  63    5H      P� 5J       �@ 
IsSelected$
 True��68   . �5K      ��  � ��# �  6;   5M      5O      5P       � ContextMenu 5U      �� 5V      .@�5W      m� $
��Test��6   6/   5X         Columns 5i      0  *System.Windows.Controls.DataGridTextColumn  5j      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 62   �� *AppointmentId+   HeaderTemplate 5k      �� 5l      .R�5m      �� $
��Auto��6)     AppointmentIdTableHeader#���  66   #���  6h   5n      5p        5r      $
 Auto 6%    62   �� *	PatientId+ 5s      �� 5t      .R�5u      �� $
��Auto��6)     PatientIdTableHeader#���  66   #���  6d   5v      5x        5z      $
 Auto 6%    62   �� *
DoctorName+ 5{      �� 5|      .R�5}      �� $
��Auto��6)    $  AppointmentDoctorNameTableHeader#���  66   #���  6p   5~      5�        5�      $
 Auto 6%    62   �� *	FirstName+ 5�      �� 5�      .R�5�      �� $
��Auto��6)     PatientFirstNameTableHeader#���  66   #���  6k   5�      5�        5�      $
 Auto 6%    62   �� *
LastName+ 5�      �� 5�      .R�5�      �� $
��Auto��6)     PatientLastNameTableHeader#���  66   #���  6j   5�      5�        5�      $
 Auto 6%    62   �� *DateOfBirth+ 5�      �� 5�      .R�5�      �� $
��Auto��6)     PatientDOBTableHeader#���  66   #���  6e   5�      5�        5�      $
 Auto 6%    62   �� *Gender+ 5�      �� 5�      .R�5�      �� $
��Auto��6)     PatientGenderTableHeader#���  66   #���  6h   5�      5�        5�      $
 Auto 6%    62   �� *PhoneNumber+ 5�      �� 5�      .R�5�      �� $
��Auto��6)    ! PatientPhoneNumberTableHeader#���  66   #���  6m   5�      5�        5�      $
 Auto 6%    62   �� *Email+ 5�      �� 5�      .R�5�      �� $
��Auto��6)     PatientEmailTableHeader#���  66   #���  6g   5�      5�        5�      $
 Auto 6%    62   �� *AppointmentStatus+ 5�      �� 5�      .R�5�      �� $
��Auto��6)      AppointmentStatusTableHeader#���  66   #���  6l   5�      5�        5�      $
 Auto 6%    62   �� *ReservationTime+ 5�      �� 5�      .R�5�      �� $
��Auto��6)    % !AppointmentReservationTableHeader#���  66   #���  6q   5�      5�      5�      5�      5�      