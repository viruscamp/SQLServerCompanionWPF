   M S B A M L   `   `   `  ���� M  ISQLServerCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA*clr-namespace:SQLServerCompanion;assembly=SQLServerCompanion  S3clr-namespace:SQLServerCompanion.Controls;assembly=SQLServerCompanion.Controls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   CloseableTabItemButtonStyle  �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� CornerRadius J� Opacity �� Triggers	 P� Property
 P� Value �� 
TargetName ! TabControlStyleHorizontalTabs.    (SQLServerCompanion.Controls.TabControlEx  TabControlNormalBorderBrush ! horizontalTabHeaderBackground ��Name-  'System.Windows.Input.KeyboardNavigation   TabIndex K� IsItemsHost �Name  TabItemStyleHorizontalTabs � RowDefinitions �� Orientation  boolToVisConv �� 	Converter �� ConverterParameter ��Name �� Path ��Name � ToolTip F�Name �� Stretch  closeTabCrossStroke ��Name ��Name ]� 
Conditions �� Property �� Value  selectedBrush  selectedGradientGlow�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     4local*clr-namespace:SQLServerCompanion;assembly=  ;ctl3clr-namespace:SQLServerCompanion.Controls;assembly=  %�  &	        &	 '    7  7  &	 �    7  7  7  7  �� "  ��.���  �@�FocusVisualStyle Z� ��  � ��
 ���� ��  � ��
 ���� ��  � ��$ 1q���  � ��# � ����  � ��$ Center=���  � ��$ Center=���  � ��$ 4q���  � �� �� " ��.R�� .+��� $ Chrome�� . 
������ #��z��#��z��$ 2��$ 0Q��� # z #��z��#��z��#��z����.  P� 	 �@J�IsMouseOver
 . . ��� $ Chrome�� �@J�Opacity$ 1Q�P� 	 � ��
 . . ��� $ Chrome�� �@J�Opacity$ 1Q�P� 	 � {�
 .  . ���  � ��
 � ���� "    .���  � ��# � ����  � ��$ 0q���  � ��$ 1q���  � ��8   ��  � ��
 �������  � ��$ Center=���  � ��$ Center=���  � �� �� "   .R�]� 8�� .+��� $ tabpanel��$��0,5,0,0q�$y�Visible=�$	��Top=�$ 1�� . �� $ 2,0,0,2��$��0,5,0,5q�#��z��._�� $ PART_ItemsHolder��$��Bottom=�$��5,0,0,0q�#��z�� P� 	 � {�
 .  . ��� # � �� � ���� "  ��.���  �@�FocusVisualStyle Z� ��  � ��
 � �����  � ��$ 0q���  � ��$ Stretch=���  � ��$ Stretch=���  � �� �� " ��.R��  . .+��� $ Bd��$��0q�$ 4��._��  �� $��* ��� $��2 �.+�� $��0��.+�� $
 grid��$��0q�$��Stretch=�$��Stretch=��� $ 
Horizontal=�$��2q�.+��� $��16��$��16��$��2,0,2,0q�$��Center=����� *	ImagePath+y��� *
HasImage+8   $
 True���� $	 lbl��$��2,0,2,0q�$��12(�$
��Bold"�$
��Left=�$��Center=����� $ DisplayText��� $ 
PART_Close��$
��Left=�$��2,0,2,0q�$��Center=�$��16��$��16��|�.  #���   $ 	Close Tab������ $ CloseWorkSpaceCommand�y��� *IsCloseable+8  $
 True��.��F� $
 Path��$
 Fill=�$	��0.5��#���  
���   �������K�����>>X �RX     ��� @°( Q��e �j�  ?� z >X �\aQ  	= � z ¹e Ѯ�e  z � 	= >aQ �RX  z ��M�g�&}>¹e Ѯ�(  	= ��K�����>>X $��Stretch=�$��Stretch=��� $ imgSelectedImage��$y�Hidden=�$��16��$	��16.��$#��/Images/circle-teal-24-ns.png��$��Center=�$
��Left=�$��2q��� $ 	rectShine��$��1��$	 0.5Q����	#ff656565$��0��$��Stretch=�$��Stretch=�$��3�� ]�  ��  �@��
IsSelected . ./���  �@K�ZIndex$ 1���� $ Bd��8   � ���� $
 grid��8   � ���� $ imgSelectedImage�� � y�$ Visible=��� $ 	rectShine�� � ��$ 2��]�  ��  �@��
IsSelected .  ��  �@J�IsMouseOver . ./���  �@K�ZIndex$ 1���� $ Bd�� � ��
 ������� $
 grid�� � ��
 ���� �� $ imgSelectedImage�� � y�$ Hidden=��� $ 	rectShine�� � ��$ 2��]�  ��  �@��
IsSelected .  ��  �@J�IsMouseOver .  ./��� $ 	rectShine�� � ��$ 0���� $	 lbl�� � ��
 ������� $
 Path�� � ��
 �����P� 	 �@��TabStripPlacement$
 Right=�. ��� $ imgSelectedImage�� � ��$
 Left=�