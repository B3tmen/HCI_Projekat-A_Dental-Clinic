   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:DentalClinicGUI.Views.DoctorDentalClinicGUI.Views.Doctor  5   	   <    6DentalClinicGUI.Views.Doctor.Windows.AddMedicineWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:DentalClinicGUI.Views.Doctor     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  AddMedicineWindow��5	   	   $	��400��6#   $	��600��60    � 
ResizeMode$ NoResize=�6<    � WindowStartupLocation$ CenterScreen=�6R    � Icon$% ../../../Resources/App-logo.png��6w      AppFontFamily#���   5
   	   .��5      �   BackgroundColor#���  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��70 �6   6*   �� 5      $��70 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� $)��#../../../Resources/Pills_bottle.png��6   $	��150��6=   $��0��6J   $��0��6W   6i   �� 5   
   $��0��6   $��1��6    $
��Auto��60     MedicineGroupBoxTitle#���  6>   $��10,10,10,10q�6o   $	��Top=�6�     ButtonBackgroundColor.  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background# �  5        	TextColor   
Foreground# �  6g      Mode$ Custom=�6�   .��5      �� $	��200��65   $
��Left=�6A   #���  5        StaticUnderlineColor#���  6?     UnderlineColor.  (MaterialDesignThemes.Wpf.TextFieldAssist	   UnderlineBrush#	 �  6t   ��5      �� *Medicine.Name+5   �   5      � 5!   
   $��1��6   $��0��6    5"      �� 5#      6%   �� 5$      6%   .+�5'      �� $��0��6   $��0��6%     MedicineDaysOfUse#���  65   $��Right=�6`   $��Center=�6|   $��0,0,10,0q�6�   #���  6�   6�   �� 5(      $��0��6   $��1��6#   $	��100��63   $
��Left=�6c   $��Center=�6~   #���  6�   #���  6�   #	 �  5)      ��5(   ?   �� *Medicine.DaysOfUse+5)   X   5*      � 5-   
   $��2��6   $��0��6    5.      �� 5/      6%   �� 50      6%   .+�53      �� $��0��6   $��0��6%     MedicineUseTimesPerDay#���  65   $��Right=�6e   $��Center=�6�   $��0,0,10,0q�6�   #���  6�   6�   �� 54      $��0��6   $��1��6#   $	��100��63   $
��Left=�6h   $��Center=�6�   #���  6�   #���  6�   #	 �  55      ��54   ?   �� *Medicine.UseTimesPerDay+55   T   56      (  "System.Windows.Controls.DatePicker  58   
   $��3��6   $��0��6"   $	��150��62   $��50��6>   $��Center=�6J   $��10,0,0,0q�6�    &	 "MedicineExpirationDateCalendarHint)  #MaterialDesignThemes.Wpf.HintAssist
   Hint#
 � 	 59       $
  MaterialDesignOutlinedDatePicker#��[
 6d   #	 �  5:      #���  5;      #���  6=      SelectedDate 58   g   �� *Medicine.ExpirationDate+5;   =   �� 5=   
   $��3��6   $��1��6   $��	0,0,10,10q�6.   $
��Auto��6A   $��Right=�6N   $��Bottom=�6j   #���  5>      #���  6:   ���#bdc3c7��5=   �   �� *AddMedicineCommand+��5?      �� 5@        AddMedicineButtonText#���  6   6M   5B      5C      5D      