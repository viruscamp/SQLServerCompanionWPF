   M S B A M L   `   `   `  ����M  ISQLServerCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA*clr-namespace:SQLServerCompanion;assembly=SQLServerCompanion  5      S3clr-namespace:SQLServerCompanion.Controls;assembly=SQLServerCompanion.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0892    ,SQLServerCompanion.BoolToVisibilityConverter   boolToVisConv  LoadingStyle  �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value  TabControlNormalBorderBrush �� Color  TabBorderBrush  selectedGradientGlow � Color � Offset  selectedBrush	 �� EndPoint
 �� 
StartPoint  nonSelectedBrush ! horizontalTabHeaderBackground �� Opacity  mainGridBrush 	 ContextMenuItemStyle �� RelativeSource 
 GlassButton �� 
TargetType � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value �� CornerRadius ��Name � RowDefinitions J� Opacity �� RelativeTransform �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle T� X T� Y  �� Triggers! P� Property" P� Value# �� 
TargetName$ N� EnterActions  	Timeline1% N� ExitActions& ��Name  	Timeline2  ValidatingTextBox-  'System.Windows.Input.KeyboardNavigation' �� Padding( ��Name) �� Self* �� Path  NormalButtonStyle+ ��Name, �� StrokeMiterLimit- �� RadiusX. �� RadiusY/ J� SnapsToDevicePixels  BlackButtonStyle0 �� BasedOn  MainGridBorder1 O� GlowSize2 O� 	GlowColor3 O� Opacity   MyColumnHeaderContainerStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader " MyListViewHeaderContainerStyle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      4local*clr-namespace:SQLServerCompanion;assembly=  5      ;ctl3clr-namespace:SQLServerCompanion.Controls;assembly=  5      %&  &	        &	      &	 ,    &	 M    &	 p    &	 �    &	 u    &	 �    &	 J    &		 !    &	
     7  7  &	 �    &	 ]    &	 �    7  '�� &    7  &	 �    &	 �     &	 #       5      6&   �� 5	      "  �6!   .�5
   
   ��  � y�$ 	Collapsed=�6'   �� 5   
    � ��$ Center=�60   �� 5   
    � ��$ Center=�6.    5   
   �� 5       6   �� *	IsLoading+ True68   .a�5      ��  � y�$ Visible=�6/   5      5      �� 5      $ #8C8E94��6:   �� 5      $ 	#FF00CE29��6-   
� 5      .��5   
   � $ 	LightGray��6   $ 0Q�6)   � 5   
   $ 	#0059FF6B��6   $ 1Q�6)   5      �� 5       $	 0.5,1&�60   $
 0.5,0&�6A   .��5!   
   � $ 	#FF8E8C5E��6   � 5"   
   $ White��6   $ 1Q�6%   5#      �� 5%      $ 	#bF00CE29��60   �� 5(      $	 0.5,1&�6   $
 0.5,0&�6+   $	 0.2Q�6e   .��5)   
   � $ 	#FF000000��6   $ 0.033Q�6)   � 5*   
   $ 	#FFEBEBEB��6   $
 0.16Q�6)   � 5+   
   $ 	#FFE4DCDC��6   $ 0.003Q�6)   � 5,   
   $ 	#FFFFFFFF��6   $ 0.253Q�6)   � 5-   
   $ 	#FFFFFFFF��6   $ 1Q�6)   � 5.   
   $ 	#FFD6D0D0��6   $ 0.945Q�6)   � 5/   
   $ 	#FFFFFFFF��6   $ 0.852Q�6)   50      �� 52      $	 	1.224,0.5&�61   $
 -0.09,0.496&�6F   .��53   
   � $
 Gray��6   $ 0Q�6$   � 54   
   $ 	#ffEAEAEA��6   $	 0.1Q�6)   � 55   
   $ 	LightGray��6   $ 0.089Q�6)   56      �� 59      .�5:   
   ��  � �� 6,   �� *Text+�� 5;   
    �@m�Command 6-   �� *	Command+�� 5<   
    �@m�CommandParameter 66   �� *SelectedItem+ �� *FindAncestor
ListView1+5=      �� 5?      " ��6*    5@   
   ���� 5A      	Timeline1 .��5B      U� $ 00:00:00X�60   $
 glow��6E   $ (UIElement.Opacity)�6b   .\�5C      �� $ 00:00:00.3000000��6+   $ 1Q�6F   5D      5E      �� 5F      	Timeline2 .��5G      U� $ 00:00:00X�60   $
 glow��6E   $ (UIElement.Opacity)�6b   .\�5H      �� $ 00:00:00.3000000��6+   $ 0Q�6F   5I      5J      5K      .R�5L   
   �� ���	#FFFFFFFF$��1,1,1,1q�6)   $ 4,4,4,4��6C   $��Stretch=�5M      ._�5N      �� $ border��6   ���	#7F000000���	#FF000000$��1,1,1,1q�6T   $ 4,4,4,4��6n   ._�5O      �  5P      �� 5Q      $��0.507* �6(   �� 5R      $��0.493* �6(   .+�5T      �� $
 glow��6G   $ 0Q�6   $��Stretch=�6)   $
��Auto��6U   $��2��6b   $ 4,4,4,4��6s   ��5U      
� 5V       5W   "   V� 5X   &   .~�5Y   *   �� $ 1.702Q�69   $ 2.243Q�6H   �� 5Z   *   $ 0Q�68   $ 0Q�6C   �� 5[   *   $ 0Q�6:   T� 5\   *   $ -0.368Q�6=   $ -0.152Q�6H   5]   '   .��5_   "   � $ 	#B28DBDFF��6/   $ 0Q�6A   � 5`   "   $ 	#008DBDFF��6/   $ 1Q�6A   5a      5c      �� 5d      $��Center=�6'   $��Center=�6D   $
��Auto��6_   $��2��6l   �� 5e      $ shine��6L   $��Stretch=�6   $��0,0,0,0q�6;   $
��Auto��6[   $ 4,4,0,0��6h   ��5f      �� 5g      $	 0.494,0.889&�62   $
 0.494,0.028&�6I   .��5h   "   � $ 	#99FFFFFF��6/   $ 0Q�6A   � 5i   "   $ 	#33FFFFFF��6/   $ 1Q�6A   5j      5l      5m      5n      5o        5p   
   P� 5q      ! � ��" . . �5r      �� $# shine��6,    �@J�Opacity$	 0.4Q�6?   �� 5s      $# border��6/    � �� �	#CC0000006C   �� 5t      $
# glow��6/    � y�$ Hidden=�6A   5u      P� 5v      ! �@J�IsMouseOver" . $ 5w      �� 5x      8��  6&   % 5z      �� 5{      $& Timeline2_BeginStoryboard��6&   8�� 6I   5}      5      �� 5�      "  ��6&   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    �@�OverridesDefaultStyle . 62   �� 5�   
    �@ TabNavigation$
 None=�6=   �� 5�   
    �@�FocusVisualStyle 6-   Z� �� 5�   
    � ��$	 120��6%   �� 5�   
    � ��$ 20��6&   �� 5�   
    �@J�	AllowDrop . 6&   �� 5�   
    �@=�ErrorTemplate 65   Z� �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $��Border��5�      $ 5��5�      $' 2q�5�      
�������
���   �$��2q�5�      ._�5�      �� $( PART_ContentHost��62   $��0q�6'   62   5�        5�      P� 5�      ! � {�" .  . �5�      �� $# Border��6%    � ��
 �����6O   �� 5�      $# Border��6%    � ��
 �   �6P   �� 5�       � ��
 �����6;   5�      P� 5�      ! �@=�HasError" . . �5�      �� $# Border��6%    � ��
 �  ��5�   %   5�      5�      5�       5�   
   P� 5�      ! �@=�HasError" . . �5�      ��  �@�ToolTip 5�      �� # Z) $2* ,(Validation.Errors).CurrentItem.ErrorContent�5�      5�      �� 5�      "  ��6&   .�5�   
   ��  � �� �#FFFFFF6'   �� 5�   
    � ��$	 100��6"   �� 5�   
    � ��$ 30��6#   �� 5�   
    � ��$ 14(�6%   �� 5�   
    � ��$
 Bold"�6'   �� 5�   
    � ��$ 5q�6$   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      � .+�5�      �� $+ 	Rectangle��6$   ���	#FF051F42$, 1.000000Q�6J   $��0.500000��6f   $- 5��6�   $. 5��6�   ��5�      �� 5�   "   $	 0.501,0.039&�66   $
 0.501,0.971&�6M   .��5�   &   � $ 	#FF1F317D��63   $ 0.101Q�6E   � 5�   &   $ 	#FF1F317D��63   $
 0.49Q�6E   � 5�   &   $ 	#FF6C8EBD��63   $
 0.51Q�6E   � 5�   &   $ 	#FF283D8C��63   $ 0Q�6E   � 5�   &   $ 	#FF7094C7��63   $ 0.986Q�6E   5�   #   5�      �� 5�      #/ z/ 6+   #��z��6g   #��z��6�   ��. 6�   5�        5�      P� 5�      ! �@J�IsKeyboardFocused" . 6?   P� 5�      ! �@J�IsMouseOver" . . �5�      �� $# 	Rectangle��65    � �� 5�   "   �� 5�   &   $	 0.501,0.039&�6:   $
 0.501,0.971&�6Q   .��5�   *   � $ 	#FF2C558C��67   $ 0.101Q�6I   � 5�   *   $ 	#FF1F317D��67   $
 0.49Q�6I   � 5�   *   $ 	#FF9DB5D7��67   $
 0.51Q�6I   � 5�   *   $ 	#FF244AAF��67   $ 0Q�6I   � 5�   *   $ 	#FF87A4D9��67   $ 0.986Q�6I   5�   '   5�      5�      5�      5�      5�      �� 5�      "  ��6%   80   .�5�   
   ��  � ��$	 100��6"   �� 5�   
    � ��$ 30��6#   �� 5�   
    � ��$ 14(�6%   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      � $��5q�6   .+�5�      �� $+ 	rectangle��6�   ���	#FF000000$, 1.000000Q�67   $��0.500000��6S   $- 5��6n   $. 5��6z   ��5�      �� 5�   "   $	 0.501,0.039&�66   $
 0.501,0.971&�6M   .��5�   &   � $ 	#FF1E1E1E��63   $ 0.101Q�6E   � 5�   &   $ 	#FF1E1E1E��63   $
 0.49Q�6E   � 5�   &   $ 	#FF5B5959��63   $
 0.51Q�6E   � 5�   &   $ 	#FF2F2F2F��63   $ 0Q�6E   � 5�   &   $ 	#FF5B5959��63   $ 0.986Q�6E   5�   #   5�      �� 5�      #/ z/ 6+   #��z��6g   #��z��6�   ��. 6�   5�        5�      P� 5�      ! �@J�IsKeyboardFocused" . 6?   P� 5�      ! �@J�IsMouseOver" . . �5�      �� $# 	rectangle��65    � �� 5�   "   �� 5�   &   $	 0.501,0.039&�6:   $
 0.501,0.971&�6Q   .��5�   *   � $ 	#FF3A3A3A��67   $ 0.101Q�6I   � 5�   *   $ 	#FF1E1E1E��67   $
 0.49Q�6I   � 5�   *   $ 	#FFB0B0B0��67   $
 0.51Q�6I   � 5�   *   $ 	#FF656565��67   $ 0Q�6I   � 5�   *   $ 	#FF989898��67   $ 0.938Q�6I   � 5   *   $ 	#FF7F7F7F��67   $ 0.986Q�6I   5  '   5     5     5     5     5	     �� 5     "  ��6   80   .�5  
   ��  � ��$	 100��6%   �� 5  
    � ��$ 25��6&   �� 5  
    � ��$ 5q�6#   �� 5  
    � ��$ 5q�6$   5     �� 5     "  ��6#   .�5  
   ��  � ��
 �����6'   �� 5  
    � ��
 �   �6(   �� 5  
    � ��$ 1q�6,   �� 5  
    �@��CornerRadius$ 5��6)   �� 5  
    � �� 5     �� 5     $	 0.5,1&�6&   $
 0.5,0&�67   .��5     � $ 	#FF000000��6#   $ 0.033Q�65   � 5     $ 	#FFEBEBEB��6#   $
 0.16Q�65   � 5     $ 	#FFE4DCDC��6#   $ 0.003Q�65   � 5      $ 	#FFFFFFFF��6#   $ 0.253Q�65   � 5!     $ 	#FFFFFFFF��6#   $ 1Q�65   � 5"     $ 	#FFD6D0D0��6#   $ 0.945Q�65   � 5#     $ 	#FFFFFFFF��6#   $ 0.852Q�65   5$     5&     �� 5'  
    �@J�BitmapEffect 5(     O� 5)     $1 6Q�6(   $
2 Gray��65   $3 1Q�6F   5+     5,     �� 50     "   61   .�51  
   ��  � ��$ 0,0,0,0q�6#   �� 52  
    � ��$ 1,1,1,1q�6,   �� 53  
    � ��$ 25��6#   �� 54  
    � �� 55     �� 56     $	 0.5,1&�6&   $
 0.5,0&�67   .��57     � $ 	#FF8E8C5E��6#   � 58     $ White��6#   $ 1Q�61   59     5;     �� 5<  
    � ��
 �   �6'   �� 5>  
    � �� 5?     �� 5@     $	 0.5,1&�6&   $
 0.5,0&�67   .��5A     � $ Black��6#   $ 0Q�61   � 5B     $
 Gray��6#   $	 1.0Q�60   5C     5E     5F     �� 5I     "  ��63   .�5J  
   ��  � ��$ 0,0,0,0q�6#   �� 5K  
    � ��$ 1,1,1,1q�6,   �� 5L  
    � ��$ 25��6#   �� 5M  
    � �� 5N     �� 5O     $	 0.5,1&�6&   $
 0.5,0&�67   .��5P     � $ 	#FF8E8C5E��6#   � 5Q     $ White��6#   $ 1Q�61   5R     5T     �� 5U  
    � ��
 �   �6'   �� 5W  
    � �� 5X     �� 5Y     $	 0.5,1&�6&   $
 0.5,0&�67   .��5Z     � $ Black��6#   $ 0Q�61   � 5[     $
 Gray��6#   $	 1.0Q�60   5\     5^     5_     5`     