   M S B A M L   `   `   `  ����D  @Cinch.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null0&clr-namespace:Cinch;assembly=Cinch.WPFCinch  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   M ISQLServerCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SQLServerCompanion.ControlsSQLServerCompanion.Controls 5	   	   P LCodeplex.Dashboarding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:Codeplex.Dashboarding;assembly=Codeplex.DashboardingCodeplex.Dashboarding 5
   	   S.clr-namespace:SQLServerCompanion.HelperClasses SQLServerCompanion.HelperClasses 5   	   +   %SQLServerCompanion.Views.HomepageView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :CinchV2&clr-namespace:Cinch;assembly=Cinch.WPF     5   	   T PMEFedMVVM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b6db3dc4f5fba1e3.meffed!http:\\www.codeplex.com\MEFedMVVM  5   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5   	   3ctl)clr-namespace:SQLServerCompanion.Controls  5	   	   KdbBclr-namespace:Codeplex.Dashboarding;assembly=Codeplex.Dashboarding  5
   	   BhelperClasses.clr-namespace:SQLServerCompanion.HelperClasses  5   	   1  +MEFedMVVM.ViewModelLocator.ViewModelLocator    	ViewModel$  HomepageViewModel��5   	    � 	Resources 5   
    �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value   
HoverColor P� Property	 P� Value
 N� EnterActions �� TargetProperty	 W� To g� Duration N� ExitActions��%u  '��       &	  �     �� 5      " ��6    5      �� 5       6"   �� *	IsLoading+ True6@   .a�5      ��  �@J�Opacity$
 0.25Q�64   5      5      �� 5      " ��6'   .�5      ��  �@J�Opacity$
 0.25Q�6,   �� 5       � ��
 ���� 6/    5      P� 5       �@J�IsMouseOver	 . 
 5      �� 5      .��5    "   �� .��5!   &   W� $ 	(Opacity)�66   $ 1X�6\   $ 0:0:0.5D�6c   5"   #   5#       5%      �� 5&      .��5'   "   �� .��5(   &   W� $ 	(Opacity)�66   $	 .25X�6\   $ 0:0:1.0D�6e   5)   #   5*      5,      5.      5/      .��50   
   � $
��Auto��6   .+�51      ��   LoadingStyle#��[ 6   .+�52      .  (SQLServerCompanion.Controls.WorkingImage     	ImageSize$ 50Q�6#      ImageVisibility$ Visible=�62   53      �� 55      
���   �$��2q�6)    �� CornerRadius$ 5��6=   $��5q�6N   
������ ._�56      ��  �� Orientation$ Vertical=�6   $��10q�64   $��Stretch=�6@   .+�57      �� 
�����F�$��2q�61   $ 5��6E   $��5q�6V   $
��Auto��6a   
���   �._�58      �� $
��Left=�6%   .+�59      �� $��SQL Server Companion��6$   $��14(�6C   $
��Bold"�6Q   $��Center=�6c   
�������6�   5:      5;      �� 5<      $ 
Horizontal=�6!   $��Center=�6:   $
��Auto��6U   $��Center=�6b   $
��Auto��6   .+�5=      �� $	��550��6%   .+�5>      �� $��Right=�6)   $	��189��6@   $
��Auto��6M   .+�5?   "   �� -   5        $��StickyCanvas��5?   )   $��
30,-40,0,0q�6=    J� Opacity$	 0.4Q�6Q   z�5@   &   �� 5A   *   -   5        AnimatedRotateTransform�� �� CenterX$ 90Q�5A   [    �� CenterY$ 18Q�6h    �� Angle$ 0Q�6u    � Triggers 5C   &   :� 5D   *    :� RoutedEvent$ Canvas.MouseEnter��67   .[�5E   .   �� .��5F   2   �� .��5G   6   W�  �� 
TargetName$ AnimatedRotateTransform��6F   $ Angle�6v   $ 30X�6�   $ 0:0:0.5D�6�    g� FillBehavior$
 Stop=�6�   W� 5H   6   $ AnimatedRotateTransform��6F   $ Angle�6v   $ 14X�6�   $ 0:0:0.5D�6�   $ HoldEnd=�6�   W� 5I   6   $ 	(Opacity)�6F   $ 1X�6l   $ 0:0:1.5D�6s   5J   3   5K   /   5L   +   :� 5M   *   $ Canvas.MouseLeave��67   .[�5N   .   �� .��5O   2   �� .��5P   6   W� $ AnimatedRotateTransform��6F   $ Angle�6v   $ 0X�6�   $ 0:0:0.75D�6�   $ HoldEnd=�6�   W� 5Q   6   $ 	(Opacity)�6F   $
 0.25X�6l   $ 0:0:1.5D�6v   5R   3   5S   /   5T   +   .+�5V   &   �� $��/Images/Sticky.png��6,   $	��300��6H   $	��260��6T    K� ZIndex$ 99��6a   � 5W   &   $��70,35q�6+   $	 100��6:    � ColumnDefinitions 5X   *   �� 5Y   .   $	��190 �6?    � RowDefinitions 5[   *   �� 5\   .   $
��Auto �6<   �� 5]   .   $
��Auto �6<   z�5_   *   �� 5`   .   $	 150Q�6>   $	 130Q�6L   $	 -14Q�6Z   .+�5b   *   �� $ 
Horizontal=�65   $��0��6N   $��0��6[   $��Center=�6k   .+�5c   .   �� $��Welcome��64   $��12(�6F   
���   �$
��Bold"�6g   $��Center=�6y   $��5q�6�   5d   +   �� 5e   *   $��1��65   $��0��6B   $	��190��6R   $	��110��6^   .+�5f   .   �� $9��3Tip : Double click on the left to select an object.��68   
���   �$
��Left=�6�   $��12(�6�   $
��Wrap=�6�   $	��170��6�   $��	10,0,10,0q�6�   5g   +   5h   '   5i   #   5j      5p      5�      5�      5�      5�      5�      