   M S B A M L   `   `   `  ����J  FDentalClinicGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DentalClinicGUIDentalClinicGUI  5   	   !    DentalClinicGUI.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:DentalClinicGUI     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5   	   $	��600��6   $	��800��6$   $	��600��60   $	��600��6?    � WindowStartupLocation$ CenterScreen=�6O    � 
ResizeMode$ NoResize=�6t    � Icon$ /Resources/App-logo.png��5	   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $
��1.5* �6   6.   .+�5   
   �� ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      � 	 � Color$	 #2980b9��6#   
 � Offset$
 0Q�63   � 5      $	 #2980b9��6#   $	
 200Q�63   5      ._�5!      � .+�5"      �� .+�5#      �  � Points �    -1��� ;X�����#3498db6:   � 5$      ' �    �� �� ���� ��
�����#2980b96?   A� 5%      $��
50 450 0 0q�6   $��20��62   $��20��6=   ���#74b9ff6I   5&      �� 5(      $��	0 100 0 0q�6   .+�5)      ��  �� Padding$ 15q�6     $  MaterialDesignHeadline4TextBlock#��[ 6-   $��Sign in ��6g   
������� �� TextAlignment$ Center=�6�   $
��Bold"�6�   �� 5*      $ 15q�6    #��[ 6-   $��Enter your personal info��6g   
�������$
��Wrap=�5+       $ Center=�64   $��24(�6K    �� 
LineHeight$ 28��6Y   5-      5.      5/      �� 51   
   ���#ffffff$��1��6&   ._�52      �� .+�53      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ToothOutline=�6*   ���#3498db$��93��6T   $	��176��6`   $��Center=�6l   �� 54      $ 15q�6   #��[ 6)   $��Sign in��6c   ���#2980b9$ Center=�6�   $
��Bold"�6�   �� 56      $��1q�6   ���#ACB0AF$��20 40 20 10q�6C   $
��Auto��6X   ._�57      �� $
��Auto��6!   $��Center=�6.   .+�59      �� $��Center=�6%   $��Center=�6@   .+�5:      ��  �� Orientation$ 
Horizontal=�6)   .+�5;   "     $ Account=�6:   $��0 25 0 0q�6I   ���#3498db6[   �� 5<   "   -   5         ��Name$ UsernameTextBox��5<   Y   $��
10 10 0 20q�6E   $	��150��6r   $��Center=�6~   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��6�      
Foreground �#3498db.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �#3498db   HasClearButton$
 True��5=   �    % !MaterialDesignFloatingHintTextBox#��[ 5>   *   ��5<   *   �� *
Username+5>   *   5?      �� 5A      $ 
Horizontal=�6)   .+�5B   "     $	 Key=�6:   $��0 25 0 0q�6E   ���#3498db6W   G� 5D   "   -   5         G�Name$ FloatingPasswordBox��5D   .   $	��150��6K   $��
10 10 0 20q�6W    �#3498db$ Password��5E   V    �#3498db$
 True��5F   _    / +MaterialDesignFloatingHintRevealPasswordBox#��[ 5G   '   0  *MaterialDesignThemes.Wpf.PasswordBoxAssist   Password 5D   k   �� *
Password+5G   '   5H      5I      �� 5L      $��	10 20 0 0q�6%   $ 
Horizontal=�68   $��Center=�6Q   $��Center=�6l   .+�5M      �� $	��120��6%   $��Login��61   
����������#2980b9��6i   �� *LoginUserCommand+5N      5O      5P      5Q      5S      5T      5V      