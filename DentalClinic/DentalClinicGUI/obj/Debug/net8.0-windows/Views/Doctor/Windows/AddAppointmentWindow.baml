   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:DentalClinicGUI.Views.DoctorDentalClinicGUI.Views.Doctor  5   	   ?    9DentalClinicGUI.Views.Doctor.Windows.AddAppointmentWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:DentalClinicGUI.Views.Doctor     5   	   X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  AddAppointmentWindow��5
   	   $	��600��6&   $
��1500��63   $
��1500��6@      AppFontFamily#���   6P   .��5      �   BackgroundColor#���  6    � 	Resources 5   
     CustomCalendarDayButton �� 
TargetType:  4System.Windows.Controls.Primitives.CalendarDayButton # MaterialDesignCalendarDayButton �� BasedOn-  'MaterialDesignThemes.Wpf.CalendarAssist �� Property �� Value  CustomCalendarButton7  1System.Windows.Controls.Primitives.CalendarButton   MaterialDesignCalendarButton��%^  &	       7  &	 �     7  �� 5      "  64   8   .�5      ��  �@ SelectionColor �#B2F39B6Q   �� 5        �@ SelectionForegroundColor
 �   �6[   5      �� 5      "  61   8   .�5      ��  �@ SelectionColor �#B2F39B6Q   �� 5        �@ SelectionForegroundColor
 �   �6[   5      5       � RowDefinitions 5   
   �� 5      $
��0.5* �6   6,   �� 5      $
��0.5* �6   6,   �� 5      $	��100 �6   6+    � ColumnDefinitions 5   
   �� 5       $
��0.5* �6   6.   �� 5!      $
��0.5* �6   6.   �� 5"      $
��Auto �6   6.   .+�5&   
   �� $��0��6   $��0��6$   .��5'      &   System.Windows.Controls.Calendar  $
��Auto��6   $	��200��6%   $��10q�61   $
��Left=�6=     CalendarMainBackgroundColor#���  6X     	TextColor#���  6�    ! CalendarHeaderBackgroundColor   HeaderBackground# �  5(      	   HeaderForeground#	 �  6x   
   CalendarButtonStyle#
 [ 5)         CalendarDayButtonStyle# [ 6S      SelectedDate 5'   �   �� *AppointmentDate+5)   S   5*      �� 5,   
   $��0��6   $��1��6    �� Padding$ 10q�6.   $
��Auto��6;   $��Center=�6I   ._�5-      �� .��5.      $  MaterialDesignThemes.Wpf.Clock  $
��Auto��6(      DisplayAutomation$ CycleWithSeconds=�65      	Is24Hours$
 True��6Z    	 MaterialDesignClock#��[	 6k      Time 6�   �� *AppointmentTime+5/      51      �� 53   
   $��0��6   $��2��6$   .��54      �� $
��Auto��6    #
 AppointmentPatientTitleGroupBox#��� 
 6&   $��10,10,10,10q�6a   $	��Top=�6v     ButtonBackgroundColor.  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background# �  55         
Foreground# �  6g      Mode$ Custom=�6�   .��56      �  57      �� 58      $��50 �6(   66   �� 59      $��50 �6(   66   �� 5:      $��50 �6(   66   �� 5;      $��50 �6(   66   �� 5<      $��50 �6(   66   �� 5=      $��* �6(   65    5@      �� 5A      $	��100 �6+   69   �� 5B      $��* �6+   67   .+�5E      �� $��0��6    $��0��6-   $��ID��6=   $��Right=�6G   $��Center=�6c   $��0,0,10,0q�6~   #���  6�   6�   �� 5F      $��0��6   $��1��6+   $	��200��6f   $
��Left=�6r   $��10,0,0,0q�6�    �� 
IsReadOnly$
 True��6�   #���  5G        StaticUnderlineColor#���  6G     UnderlineColor.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush# �  6|   ��5F   ;   �� *SelectedPatient.PatientId+5G   �   �� 5I      $��1��6    $��0��6-    # AppointmentPatientNameTextBlock#���  6=   $��Right=�6v   $��Center=�6�   $��0,0,10,0q�6�   #���  6�   6�   �� 5J      $��1��6   $��1��6+   $	��200��6f   $
��Left=�6r   $��10,0,0,0q�6�   $
 True��6�   #���  6�   #���  6�   # �  5K      ��5J   ;   �� *SelectedPatient.FirstName+5K   a   �� 5M      $��2��6    $��0��6-    " AppointmentPatientDOBTextBlock#���  6=   $��Right=�6u   $��Center=�6�   $��0,0,10,0q�6�   #���  6�   6�   �� 5N      $��2��6   $��1��6+   $	��200��6h   $
��Left=�6t   $��10,0,0,0q�6�   $
 True��6�   #���  6�   #���  6�   # �  5O      ��5N   ;   �� *SelectedPatient.DateOfBirth+5O   a   �� 5Q      $��3��6    $��0��6-     AppointmentDoctorTextBlock#���  6=   $��Right=�6q   $��Center=�6�   $��0,0,10,0q�6�   #���  6�   6�   �� 5R      $��3��6   $��1��6+   $	��200��6_   $
��Left=�6k   $��10,0,0,0q�6�   $
 True��6�   #���  6�   #���  6�   # �  5S      ��5R   ;   �� *SelectedDoctorName+5S   a   �� 5U      $��4��6    $��0��6-    $  AppointmentPatientPhoneTextBlock#���  6=   $��Right=�6w   $��Center=�6�   $��0,0,10,0q�6�   #���  6�   6�   �� 5V      $��4��6   $��1��6+   $	��200��6h   $
��Left=�6t   $��10,0,0,0q�6�   $
 True��6�   #���  6�   #���  6�   # �  5W      ��5V   ;   �� *SelectedPatient.PhoneNumber+5W   T   5X      5Y      5Z      �� 5^   
   $��1��6   $��0��6    $��Status��60   $
��Auto��6@   $��10,10,10,10q�6N   $	��Top=�6c   # �  5_      # �  6g   $ Custom=�6�   .��5`      �  5a      �� 5b      $��50 �6$   62   �� 5c      $��50 �6$   62    5f      �� 5g      $	��100 �6'   65   �� 5h      $��* �6'   63   .+�5l      	� $��0��6   $��0��6+     SelectedRadioBtnColor#���  6;    ' #AppointmentConfirmedRadioBtnContent#���  6p   #���  6�   $��0,0,10,0q�6�    d� 	IsChecked 6�   �� *IsConfirmed+6  	� 5m      $��0��6   $��1��6+   #���  6;    $  AppointmentMissedRadioBtnContent#���  6p   #���  6�    6�   �� *
IsMissed+6�   	� 5n      $��1��6   $��0��6+   #���  6;    ' #AppointmentCancelledRadioBtnContent#���  6p   #���  6�    6�   �� *IsCancelled+6�   	� 5o      $��1��6   $��1��6+   #���  6;    & "AppointmentFinishedRadioBtnContent#���  6p   #���  6�    6�   �� *
IsFinished+6�   5p      5q      �� 5s   
   $��1��6   $��1��6"   $��Center=�62   $��10q�6O   .+�5t      �� $��Doctor��6   $��Center=�6&   6E   �� 5u      $	��200��6   #���  5v        ComboBoxItemBackgroundColor#���  6@   #���  6{   # �  5w        CustomComboBoxItemStyle#��[ 6h   ��5u   #   �� *DoctorNamesCollection+ �� SelectedValue 6Q   �� *SelectedDoctorName+5y      5z      �� 5|   
   $��2��6   $��2��6   $��	0,0,10,10q�6.   $
��Auto��6A   $��Right=�6N   $��Bottom=�6j   #���  5}      #���  6:   ���#bdc3c7��5|   �   �� *AddAppointmentCommand+��5~      �� 5       �� Orientation$ 
Horizontal=�6   .+�5�        FontAwesome5.ImageAwesome  $��20��6'      Icon$ Regular_CheckCircle=�63     IconForegroundColor   
Foreground# �  6N   $��0,0,10,0q�6�   �� 5�        AddAppointmentButtonText#���  6    6T   5�      5�      &	   System.Windows.Controls.DataGrid	  5�   
   $��1��6   $��2��6    $��10 10 10 10q�60   $
��Auto��6E    	  AutoGenerateColumns$ False��6�    	  
IsReadOnly$
 True��6�     TableBackgroundColor#���  5�        TableBorderBrushColor#���  6?   #���  6u   ��5�   R   �� *PatientsCollection+ �� SelectedItem 6}   �� *SelectedPatient+ � ContextMenu 5�      �� 5�      .@�5�      m� $��View patient��6   67   5�       	  Columns 5�      0
  *System.Windows.Controls.DataGridTextColumn
  5�      ,  &System.Windows.Controls.DataGridColumn    Width5  /System.Windows.Controls.DataGridLengthConverter$
  Auto 6%   1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 62   �� *	PatientId+"   HeaderTemplate" 5�      �� 5�      .R�5�      �� $
��Auto��6)     PatientIdTableHeader#���  66   #���  6d   5�      5�      
  5�      $
  Auto 6%   ! 62   �� *	FirstName+" 5�      �� 5�      .R�5�      �� $
��Auto��6)     PatientFirstNameTableHeader#���  66   #���  6k   5�      5�      
  5�      $
  Auto 6%   ! 62   �� *
LastName+" 5�      �� 5�      .R�5�      �� $
��Auto��6)     PatientLastNameTableHeader#���  66   #���  6j   5�      5�      
  5�      $
  Auto 6%   ! 62   �� *DateOfBirth+" 5�      �� 5�      .R�5�      �� $
��Auto��6)      PatientDOBTableHeader#���   66   #���  6e   5�      5�      
  5�      $
  Auto 6%   ! 62   �� *Gender+" 5�      �� 5�      .R�5�      �� $
��Auto��6)    ! PatientGenderTableHeader#��� ! 66   #���  6h   5�      5�      
  5�      $
  Auto 6%   ! 62   �� *PhoneNumber+" 5�      �� 5�      .R�5�      �� $
��Auto��6)    !" PatientPhoneNumberTableHeader#��� " 66   #���  6m   5�      5�      
  5�      $
  Auto 6%   ! 62   �� *Email+" 5�      �� 5�      .R�5�      �� $
��Auto��6)    # PatientEmailTableHeader#��� # 66   #���  6g   5�      5�      5�      5�      5�      