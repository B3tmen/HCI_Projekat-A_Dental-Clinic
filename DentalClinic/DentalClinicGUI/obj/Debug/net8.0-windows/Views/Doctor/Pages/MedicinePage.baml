   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DentalClinicGUI.Views.Doctor.Pages"DentalClinicGUI.Views.Doctor.Pages  5      5    /DentalClinicGUI.Views.Doctor.Pages.MedicinePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      <local0clr-namespace:DentalClinicGUI.Views.Doctor.Pages  5        N� Title$  MedicinePage��5         AppFontFamily N� 
FontFamily# �   6   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��50 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��1��6!   $��Center=�61   $��Center=�6N     MedicinePageTitle#���  6i   $��20(�6�     	TextColor#���  6�   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"     BackgroundColor#���  6;   $��	10,10,0,0q�6j   $
��Auto��6}   .+�5        FontAwesome5.ImageAwesome  $��15��6      Icon$ Solid_Search=�6+      
Foreground �#2980b9$��10,0,0,0q�6T   �� 5      $	��200��6   $
��Left=�6"   $��10,0,0,0q�6=     SearchPlaceholderText)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6O   #���  5        StaticUnderlineColor#���  67     UnderlineColor.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush# �  6l   ��5   �   �� *
SearchText+	 �� UpdateSourceTrigger$	 PropertyChanged=�5   �   5      �� 5!   
   $��1��6   $��1��6"   $��	10,0,10,0q�62   $ 
Horizontal=�6E   .+�5"        $��15��6   $ Solid_Pills=�6+    �#2980b9$��10,0,0,0q�6S   �� 5#      $
��Auto��6     TotalMedicineTextBlock#���  6&   $��Center=�6V   $��10,0,0,0q�6q   #���  6�   �� 5$      $	��100��6   $��Center=�6D   $��10,0,0,0q�6_   #���  6q   ��6%   �� *MedicineCount+6q   5%      �� 5'   
   $ 
Horizontal=�6   $��1��6.   $��2��6;   $��Right=�6K   .+�5(      �� $��0,0,10,0q�6   $
��Auto��6'   $��Right=�64   #���  5)        ButtonBackgroundColor#���  6:   ���#bdc3c7��5(   P   �� *RefreshCommand+��5*      �� 5+      $ 
Horizontal=�6!   .+�5,        $��20��6+   $��0,0,10,0q�67   $ 
Solid_Sync=�6I    	 IconForegroundColor# � 	 6[   �� 5-       
 RefreshButtonText#��� 
 6$   6R   5.      50      �� 52      $��1��6   $��2��6"   $��0,0,10,0q�62   $
��Auto��6D   $��Right=�6Q   #���  53   	   #���  62   ���#bdc3c7��52   m   �� *ShowAddMedicineCommand+��54      �� 55      $ 
Horizontal=�6!   .+�56        $��20��6+   $��0,0,10,0q�67   $ Solid_PlusCircle=�6I   # � 	 6a   �� 57        AddMedicineButtonText#���  6$   6V   58      5:      5;      &   System.Windows.Controls.DataGrid  5=   
   $��2��6   $��3��6    $��10 10 10 10q�64   $
��Auto��6I   
   
IsReadOnly$

 True��6�      AutoGenerateColumns$ False��6�     TableBackgroundColor#���  5>        TableBorderBrushColor#���  6G   #���  6}   ��5=   V   �� *MedicineCollection+   Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *
MedicineId+   HeaderTemplate 5B      �� 5C      .R�5D      �� $
��Auto��6)     MedicineIdTableHeader#���  66   #���  6e   5E      5G        5I      $
 Auto 6%    62   �� *Name+ 5J      �� 5K      .R�5L      �� $
��Auto��6)     MedicineNameTableHeader#���  66   #���  6g   5M      5O        5Q      $
 Auto 6%    62   �� *	DaysOfUse+ 5R      �� 5S      .R�5T      �� $
��Auto��6)      MedicineDaysOfUseTableHeader#���  66   #���  6l   5U      5W        5Y      $
 Auto 6%    62   �� *UseTimesPerDay+ 5Z      �� 5[      .R�5\      �� $
��Auto��6)    " MedicineTimesPerDayTableHeader#���  66   #���  6n   5]      5_        5a      $
 Auto 6%    62   �� *ExpirationDate+ 5b      �� 5c      .R�5d      �� $
��Auto��6)    % !MedicineExpirationDateTableHeader#���  66   #���  6q   5e      5g      5j      5k      5l      