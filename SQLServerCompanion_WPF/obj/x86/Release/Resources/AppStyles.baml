   M S B A M L   `   `   `  ���� M  ISQLServerCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA*clr-namespace:SQLServerCompanion;assembly=SQLServerCompanion  S3clr-namespace:SQLServerCompanion.Controls;assembly=SQLServerCompanion.Controls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0892    ,SQLServerCompanion.BoolToVisibilityConverter   boolToVisConv  LoadingStyle  �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value  TabControlNormalBorderBrush �� Color  TabBorderBrush  selectedGradientGlow � Color � Offset  selectedBrush	 �� EndPoint
 �� 
StartPoint  nonSelectedBrush ! horizontalTabHeaderBackground �� Opacity  mainGridBrush 	 ContextMenuItemStyle �� RelativeSource 
 GlassButton �� 
TargetType � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value �� CornerRadius ��Name � RowDefinitions J� Opacity �� RelativeTransform �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle T� X T� Y  �� Triggers! P� Property" P� Value# �� 
TargetName$ N� EnterActions  	Timeline1% N� ExitActions& ��Name  	Timeline2  ValidatingTextBox-  'System.Windows.Input.KeyboardNavigation' �� Padding( ��Name) �� Self* �� Path  NormalButtonStyle+ ��Name, �� StrokeMiterLimit- �� RadiusX. �� RadiusY/ J� SnapsToDevicePixels  BlackButtonStyle0 �� BasedOn  MainGridBorder1 O� GlowSize2 O� 	GlowColor3 O� Opacity   MyColumnHeaderContainerStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader " MyListViewHeaderContainerStyle�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     4local*clr-namespace:SQLServerCompanion;assembly=  ;ctl3clr-namespace:SQLServerCompanion.Controls;assembly=  %�  &	        &	      &	 �     &	 �     &	 �     &	     &	 b    &	 w    &	 �    &		     &	
 �    7  7  &	 J    &	 (    &	 d    7  '�� �    7  &	 �    &	 �    &	 �       �� "  �.���  � y�$ 	Collapsed=���  � ��$ Center=���  � ��$ Center=� ��  �� *	IsLoading+ True.a���  � y�$ Visible=��� $ #8C8E94���� $ 	#FF00CE29��
� .��� $ 	LightGray��$ 0Q�� $ 	#0059FF6B��$ 1Q��� $	 0.5,1&�$
 0.5,0&�.��� $ 	#FF8E8C5E��� $ White��$ 1Q��� $ 	#bF00CE29���� $	 0.5,1&�$
 0.5,0&�$	 0.2Q�.��� $ 	#FF000000��$ 0.033Q�� $ 	#FFEBEBEB��$
 0.16Q�� $ 	#FFE4DCDC��$ 0.003Q�� $ 	#FFFFFFFF��$ 0.253Q�� $ 	#FFFFFFFF��$ 1Q�� $ 	#FFD6D0D0��$ 0.945Q�� $ 	#FFFFFFFF��$ 0.852Q��� $	 	1.224,0.5&�$
 -0.09,0.496&�.��� $
 Gray��$ 0Q�� $ 	#ffEAEAEA��$	 0.1Q�� $ 	LightGray��$ 0.089Q��� .���  � �� �� *Text+��  �@m�Command �� *	Command+��  �@m�CommandParameter �� *SelectedItem+ �� *FindAncestor
ListView1+�� " �� ���� 	Timeline1 .��U� $ 00:00:00X�$
 glow��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 1Q��� 	Timeline2 .��U� $ 00:00:00X�$
 glow��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�.R��� ���	#FFFFFFFF$��1,1,1,1q�$ 4,4,4,4��$��Stretch=�._��� $ border�����	#7F000000���	#FF000000$��1,1,1,1q�$ 4,4,4,4��._��  �� $��0.507* ��� $��0.493* �.+��� $
 glow��$ 0Q�$��Stretch=�$
��Auto��$��2��$ 4,4,4,4����
�  V� .~��� $ 1.702Q�$ 2.243Q��� $ 0Q�$ 0Q��� $ 0Q�T� $ -0.368Q�$ -0.152Q�.��� $ 	#B28DBDFF��$ 0Q�� $ 	#008DBDFF��$ 1Q��� $��Center=�$��Center=�$
��Auto��$��2���� $ shine��$��Stretch=�$��0,0,0,0q�$
��Auto��$ 4,4,0,0������ $	 0.494,0.889&�$
 0.494,0.028&�.��� $ 	#99FFFFFF��$ 0Q�� $ 	#33FFFFFF��$ 1Q�  P� ! � ��" . . ��� $# shine�� �@J�Opacity$	 0.4Q��� $# border�� � �� �	#CC000000�� $
# glow�� � y�$ Hidden=�P� ! �@J�IsMouseOver" . $ �� 8��  % �� $& Timeline2_BeginStoryboard��8�� �� "  ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@ TabNavigation$
 None=���  �@�FocusVisualStyle Z� ��  � ��$	 120����  � ��$ 20����  �@J�	AllowDrop . ��  �@=�ErrorTemplate Z� ��  � �� �� " ��.R��� $��Border��$ 5��$' 2q�
�������
���   �$��2q�._��� $( PART_ContentHost��$��0q�  P� ! � {�" .  . ��� $# Border�� � ��
 ������� $# Border�� � ��
 �   ���  � ��
 �����P� ! �@=�HasError" . . ��� $# Border�� � ��
 �  �� P� ! �@=�HasError" . . ���  �@�ToolTip �� # Z) $2* ,(Validation.Errors).CurrentItem.ErrorContent��� "  ��.���  � �� �#FFFFFF��  � ��$	 100����  � ��$ 30����  � ��$ 14(���  � ��$
 Bold"���  � ��$ 5q���  � �� �� " ��.R�� .+��� $+ 	Rectangle�����	#FF051F42$, 1.000000Q�$��0.500000��$- 5��$. 5������ $	 0.501,0.039&�$
 0.501,0.971&�.��� $ 	#FF1F317D��$ 0.101Q�� $ 	#FF1F317D��$
 0.49Q�� $ 	#FF6C8EBD��$
 0.51Q�� $ 	#FF283D8C��$ 0Q�� $ 	#FF7094C7��$ 0.986Q��� #/ z/ #��z��#��z����.   P� ! �@J�IsKeyboardFocused" . P� ! �@J�IsMouseOver" . . ��� $# 	Rectangle�� � �� �� $	 0.501,0.039&�$
 0.501,0.971&�.��� $ 	#FF2C558C��$ 0.101Q�� $ 	#FF1F317D��$
 0.49Q�� $ 	#FF9DB5D7��$
 0.51Q�� $ 	#FF244AAF��$ 0Q�� $ 	#FF87A4D9��$ 0.986Q��� "  ��80   .���  � ��$	 100����  � ��$ 30����  � ��$ 14(���  � �� �� " ��.R�� $��5q�.+��� $+ 	rectangle�����	#FF000000$, 1.000000Q�$��0.500000��$- 5��$. 5������ $	 0.501,0.039&�$
 0.501,0.971&�.��� $ 	#FF1E1E1E��$ 0.101Q�� $ 	#FF1E1E1E��$
 0.49Q�� $ 	#FF5B5959��$
 0.51Q�� $ 	#FF2F2F2F��$ 0Q�� $ 	#FF5B5959��$ 0.986Q��� #/ z/ #��z��#��z����.   P� ! �@J�IsKeyboardFocused" . P� ! �@J�IsMouseOver" . . ��� $# 	rectangle�� � �� �� $	 0.501,0.039&�$
 0.501,0.971&�.��� $ 	#FF3A3A3A��$ 0.101Q�� $ 	#FF1E1E1E��$
 0.49Q�� $ 	#FFB0B0B0��$
 0.51Q�� $ 	#FF656565��$ 0Q�� $ 	#FF989898��$ 0.938Q�� $ 	#FF7F7F7F��$ 0.986Q��� "  ��80   .���  � ��$	 100����  � ��$ 25����  � ��$ 5q���  � ��$ 5q��� "  ��.���  � ��
 �������  � ��
 �   ���  � ��$ 1q���  �@��CornerRadius$ 5����  � �� �� $	 0.5,1&�$
 0.5,0&�.��� $ 	#FF000000��$ 0.033Q�� $ 	#FFEBEBEB��$
 0.16Q�� $ 	#FFE4DCDC��$ 0.003Q�� $ 	#FFFFFFFF��$ 0.253Q�� $ 	#FFFFFFFF��$ 1Q�� $ 	#FFD6D0D0��$ 0.945Q�� $ 	#FFFFFFFF��$ 0.852Q���  �@J�BitmapEffect O� $1 6Q�$
2 Gray��$3 1Q��� "   .���  � ��$ 0,0,0,0q���  � ��$ 1,1,1,1q���  � ��$ 25����  � �� �� $	 0.5,1&�$
 0.5,0&�.��� $ 	#FF8E8C5E��� $ White��$ 1Q���  � ��
 �   ���  � �� �� $	 0.5,1&�$
 0.5,0&�.��� $ Black��$ 0Q�� $
 Gray��$	 1.0Q��� "  ��.���  � ��$ 0,0,0,0q���  � ��$ 1,1,1,1q���  � ��$ 25����  � �� �� $	 0.5,1&�$
 0.5,0&�.��� $ 	#FF8E8C5E��� $ White��$ 1Q���  � ��
 �   ���  � �� �� $	 0.5,1&�$
 0.5,0&�.��� $ Black��$ 0Q�� $
 Gray��$	 1.0Q�