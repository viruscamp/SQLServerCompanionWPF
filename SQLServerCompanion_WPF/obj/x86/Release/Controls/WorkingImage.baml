   M S B A M L   `   `   `  ����   SQLServerCompanion.    (SQLServerCompanion.Controls.WorkingImage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       J� RenderTransformOrigin$	  0,0&�$
��Left=�$	��Top=� � 	Resources    WorkingImageColour��%   &	        ��	Black��.��� -    �Name$ ImageCanvas��$
��Auto��$
��Auto��.+�]� -    ]�Name$ WorkingDockPanel��.+�� -   $ 
LayoutRoot��
������ $��60��$y�Visible=�
 � Tag$	 Top������  �� ElementName$ 
LayoutRoot�� �� Path$	 Tag����� $ 
LayoutRoot��$ Width�.+�� -   $ WaitGridRoot��$  0.5,0.5&�$��0��$��2q����� $ 
LayoutRoot��$ Width����� $ 
LayoutRoot��$ Height�z���  �� Angle$ 0Q� � Triggers :� 	 :� RoutedEvent$	 Grid.Loaded��[��� .���� .��W� 
 �� 
TargetName$
 WaitGridRoot�� �� TargetProperty$4 .(Grid.RenderTransform).(RotateTransform.Angle)� W� From$ 0X�	 W� To$
 -360X� g� Duration$ 0:0:1D� g� RepeatBehavior$ Forever��.+��  � RowDefinitions �� �� �� �� ��  � ColumnDefinitions �� �� �� �� �� .+�A� -    A�Name$ Ellipse1��$��0��$��2��$��1��$��1��#��[   :� $	 Ellipse.Loaded��.[��� .���� .��W� $
 Ellipse1��$ (Ellipse.Opacity)�$ 1X�$ 0X�$ 0:0:0.5D�$ Forever�� g� 	BeginTime$ 
0:0:0.0625X�A� -   $ Ellipse3��$��2��$��4��$��1��$��1��#��[   :� $	 Ellipse.Loaded��.[��� .���� .��W� $
 Ellipse3��$ (Ellipse.Opacity)�$ 1X�$ 0X�$ 0:0:0.5D�$ Forever��$ 
0:0:0.1875X�A� -   $ Ellipse5��$��4��$��2��$��1��$��1��#��[   :� $	 Ellipse.Loaded��.[��� .���� .��W� $
 Ellipse5��$ (Ellipse.Opacity)�$ 1X�$ 0X�$ 0:0:0.5D�$ Forever��$ 
0:0:0.3125X�A� -   $ Ellipse7��$��2��$��0��$��1��$��1��#��[   :� $	 Ellipse.Loaded��.[��� .���� .��W� $
 Ellipse7��$ (Ellipse.Opacity)�$ 1X�$ 0X�$ 0:0:0.5D�$ Forever��$ 
0:0:0.4375X�� $  0.5,0.5&�z��� $	 -45Q� �� �� �� �� ��  �� �� �� �� �� .+�A� -	   $ Ellipse0��$��0��$��2��$��1��$��1��#��[   :� $	 Ellipse.Loaded��.[��� .���� .��W� $
 Ellipse0��$ (Ellipse.Opacity)�$ 1X�$ 0X�$ 0:0:0.5D�$ Forever��A� -
   $ Ellipse2��$��2��$��4��$��1��$��1��#��[   :� $	 Ellipse.Loaded��.[��� .���� .��W� $
 Ellipse2��$ (Ellipse.Opacity)�$ 1X�$ 0X�$ 0:2:0.5D�$ Forever��$ 	0:0:0.125X�A� -   $ Ellipse4��$��4��$��2��$��1��$��1��#��[   :� $	 Ellipse.Loaded��.[��� .���� .��W� $
 Ellipse4��$ (Ellipse.Opacity)�$ 1X�$ 0X�$ 0:0:0.5D�$ Forever��$ 0:0:0.25X�A� -   $ Ellipse6��$��2��$��0��$��1��$��1��#��[   :� $	 Ellipse.Loaded��.[��� .���� .��W� $
 Ellipse6��$ (Ellipse.Opacity)�$ 1X�$ 0X�$ 0:0:0.5D�$ Forever��$ 	0:0:0.375X�� ���� $ Message��$	 Tag����� $ 
LayoutRoot��$ ActualHeight�.+��� -    ��Name$ Message��
������ $y�Visible=�$��Arial)�$��11(�$��Normal$�$��Regular"�$��5q�$ Bottom��$��Center=�$��Center=�
Loading...