   M S B A M L   `   `   `  ���� D  @Cinch.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null0&clr-namespace:Cinch;assembly=Cinch.WPFCinch  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity M ISQLServerCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SQLServerCompanion.ControlsSQLServerCompanion.Controls P LCodeplex.Dashboarding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:Codeplex.Dashboarding;assembly=Codeplex.DashboardingCodeplex.Dashboarding S.clr-namespace:SQLServerCompanion.HelperClasses SQLServerCompanion.HelperClasses +   %SQLServerCompanion.Views.HomepageView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :CinchV2&clr-namespace:Cinch;assembly=Cinch.WPF     T PMEFedMVVM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b6db3dc4f5fba1e3.meffed!http:\\www.codeplex.com\MEFedMVVM  XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  3ctl)clr-namespace:SQLServerCompanion.Controls  KdbBclr-namespace:Codeplex.Dashboarding;assembly=Codeplex.Dashboarding  BhelperClasses.clr-namespace:SQLServerCompanion.HelperClasses  1  +MEFedMVVM.ViewModelLocator.ViewModelLocator    	ViewModel$  HomepageViewModel�� � 	Resources  �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value   
HoverColor P� Property	 P� Value
 N� EnterActions �� TargetProperty	 W� To g� Duration N� ExitActions��%S  '��       &	  V     �� " �� ��  �� *	IsLoading+ True.a���  �@J�Opacity$
 0.25Q��� " ��.���  �@J�Opacity$
 0.25Q���  � ��
 ����  P�  �@J�IsMouseOver	 . 
 �� .���� .��W� $ 	(Opacity)�$ 1X�$ 0:0:0.5D� �� .���� .��W� $ 	(Opacity)�$	 .25X�$ 0:0:1.0D�.��� $
��Auto��.+���   LoadingStyle#��[ .+�.  (SQLServerCompanion.Controls.WorkingImage     	ImageSize$ 50Q�   ImageVisibility$ Visible=��� 
���   �$��2q� �� CornerRadius$ 5��$��5q�
������ ._���  �� Orientation$ Vertical=�$��10q�$��Stretch=�.+��� 
�����F�$��2q�$ 5��$��5q�$
��Auto��
���   �._��� $
��Left=�.+��� $��SQL Server Companion��$��14(�$
��Bold"�$��Center=�
��������� $ 
Horizontal=�$��Center=�$
��Auto��$��Center=�$
��Auto��.+��� $	��550��.+��� $��Right=�$	��189��$
��Auto��.+��� -   $��StickyCanvas��$��
30,-40,0,0q� J� Opacity$	 0.4Q�z��� -   AnimatedRotateTransform�� �� CenterX$ 90Q� �� CenterY$ 18Q� �� Angle$ 0Q� � Triggers :�  :� RoutedEvent$ Canvas.MouseEnter��.[��� .���� .��W�  �� 
TargetName$ AnimatedRotateTransform��$ Angle�$ 30X�$ 0:0:0.5D� g� FillBehavior$
 Stop=�W� $ AnimatedRotateTransform��$ Angle�$ 14X�$ 0:0:0.5D�$ HoldEnd=�W� $ 	(Opacity)�$ 1X�$ 0:0:1.5D�:� $ Canvas.MouseLeave��.[��� .���� .��W� $ AnimatedRotateTransform��$ Angle�$ 0X�$ 0:0:0.75D�$ HoldEnd=�W� $ 	(Opacity)�$
 0.25X�$ 0:0:1.5D�.+��� $��/Images/Sticky.png��$	��300��$	��260�� K� ZIndex$ 99��� $��70,35q�$	 100�� � ColumnDefinitions �� $	��190 � � RowDefinitions �� $
��Auto ��� $
��Auto �z��� $	 150Q�$	 130Q�$	 -14Q�.+��� $ 
Horizontal=�$��0��$��0��$��Center=�.+��� $��Welcome��$��12(�
���   �$
��Bold"�$��Center=�$��5q��� $��1��$��0��$	��190��$	��110��.+��� $;��5Tip 1 : Double click on the left to select an object.��
���   �$
��Left=�$��12(�$
��Wrap=�$	��170��$��	10,0,10,0q��� $K��ETip 2 : Select db objects to view from the blue dropdown on the left.��
���   �$
��Left=�$��12(�$
��Wrap=�$	��170��$��	10,0,10,0q�