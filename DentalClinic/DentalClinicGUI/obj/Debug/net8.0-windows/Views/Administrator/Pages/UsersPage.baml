   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:DentalClinicGUI.Views.Administrator.Pages)DentalClinicGUI.Views.Administrator.Pages  5      9    3DentalClinicGUI.Views.Administrator.Pages.UsersPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:DentalClinicGUI.Views.Administrator.Pages     5      X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  	UsersPage��5         AppFontFamily N� 
FontFamily# �   6   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��50 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$	 asd��5      $��0��6!   $��1��6.   $��Center=�6>   $��Center=�6[     UsersPageTitle#���  6v   $��20(�6�     	TextColor#���  6�   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"     BackgroundColor#���  6;   $��	10,10,0,0q�6j   $
��Auto��6}   .+�5        FontAwesome5.ImageAwesome  $��15��6      Icon$ Solid_Search=�6+      
Foreground �#2980b9$��10,0,0,0q�6T   �� 5      $	��200��6   $
��Left=�6"   $��10,0,0,0q�6=     SearchPlaceholderText)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6O   #���  5   	     StaticUnderlineColor#���  62     UnderlineColor.  (MaterialDesignThemes.Wpf.TextFieldAssist	   UnderlineBrush#	 �  6g   ��5   �   �� *
SearchText+
 �� UpdateSourceTrigger$
 PropertyChanged=�5   �   5      �� 5!   
   $ 
Horizontal=�6   $��1��6.   $��2��6;   $��Right=�6K   .+�5"      �� $��0,0,10,0q�6   $
��Auto��6'   $��Right=�64   #���  5#        ButtonBackgroundColor#���  6.   ���#bdc3c7��5"   P   �� *RefreshCommand+��5$      �� 5%      $ 
Horizontal=�6!   .+�5&        $��20��6+   $��0,0,10,0q�67   $ 
Solid_Sync=�6I     IconForegroundColor# �  6[   �� 5'       	 RefreshButtonText#��� 	 6$   6R   5(      5*      �� 5,      $��1��6   $��2��6"   $��0,0,10,0q�62   $
��Auto��6D   $��Right=�6Q   #���  5-      #���  6*   ���#bdc3c7��5,   m   �� *ShowAddUserCommand+��5.      �� 5/      $ 
Horizontal=�6!   .+�50        $��20��6+   $��0,0,10,0q�67   $ Solid_UserPlus=�6I   # �  6_   �� 51       
 AddUserButtonText#��� 
 6$   6R   52      54      55      &   System.Windows.Controls.DataGrid  59   
   $��2��6   $��3��6    $��10q�6]   $
��Auto��6i      AutoGenerateColumns$ False��6v      
IsReadOnly$
 True��6�     TableBackgroundColor#���  5:        TableBorderBrushColor#���  6?   #���  6u   ��59   4   �� *UsersCollection+   Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *UserId+   HeaderTemplate 5=      �� 5>      .R�5?      �� $
��Auto��6)     UserIdTableHeader#���  66   #���  6a   5@      5B        5D      $
 Auto 6%    62   �� *	FirstName+ 5E      �� 5F      .R�5G      �� $
��Auto��6)     UserFirstNameTableHeader#���  66   #���  6h   5H      5J        5L      $
 Auto 6%    62   �� *
LastName+ 5M      �� 5N      .R�5O      �� $
��Auto��6)     UserLastNameTableHeader#���  66   #���  6g   5P      5R        5T      $
 Auto 6%    62   �� *Email+ 5U      �� 5V      .R�5W      �� $
��Auto��6)     UserEmailTableHeader#���  66   #���  6d   5X      5Z        5\      $
 Auto 6%    62   �� *Role+ 5]      �� 5^      .R�5_      �� $
��Auto��6)     UserRoleTableHeader#���  66   #���  6c   5`      5b      4	  .System.Windows.Controls.DataGridTemplateColumn	  5d      $
 Auto 6)    5e      �� 5f      .R�5g      �� $
��Auto��6(     UserIsActiveTableHeader#���  65   #���  6f   5h       	  CellTemplate 5j      �� 5k      .R�5l      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5n   "   d� -   5         $  MaterialDesignSwitchToggleButton#��[ 5n   /    � ToolTip$ Active status��6i    d� 	IsChecked 6�   �� *
IsActive+
 � Tag 6�   �� 1
  +MaterialDesignThemes.Wpf.ToggleButtonAssist 
  SwitchTrackOnBackground 5p   &   �� 5q   *    �� Color$ Green��6:    
  SwitchTrackOffBackground 5s   &   �� 5t   *   $	 Red��6:   5v   #   5w      5x      5z      	  5}      $
 Auto 6)    5~      �� 5      .R�5�      �� $
��Auto��6(     UserUpdateTableHeader#���  65   #���  6d   5�       5�      �� 5�      .R�5�      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5�   "   �� 
������ 
������ ��6)   �� *#!DataContext.ShowUpdateUserCommand+ �� RelativeSource ��  �� AncestorType DataGrid��5�   \   �� .��5�   &     FontAwesome5.FontAwesome     Icon$ Solid_PencilAlt=�66   
����� �6M   5�   #   5�      5�      5�      5�      5�      5�      