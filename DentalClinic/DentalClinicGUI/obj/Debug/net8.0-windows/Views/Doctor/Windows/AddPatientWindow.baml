   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:DentalClinicGUI.Views.DoctorDentalClinicGUI.Views.Doctor  5   	   ;    5DentalClinicGUI.Views.Doctor.Windows.AddPatientWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:DentalClinicGUI.Views.Doctor     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  AddPatientWindow��5	   	   $	��450��6"   $	��700��6/   $
��1000��6;   $	��600��6K    � WindowStartupLocation$ CenterScreen=�6[    � Icon$% ../../../Resources/App-logo.png��6�      AppFontFamily#���   5
   	   .��5      �   BackgroundColor#���  6    � RowDefinitions 5   
   �� 5      $��70 �6   6*   �� 5      $��70 �6   6*   �� 5      $��70 �6   6*   �� 5      $��70 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   6.   �� 5      $
��0.5* �6   6.   .+�5   
   �� $��0��6   $��0��6   $��ID: ??��6/   $	��140��6>   $��Center=�6J   $
��Left=�6e   $��10,0,0,0q�6�     UnderlineColor.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush# �  5        	TextColor#���  5        StaticUnderlineColor#���  6;    % !MaterialDesignFloatingHintTextBox#��[ 5       �� 
IsReadOnly$
 True��6M   �� 5   
   $��1��6   $��0��6   $	��200��6/   $��Center=�6;   $
��Left=�6V   $��10,0,0,0q�6�     PatientFirstNameTableHeader)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5      # �  6a   #���  5      #���  6;      
Foreground# �  6p   #��[ 5       ��5   q   �� *Patient.FirstName+5       �� 5"   
   $��1��6   $��1��6   $	��200��6/   $��Center=�6;   $��Right=�6V   $��0,0,10,0q�6�     PatientLastNameTableHeader# �  5#      # �  6`   #���  5$      #���  6;   # �  6p   #��[ 5%      ��5"   r   �� *Patient.LastName+5%      (  "System.Windows.Controls.DatePicker  5'   
   $��2��6   $��0��6"   $	��150��62   $��50��6>   $��Center=�6K   $
��Left=�6f   $��10,0,0,0q�6�     PatientDOBTableHeader# �  5(       $	  MaterialDesignOutlinedDatePicker#��[	 6_   # �  5)      #���  5*      #���  6E   	   SelectedDate	 5'   �   �� *Patient.DateOfBirth+5,      �� 53   
   -   5        
 ��Name$
 OutlinedComboBox��53   <   $��2��6   $��1��6    $	��200��60   $��Center=�6W   $��Right=�6r   $��0,0,10,0q�6�    �� 
IsReadOnly$
 True��6�   #���  54       
 ComboBoxItemBackgroundColor#��� 
 66   #���  6q     PatientGenderTableHeader# �  55      # �  6Y    " MaterialDesignOutlinedComboBox#��[ 56        CustomComboBoxItemStyle#��[ 6K    �� Text 53   �   �� *Patient.Gender+��6�   �� *GenderCollection+56   K   �� 5:   
   $��3��6   $��0��6   $	��200��60   $��Center=�6<   $
��Left=�6W   $��10,0,0,0q�6�    ! PatientPhoneNumberTableHeader# �  5;      # �  6c   #���  5<      #���  6;   # �  6p   #��[ 5=      ��5:   r   �� *Patient.PhoneNumber+5=      �� 5>   
   $��3��6   $��1��6   $	��200��60   $��Center=�6<   $��Right=�6W   $��0,0,10,0q�6�   $ Email��5?      # �  69   #���  5@      #���  6;   #��[ 5A      # �  6M   ��5>   s   �� *Patient.Email+5A   M   �� 5C   
   $��4��6   $��1��6   $��	0,10,10,0q�6.   $
��Auto��6A   $	��Top=�6N   $��Right=�6f   #���  5D   	     ButtonBackgroundColor#���  62   ���#bdc3c7��5C   �   �� *AddPatientCommand+��5E      �� 5F       �� Orientation$ 
Horizontal=�6   .+�5G      ��   AddPatientButtonText#���  6    6Q   5H      5J      5K      5L      