   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DentalClinicGUI.Views.Doctor.Pages"DentalClinicGUI.Views.Doctor.Pages  5      E AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.Converters;assembly=ViewModelsViewModels.Converters 5	      5    /DentalClinicGUI.Views.Doctor.Pages.PatientsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      _	 [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5      <local0clr-namespace:DentalClinicGUI.Views.Doctor.Pages 	 5      @vm7clr-namespace:ViewModels.Converters;assembly=ViewModels 	 5	        N� Title$  PatientsPage��5         AppFontFamily N� 
FontFamily# �   6    � 	Resources 5      8  2ViewModels.Converters.BooleanToVisibilityConverter  Bool2VisConverter��%   &	         5   
   6*   5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��50 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��1��6!   $��Center=�61   $��Center=�6N     PatientPageTitle#���  6i   $��20(�6�     	TextColor#���  6�   �� 5!   
   $��1��6    �� Orientation$ 
Horizontal=�6"     BackgroundColor#���  6;   $��	10,10,0,0q�6j   $
��Auto��6}   .+�5"        FontAwesome5.ImageAwesome  $��15��6      Icon$ Solid_Search=�6+      
Foreground �#2980b9$��10,0,0,0q�6T   �� 5#      $	��200��6   $
��Left=�6"   $��10,0,0,0q�6=     SearchPlaceholderText) 	 #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6O   #���  5$        StaticUnderlineColor#���  6:     UnderlineColor. 	 (MaterialDesignThemes.Wpf.TextFieldAssist	   UnderlineBrush#	 �  6o   ��5#   �   �� *
SearchText+
 �� UpdateSourceTrigger$
 PropertyChanged=�5$   �   5%      �� 5'   
   $��1��6   $��1��6"   $��	10,0,10,0q�62   $ 
Horizontal=�6E   .+�5(        $��15��6   $ Solid_Wheelchair=�6+    �#2980b9$��10,0,0,0q�6X   �� 5)      $	��100��6     TotalPatientsTextBlock#���  6%   $��Center=�6U   $��10,0,0,0q�6p   #���  6�   �� 5*      $	��100��6   $��Center=�6D   $��0,0,0,0q�6_   #���  6p   ��6%   �� *PatientsCount+6p   5+      �� 5-   
   $ 
Horizontal=�6   $��1��6.   $��2��6;   $��Right=�6K   .+�5.      �� $��0,0,10,0q�6   $
��Auto��6'   $��Right=�64   #���  5/       	 ButtonBackgroundColor#��� 	 6:   ���#bdc3c7��5.   P   �� *RefreshCommand+��50      �� 51      $ 
Horizontal=�6!   .+�52        $��20��6+   $��0,0,10,0q�67   $ 
Solid_Sync=�6I    
 IconForegroundColor# � 
 6[   �� 53        RefreshButtonText#���  6$   6R   54      56      �� 58      $��0,0,10,0q�6   $
��Auto��6'   $��Right=�64   #���  59      #��� 	 6:   ���#bdc3c7��58   P   �� *ShowPatientWindowCommand+��5:      �� 5;      $ 
Horizontal=�6!   .+�5<        $��20��6+   $��0,0,10,0q�67   $ Solid_UserPlus=�6I   # � 
 6_   �� 5=        AddPatientButtonText#���  6$   6U   5>      5@      5A      &   System.Windows.Controls.DataGrid  5C   
   $��2��6   $��3��6    $��10q�6�   $
��Auto��6�      AutoGenerateColumns$ False��6�      
IsReadOnly$
 True��6�     TableBackgroundColor#���  5D        TableBorderBrushColor#���  6G   #���  6}   ��5C   4   �� *PatientsCollection+ �� SelectedItem 6_   �� *SelectedPatient+ � ContextMenu 5G      �� 5H      y�6   �� *IsItemSelected+ �� 	Converter# [ .@�5I      m� $��Add treatment��6    m� Command 66   �� *ShowTreatmentWindowCommand+6h   5J         Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 62   �� *	PatientId+   HeaderTemplate 5R      �� 5S      .R�5T      �� $
��Auto��6)     PatientIdTableHeader#���  66   #���  6d   5U      5W        5Y      $
 Auto 6%    62   �� *	FirstName+ 5Z      �� 5[      .R�5\      �� $
��Auto��6)     PatientFirstNameTableHeader#���  66   #���  6k   5]      5_        5a      $
 Auto 6%    62   �� *
LastName+ 5b      �� 5c      .R�5d      �� $
��Auto��6)     PatientLastNameTableHeader#���  66   #���  6j   5e      5g        5i      $
 Auto 6%    62   �� *DateOfBirth+ 5j      �� 5k      .R�5l      �� $
��Auto��6)     PatientDOBTableHeader#���  66   #���  6e   5m      5o        5q      $
 Auto 6%    62   �� *Gender+ 5r      �� 5s      .R�5t      �� $
��Auto��6)     PatientGenderTableHeader#���  66   #���  6h   5u      5w        5y      $
 Auto 6%    62   �� *PhoneNumber+ 5z      �� 5{      .R�5|      �� $
��Auto��6)    ! PatientPhoneNumberTableHeader#���  66   #���  6m   5}      5        5�      $
 Auto 6%    62   �� *Email+ 5�      �� 5�      .R�5�      �� $
��Auto��6)     PatientEmailTableHeader#���  66   #���  6g   5�      5�      5�      5�      5�      