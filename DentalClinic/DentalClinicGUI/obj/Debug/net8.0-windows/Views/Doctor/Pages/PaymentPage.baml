   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DentalClinicGUI.Views.Doctor.Pages"DentalClinicGUI.Views.Doctor.Pages  5      E AViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ7clr-namespace:ViewModels.Converters;assembly=ViewModelsViewModels.Converters 5	      4    .DentalClinicGUI.Views.Doctor.Pages.PaymentPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      _	 [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5      <local0clr-namespace:DentalClinicGUI.Views.Doctor.Pages 	 5      @vm7clr-namespace:ViewModels.Converters;assembly=ViewModels 	 5	        N� Title$  PaymentPage��5         AppFontFamily N� 
FontFamily# �   6    � 	Resources 5      8  2ViewModels.Converters.BooleanToVisibilityConverter  Bool2VisConverter��%   &	         5   
   6*   5      .��5      � $��Center=�6    � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   .+�5   
   �� $��0��6   $��0��6!   $��Center=�61   $��Center=�6N     PaymentTitleTextBlock#���  6i   $��20(�6�     	TextColor#���  6�   &   System.Windows.Controls.DataGrid  5   
   $��1��6   $��0��6    $��10 10 10 10q�60   $
��Auto��6E      AutoGenerateColumns$ False��6�      
IsReadOnly$
 True��6�     TableBackgroundColor#���  5        TableBorderBrushColor#���  6?   #���  6u   ��5   R   �� *PatientPaymentsCollection+ �� SelectedItem 6�   �� *SelectedPatient+ � ContextMenu 5      �� 5       y�6   �� *IsItemSelected+	 �� 	Converter#	 [ .@�5!      m�   PaymentGenerateReceiptText#���  6   
 m� Command
 6U   �� *ShowReceiptWindowCommand+6�   5"         Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *	PatientId+   HeaderTemplate 5'      �� 5(      .R�5)      �� $
��Auto��6)     PatientIdTableHeader#���  66   #���  6d   5*      5,        5.      $
 Auto 6%    62   �� *	FirstName+ 5/      �� 50      .R�51      �� $
��Auto��6)     PatientFirstNameTableHeader#���  66   #���  6k   52      54        56      $
 Auto 6%    62   �� *
LastName+ 57      �� 58      .R�59      �� $
��Auto��6)    	 PatientLastNameTableHeader#��� 	 66   #���  6j   5:      5<        5>      $
 Auto 6%    62   �� *DateOfBirth+ 5?      �� 5@      .R�5A      �� $
��Auto��6)    
 PatientDOBTableHeader#��� 
 66   #���  6e   5B      5D        5F      $
 Auto 6%    62   �� *Gender+ 5G      �� 5H      .R�5I      �� $
��Auto��6)     PatientGenderTableHeader#���  66   #���  6h   5J      5L      5N      5P      5Q      