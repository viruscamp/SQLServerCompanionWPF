   M S B A M L   `   `   `  ���� M  ISQLServerCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SQLServerCompanion.ControlsSQLServerCompanion.Controls  A*clr-namespace:SQLServerCompanion;assembly=SQLServerCompanion  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0892    ,SQLServerCompanion.BoolToVisibilityConverter   boolToVisConv  OutlookButtonHighlightBlue  �� EndPoint �� 
StartPoint � Color � Offset  OutlookButtonHighlight  MainTabControlTemplateEx �� 
TargetType.   (SQLServerCompanion.Controls.TabControlEx � RowDefinitions ��Name ��Name K� IsItemsHost	 �Name
 �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value  CloseableTabItemButtonStyle �� 
TargetType ��Name J� SnapsToDevicePixels �� CornerRadius J� Opacity ��Name � ToolTip �� Path �� 	Converter �� ConverterParameter F�Name �� Stretch  closeTabCrossStroke ��Name P� 
SourceName  NonWorkspaceTabBase  DefaultLabel  
TabItemOne �� BasedOn 	 
TabItemTwo 
 TabItemThree  TabItemFour�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     6controls)clr-namespace:SQLServerCompanion.Controls  4local*clr-namespace:SQLServerCompanion;assembly=  %�  &	        &	      &	 �     &	 �    7  &	 �    7  '�� �    7  7   7  7  &	 p    7  7  7  7  &	 �    7  &		 �    7  &	
 �    7  &	 �    7     �� $  0.5,1&�$ 0.5,0&�.��� $ 	#FF0070E0��$ 0Q�� $ 	#FF1F8FFF��$ 0.0967Q�� $ 	#FF5CADFF��$ 0.2580Q�� $ 	#FF99CCFF��$ 0.3870Q�� $ 	#FF5CADFF��$ 0.9677Q�� $ 	#FF1F8FFF��$ 1Q��� $  0.5,1&�$ 0.5,0&�.��� $ 	#FFFFBD69��$ 0Q�� $ 	#FFFFB75A��$ 0.0967Q�� $ 	#FFFFB14C��$ 0.2580Q�� $ 	#FFFB8C3C��$ 0.3870Q�� $ 	#FFFEB461��$ 0.9677Q�� $ 	#FFFEBB67��$ 1Q��� "  .R��  �� $
 row0��$
��Auto ��� $
 row1��$��4 ��� $
 row2��$��* �.+��� $ tabpanel��8��  $��0q�$��0�� . � $	 divider��$��1��
���   �$��Stretch=�� $	 PART_ItemsHolder��
�������$��2��
 P�  �@��TabStripPlacement$	 Top=�. ��� $ tabpanel�� � ��$ 0���� $ divider�� � ��$ 1���� $ PART_ItemsHolder�� � ��$ 2���� $
 row0�� � ��$
 Auto ��� $
 row1�� � ��$ 4 ��� $
 row2�� � ��$ * �P�  �@��TabStripPlacement$ Bottom=�. ��� $ tabpanel�� � ��$ 2���� $ divider�� � ��$ 1���� $ PART_ItemsHolder�� � ��$ 0���� $
 row0�� � ��$ * ��� $
 row1�� � ��$ 4 ��� $
 row2�� � ��$
 Auto ��� " ��.���  �@�FocusVisualStyle Z� ��  � ��
 ���� ��  � ��
 ���� ��  � ��$ 1q���  � ��8   ��  � ��$ Center=���  � ��$ Center=���  � ��$ 4q���  � �� �� " ��.R�� .+��� $ Chrome�� . 
������ #��z��#��z��$ 2��$ 0Q��� # z #��z��#��z��#��z����. 
 P�  �@J�IsMouseOver . . ��� $ Chrome�� �@J�Opacity$ 1Q�P�  � �� . . ��� $ Chrome�� �@J�Opacity$ 1Q�P�  � {� .  . ���  � ��
 � � ��� " ��.���  � ��$ 5q���  � ��
 �   ���  � ��8   ��  � ��$ Stretch=���  � ��$ Stretch=���  � �� �� " ��.R��� $ Bd�� . $ 	15,5,0,10��#��z��$��1,1,1,0q�
�������$	��100��._�]� $
��Auto��.+��� $
��Fred���� $ 
PART_Close��$��Center=�$��3q�$��Center=�$��16��$��16��$��Right=�|�.  #���  $ 	Close Tab������ $ CloseWorkSpaceCommand�y��� *IsCloseable+8  $
 True��.��F� $
 Path��$
 Fill=�$	��0.5��#���  
���   �������K�����>>X �RX     ��� @°( Q��e �j�  ?� z >X �\aQ  	= � z ¹e Ѯ�e  z � 	= >aQ �RX  z ��M�g�&}>¹e Ѯ�(  	= ��K�����>>X $��Stretch=�$��Stretch=��� $	 lbl��$��2,0,2,0q�$��Center=����� $ DisplayText�
 P�  �@��
IsSelected . . ��� $ Bd�� � ��
 �   ��� $	 lbl��8   � ���� $
 Path��8   � ��P� $ 
PART_Close�� �@J�IsMouseOver . . ��� $
 Path�� � ��
 �  ��P� $ Bd�� �@J�IsMouseOver . . ��� $	 lbl�� �@�Cursor$
 Hand��P� $ 
PART_Close�� � �� . . ��� $
 Path�� � ��
 �  ���� " ��.���  � ��$ 5q���  � ��
 �   ���  � ��8   ��  � ��$ Stretch=���  � ��$ Stretch=���  � ��$	 Tab����  � �� �� " ��.R��� $ Bd�� . $ 5,5,0,0��#��z��$��1,1,1,0q�
�������$	��100��._�]� $
��Auto��.+��� $ 
PART_Close��$��Center=�$��3q�$��Center=�$��16��$��16��$y�Hidden=�$��Right=�|�.  #���  $ 	Close Tab������ $ CloseWorkSpaceCommand�.��F� $
 Path��$
 Fill=�$	��0.5��#���  
���   �������K�����>>X �RX     ��� @°( Q��e �j�  ?� z >X �\aQ  	= � z ¹e Ѯ�e  z � 	= >aQ �RX  z ��M�g�&}>¹e Ѯ�(  	= ��K�����>>X $��Stretch=�$��Stretch=��� $	 lbl��8�� #��z��$��Center=�
 P�  �@��
IsSelected . . ��� $ Bd�� � ��
 �   ��� $	 lbl��8   � ���� $
 Path��8   � ��P� $ 
PART_Close�� �@J�IsMouseOver . . ��� $
 Path�� � ��
 �  ��P� $ Bd�� �@J�IsMouseOver . . ��� $	 lbl�� �@�Cursor$
 Hand��P� $ 
PART_Close�� � �� . . ��� $
 Path�� � ��
 �  ���� 8   " ���� 8   " ���� 8   " ���� 8   " ��