   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:DentalClinicGUI.Views.Doctor.Windows$DentalClinicGUI.Views.Doctor.Windows  5   	   8    2DentalClinicGUI.Views.Doctor.Windows.ReceiptWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:DentalClinicGUI.Views.Doctor.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5   	     � Title$  ReceiptWindow��5
   	   $	��800��6   $	��860��6,      AppFontFamily#���   68    � Icon$% ../../../Resources/App-logo.png��6e   .��5      �� -   5         ��Name$ VerticalScrollViewer��5      .��5   
   � $��10q�6   .+�5      �� -   5         ��Name$ PrintButton��5      $��10q�6*   $	��Top=�66   $��Right=�6N     	TextColor#���  6j     ButtonBackgroundColor#���  6�   ���#bdc3c7$��60��5   +   $	��150��67   ��6C   �� *GenerateReceiptCommand+��5      �� 5      .+�5        FontAwesome5.ImageAwesome  $��30��6+      Icon$ Solid_Print=�67     IconForegroundColor   
Foreground# �  6J   �� 5        PaymentPrintReceiptText#���  6$   6X   5      5      � 5      -   5         �Name$ print��5       � RowDefinitions 5      �� 5      $	��120 �6$   �� 5      $	��400 �6$   �� 5      $	��200 �6$   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��30q�66   $��0��6B   .+�5       �� $%��../../../Resources/App-logo.png��6   $
��Auto��6E   6U   �� 5!        ReceiptTitle#���  6    $��Center=�6F   $��35(�6a   $
��Bold"�6o   ���	#FFFBE1886�   5"      �� 5#      $��1��6   $��Stretch=�6*   $��20q�6H   .+�5&      � $��Stretch=�6   	 � ColumnDefinitions	 5'      �� 5(      $��1* �6/   �� 5)      $��1* �6/   .+�5+      �� $��0��6%   $��
10 0 10 10q�65   .+�5,      ��  
 BillTo#���  6(   $��24(�6H   $��5 0 0 0q�6V   �� 5-      $��20(�6h   $��5q�6v   ��6(   �� *PatientFullName+
 �� FallbackValue$
 PatientFullName��6v   �� 5.      $ 
Horizontal=�6)   .+�5/   "   ��   
DateIssued#���  6,   $��12(�6P   $��5q�6^   �� 50   "   $��12(�6_   $��5q�6m   $��DemiBold"�6x   ��6,   �� *	TodayDate+$
 0.0.0001��6x   51      �� 52      $ 
Horizontal=�6)   .+�53   "   ��   ReceiptNumber#���  6,   $��12(�6S   $��5q�6a   �� 54   "   $��12(�6G   $��5q�6U   $��DemiBold"�6`   ��6,   �� *	ReceiptId+6`   55      56      �� 57      $��1��6%   $��10q�65   .+�58      �� $��12(�6h   $��5q�6v   $��Right=�6�   ��6(   �� *PatientFullName+$
 PatientFullName��6�   �� 59      $��Patre 5��6(   $��12(�67   $��5q�6E   $��Right=�6P   �� 5:      $��
Banja Luka��6(   $��12(�6:   $��5q�6H   $��Right=�6S   �� 5;      $��78000��6(   $��12(�65   $��5q�6C   $��Right=�6N   5<      5=      &   System.Windows.Controls.DataGrid  5@      $��
10 10 10 0q�6      AutoGenerateColumns$ False��6d      
IsReadOnly$
 True��6�   $��0q�6�    	 BackgroundColor#��� 	 6�   ��63   �� *ReceiptDetailsCollection+   Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *NameOfTreatment+   HeaderTemplate 5C   "   �� 5D   &   .R�5E   *   �� $
��Auto��65    
 NameOfTreatmentHeader#��� 
 6B   #���  6q   5F   '   5H        5J      $
 Auto 61    6>   �� *Price+ 5K   "   �� 5L   &   .R�5M   *   �� $
��Auto��65     PriceHeader#���  6B   #���  6g   5N   '   5P        5R      $
 Auto 61    6>   �� *TreatedTeethQuantity+ 5S   "   �� 5T   &   .R�5U   *   �� $
��Auto��65     TreatedTeethHeader#���  6B   #���  6n   5V   '   5X        5Z      $
 Auto 61    6>   �� *
Subtotal+ 5[   "   �� 5\   &   .R�5]   *   �� $
��Auto��65     SubtotalHeader#���  6B   #���  6j   5^   '   5`      5b      �� 5c      
���   �$��1��6-   $	��5 2q�68    J� Opacity$	 0.5Q�6E   5d      �� 5f      $��2��6   $
��20 0q�6*   .+�5g      � $��
10 20 10 0q�6   	 5h      �� 5i      $��1* �6/   �� 5j      $��1* �6/   �� 5k      $��1* �6/   .+�5m      ��   TotalHeader#���  6$   $��3��6I   $��12(�6Y   $��Right=�6h   5n      �� 5o      
���   �$��1��6-   $��5q�68   $	 0.5Q�6C   � 5p      $��10q�6   	 5q      �� 5r      $��1* �6/   �� 5s      $��1* �6/   �� 5t      $��1* �6/   .+�5v      �� $��2��6%   .+�5w      �� $��25(�6^   $��5q�6l   $��Right=�6w   ���	#FF62013C$
��Bold"�6�   ��6(   �� *
TotalPrice+$
 
1000.00 KM��6�   5x      5y      �� 5z      
���   �$��1��6-   $��5q�68   $	 0.5Q�6C   � 5}      $��0q�6   $��Stretch=�6&   .+�5~      �� $ Vertical=�6%   $��Center=�6<   $��Center=�6Y   .+�5      ��   ThanksForPayment#���  6(   $��Center=�6R   $��20(�6o   $��5q�6}   $��Light"�6�   �� 5�      $K��EDental Clinic • Ulica • Banja Luka • RS, BiH • +38765/123-456��6(   $��Center=�6m   $��20(�6�   $��5q�6�   $��Light"�6�   5�      5�      5�      5�      5�      5�      5�      