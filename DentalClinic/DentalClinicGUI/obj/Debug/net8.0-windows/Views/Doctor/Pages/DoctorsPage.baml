   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DentalClinicGUI.Views.Doctor.Pages"DentalClinicGUI.Views.Doctor.Pages  5      4    .DentalClinicGUI.Views.Doctor.Pages.DoctorsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      <local0clr-namespace:DentalClinicGUI.Views.Doctor.Pages  5        N� Title$  DoctorsPage��5         AppFontFamily N� 
FontFamily# �   6   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��50 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��1��6!   $��Center=�61   $��Center=�6N     DoctorsPageTitle#���  6i   $��20(�6�     	TextColor#���  6�   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"     BackgroundColor#���  6;   $��	10,10,0,0q�6j   $
��Auto��6}   .+�5        FontAwesome5.ImageAwesome  $��15��6      Icon$ Solid_Search=�6+      
Foreground �#2980b9$��10,0,0,0q�6T   �� 5      $	��200��6   $
��Left=�6"   $��10,0,0,0q�6=     SearchPlaceholderText)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6O   #���  5        StaticUnderlineColor#���  67     UnderlineColor.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush# �  6l   ��5   �   �� *
SearchText+	 �� UpdateSourceTrigger$	 PropertyChanged=�5   �   5       �� 5"   
   $��1��6   $��1��6"   $��	10,0,10,0q�62   $ 
Horizontal=�6E   .+�5#        $��15��6   $ Solid_UserMd=�6+    �#2980b9$��10,0,0,0q�6T   �� 5$      $
��Auto��6     TotalDoctorsTextBlock#���  6&   $��Center=�6U   $��10,0,0,0q�6p   #���  6�   �� 5%      $	��100��6   $��Center=�6C   $��10,0,0,0q�6^   #���  6p   ��6%   �� *DoctorsCount+6p   5&      &   System.Windows.Controls.DataGrid  5)   
   $��2��6   $��3��6    $��10 10 10 10q�64   $
��Auto��6I   
   AutoGenerateColumns$
 False��6�      
IsReadOnly$
 True��6�     TableBackgroundColor#���  5*       	 TableBorderBrushColor#��� 	 6G   #���  6}   ��5)   V   �� *DoctorsCollection+   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *UserId+   HeaderTemplate 5-      �� 5.      .R�5/      �� $
��Auto��6)    
 DoctorIdTableHeader#��� 
 66   #���  6c   50      52        54      $
 Auto 6%    62   �� *	FirstName+ 55      �� 56      .R�57      �� $
��Auto��6)     DoctorFirstNameTableHeader#���  66   #���  6j   58      5:        5<      $
 Auto 6%    62   �� *
LastName+ 5=      �� 5>      .R�5?      �� $
��Auto��6)     DoctorLastNameTableHeader#���  66   #���  6i   5@      5B        5D      $
 Auto 6%    62   �� *Specialization+ 5E      �� 5F      .R�5G      �� $
��Auto��6)    # DoctorSpecializationTableHeader#���  66   #���  6o   5H      5J        5L      $
 Auto 6%    62   �� *PhoneNumber+ 5M      �� 5N      .R�5O      �� $
��Auto��6)      DoctorPhoneNumberTableHeader#���  66   #���  6l   5P      5R        5T      $
 Auto 6%    62   �� *Email+ 5U      �� 5V      .R�5W      �� $
��Auto��6)     DoctorEmailTableHeader#���  66   #���  6f   5X      5Z        5\      $
 Auto 6%    62   �� *Gender+ 5]      �� 5^      .R�5_      �� $
��Auto��6)     DoctorGenderTableHeader#���  66   #���  6g   5`      5b      5t      5u      5v      