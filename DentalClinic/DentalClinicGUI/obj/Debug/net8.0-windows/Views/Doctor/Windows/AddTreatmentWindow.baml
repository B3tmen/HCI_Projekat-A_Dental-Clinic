   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:DentalClinicGUI.Views.Doctor.Windows$DentalClinicGUI.Views.Doctor.Windows  5   	   =    7DentalClinicGUI.Views.Doctor.Windows.AddTreatmentWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:DentalClinicGUI.Views.Doctor.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5   	     � Title$  AddTreatmentWindow��5
   	   $
��Auto��6$   $
��1150��62   $
��1150��6?      AppFontFamily#���   6O    � 	Resources 5        SelectableEllipseStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�  &	       �� 5   
   " A�6/   .�5      ��  � ��$	 100��6&   �� 5       � ��$	 100��6'   �� 5       � ��
 ���� 6%   �� 5       � ��
 �   �6'   �� 5       � ��$ 1��60   �� 5       �@�Cursor$
 Hand��6'    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 �  ��6-   5      5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $
��Auto �6   6,   �� 5#      6   .+�5'   
   � $��0��6    5(      �� 5)      6"   	 � ColumnDefinitions	 5+      �� 5,      6%   �� 5-      6%   .+�50      � $��0��6   $��0��6%   .+�51      �� $	��150��6   $��
10,0,10,10q�6&   $��Center=�6:   
 �� 
IsReadOnly$

 True��6U     TreatmentPatientId)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  52       % !MaterialDesignFloatingHintTextBox#��[ 6[   ��51   g   �� *Patient.PatientId+52   [   �� 53      $	��150��6   $��
10,0,10,10q�6&   $��Center=�6:   $

 True��6U     TreatmentPatientName# �  54      #��[ 6]   ��53   g   �� *PatientName+54   ]   �� 55      $	��150��6   $��
10,0,10,10q�6&   $��Center=�6:   $

 True��6U     TreatmentPatientDOB# �  56      #��[ 6\   ��55   g   �� *Patient.DateOfBirth+56   \   �� 57      $	��150��6   $��
10,0,10,10q�6&   $��Center=�6:   $

 True��6U     TreatmentPatientPhone# �  58      #��[ 6^   ��57   g   �� *Patient.PhoneNumber+58   ^   �� 59      $	��150��6   $��
10,0,10,10q�6&   $��Center=�6:   $

 True��6U     TreatmentPatientGender# �  5:      #��[ 6_   ��59   g   �� *Patient.Gender+5:   _   5;      �� 5=      $��1��6   $��Right=�6%   $��10q�6A     	TextColor#���  5>       	 ButtonBackgroundColor#��� 	 6>   ���#bdc3c7$��60��6�   $	��130��6�   ��5=   M   �� *FinishTreatmentCommand+��5?      �� 5@      .+�5A        FontAwesome5.ImageAwesome  $��30��6+      Icon$ Regular_Save=�67    
 IconForegroundColor   
Foreground# � 
 6K   �� 5B      $��Finish��6$   64   5C      5E      5F      � 5J   
   $��1��6    5K      �� 5L      $
��Auto �6    60   �� 5M      6"   	 5P      �� 5Q      6%   �� 5R      6%   .+�5V      �� $��0��6   $��0��6$   $
��Auto��64   $��	Treatment��6B   $��10,10,10,10q�6U   $	��Top=�6j   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background# � 	 5W         
Foreground# �  6e      Mode$ Custom=�6�   .��5X      �� .+�5Y      �� $	��200��6>   $��	10,0,10,0q�6J   $
��Left=�6]   $
 Name��6x   #��[ 6�   #���  5Z        StaticUnderlineColor#���  6B     UnderlineColor.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush# �  6w   ��5Y      �� *Treatment.Name+5Z   �   �� 5\      $	��200��6E   $��
10,20,10,0q�6R   $	��Top=�6f   $ Description��6~    �� AcceptsReturn$
 True��6�    ! MaterialDesignOutlinedTextBox#��[ 5]       �� TextWrapping$
 Wrap=�6P   " �� VerticalScrollBarVisibility$
 Auto=�6d   ��5\      �� *Treatment.Description+5]   d   �� 5_       �� DisplayMemberPath$
 Name��6J   $	��150��6�   $��	10,20,0,0q�6�   #���  6�     ComboBoxItemBackgroundColor#���  6�   #���  6  $
��Left=�6?  $ Medicine��5`      # �  6C    " MaterialDesignOutlinedComboBox#��[ 5a        CustomComboBoxItemStyle#��[ 6W   ��5_      �� *MedicineCollection+ �� SelectedItem 6c   �� *SelectedMedicine+5b      5c      5d      �� 5g      $��1��6   $��0��6$   $
��Auto��64   $��
10,0,10,10q�6B   $��Selected teeth��6V   # � 	 5h      # �  6e   $ Custom=�6�   .��5j      �� $	��Top=�6G   $
��Left=�6_   ��6   �� *TeethCollection+��5k      �� 5l      .R�5m      �  � Orientation$ 
Horizontal=�6(   5n      ��5p      �� 5q      .R�5r      #  MaterialDesignThemes.Wpf.Chip  ��62   �� *Text+5s      5u      5�      �� 5�      $��0��6   $��1��6"    K� ZIndex$ 1��62   .+�5�      �� $"��../../../Resources/Teeth.jpg��6   $��Uniform=�6>   $	��350��6P   $	��563��6]   6k   A� 5�      #��[ 6    �� Left$ 16��6k   
 �� Top$	 148��6|   $��24��6�   $��33��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorTR8+ J� InputBindings 5�      d� 5�       �� CommandParameter$	 TR8��6O    d� MouseAction$ 	LeftClicke�6f    �� Command 6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $ 59��6k   $	 147��6|   $��23��6�   $��34��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorTR7+ 5�      d� 5�      $	 TR7��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 103��6k   $	 146��6}   $��26��6�   $��35��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorTR6+ 5�      d� 5�      $	 TR6��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 144��6k   $	 142��6}   $��28��6�   $��24��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorTR5+ 5�      d� 5�      $	 TR5��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 171��6k   $	 142��6}   $��28��6�   $��22��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorTR4+ 5�      d� 5�      $	 TR4��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 200��6k   $	 134��6}   $��37��6�   $��25��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorTR3+ 5�      d� 5�      $	 TR3��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 229��6k   $	 140��6}   $��32��6�   $��21��6�   $��Center=�6�   $	��Top=�6�   ��6J   �� *EllipseColorTR2+ 5�      d� 5�      $	 TR2��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 253��6k   $	 135��6}   $��36��6�   $��26��6�   $��Center=�6�   $	��Top=�6�   ��6J   �� *EllipseColorTR1+ 5�      d� 5�      $	 TR1��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 284��6k   $	 136��6}   $��35��6�   $��27��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorTL1+ 5�      d� 5�      $	 TL1��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 313��6k   $	 140��6}   $��31��6�   $��21��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorTL2+ 5�      d� 5�      $	 TL2��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 338��6k   $	 136��6}   $��34��6�   $��26��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorTL3+ 5�      d� 5�      $	 TL3��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 369��6k   $	 142��6}   $��29��6�   $��24��6�   $��Center=�6�   $	��Top=�6�   ��6J   �� *EllipseColorTL4+ 5�      d� 5�      $	 TL4��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 397��6k   $	 143��6}   $��29��6�   $��21��6�   $��Center=�6�   $	��Top=�6�   ��6J   �� *EllipseColorTL5+ 5�      d� 5�      $	 TL5��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 425��6k   $	 146��6}   $��26��6�   $��35��6�   $��Center=�6�   $	��Top=�6�   ��6J   �� *EllipseColorTL6+ 5�      d� 5�      $	 TL6��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 471��6k   $	 146��6}   $��26��6�   $��33��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorTL7+ 5�      d� 5�      $	 TL7��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 516��6k   $	 145��6}   $��28��6�   $��31��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorTL8+ 5�      d� 5�      $	 TL8��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $ 10��6k   $	 186��6|   $��18��6�   $��37��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorBR8+ 5�      d� 5�      $	 BR8��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $ 58��6k   $	 185��6|   $��20��6�   $��34��6�   $��Center=�6�   $	��Top=�6�   ��6J   �� *EllipseColorBR7+ 5�      d� 5�      $	 BR7��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $ 96��6k   $	 184��6|   $��24��6�   $��40��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorBR6+ 5�      d� 5�      $	 BR6��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5�      A� 5�      #��[ 6   $	 141��6k   $	 185��6}   $��25��6�   $��28��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorBR5+ 5�      d� 5      $	 BR5��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5     A� 5     #��[ 6   $	 174��6k   $	 185��6}   $��25��6�   $��22��6�   $
��Left=�6�   $	��Top=�6�   ��6J   �� *EllipseColorBR4+ 5     d� 5     $	 BR4��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5     A� 5     #��[ 6   $	 206��6k   $	 183��6}   $��30��6�   $��22��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorBR3+ 5	     d� 5
     $	 BR3��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5     A� 5     #��[ 6   $	 240��6k   $	 180��6}   $��30��6�   $��15��6�   $
��Left=�6�   $	��Top=�6�   ��6J   �� *EllipseColorBR2+ 5     d� 5     $	 BR2��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5     A� 5     #��[ 6   $	 261��6k   $	 180��6}   $��27��6�   $��19��6�   $
��Left=�6�   $	��Top=�6�   ��6J   �� *EllipseColorBR1+ 5     d� 5     $	 BR1��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5     A� 5     #��[ 6   $	 283��6k   $	 180��6}   $��27��6�   $��19��6�   $
��Left=�6�   $	��Top=�6�   ��6J   �� *EllipseColorBL1+ 5     d� 5     $	 BL1��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5     A� 5     #��[ 6   $	 308��6k   $	 180��6}   $��27��6�   $��15��6�   $
��Left=�6�   $	��Top=�6�   ��6J   �� *EllipseColorBL2+ 5     d� 5     $	 BL2��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5      A� 5!     #��[ 6   $	 333��6k   $	 183��6}   $��30��6�   $��25��6�   $
��Left=�6�   $	��Top=�6�   ��6J   �� *EllipseColorBL3+ 5"     d� 5#     $	 BL3��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5%     A� 5&     #��[ 6   $	 367��6k   $	 185��6}   $��25��6�   $��22��6�   $
��Left=�6�   $	��Top=�6�   ��6J   �� *EllipseColorBL4+ 5'     d� 5(     $	 BL4��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5*     A� 5+     #��[ 6   $	 398��6k   $	 185��6}   $��27��6�   $��21��6�   $
��Left=�6�   $��Center=�6�   ��6J   �� *EllipseColorBL5+ 5,     d� 5-     $	 BL5��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5/     A� 50     #��[ 6   $	 426��6k   $	 184��6}   $��24��6�   $��43��6�   $��Center=�6�   $	��Top=�6�   ��6J   �� *EllipseColorBL6+ 51     d� 52     $	 BL6��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   54     A� 55     #��[ 6   $	 470��6k   $	 182��6}   $��24��6�   $��37��6�   $��Center=�6�   $	��Top=�6�   ��6J   �� *EllipseColorBL7+ 56     d� 57     $	 BL7��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   59     A� 5:     #��[ 6   $	 516��6k   $	 185��6}   $��20��6�   $��37��6�   $��Center=�6�   $	��Top=�6�   ��6J   �� *EllipseColorBL8+ 5;     d� 5<     $	 BL8��6O   $ 	LeftClicke�6f    6'   �� *EllipseClickCommand+6f   5>     5?     5@     5A     5B     