   M S B A M L   `   `   `  ����D  @Cinch.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null0&clr-namespace:Cinch;assembly=Cinch.WPFCinch  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      P LCodeplex.Dashboarding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:Codeplex.Dashboarding;assembly=Codeplex.DashboardingCodeplex.Dashboarding 5	      M ISQLServerCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SQLServerCompanion.ControlsSQLServerCompanion.Controls 5
      S.clr-namespace:SQLServerCompanion.HelperClasses SQLServerCompanion.HelperClasses 5      7 clr-namespace:SQLServerCompanionSQLServerCompanion 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      j fMicrosoft.SqlServer.ConnectionInfo, Version=10.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91�_clr-namespace:Microsoft.SqlServer.Management.Common;assembly=Microsoft.SqlServer.ConnectionInfo%Microsoft.SqlServer.Management.Common 5      *   $SQLServerCompanion.Views.DBLogonView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  	   5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	   5      @d2http://schemas.microsoft.com/expression/blend/2008  	   5      :CinchV2&clr-namespace:Cinch;assembly=Cinch.WPF  	   5      T
 PMEFedMVVM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b6db3dc4f5fba1e3.meffed!http:\\www.codeplex.com\MEFedMVVM 
 5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 
 5      KdbBclr-namespace:Codeplex.Dashboarding;assembly=Codeplex.Dashboarding 
 5	      3ctl)clr-namespace:SQLServerCompanion.Controls 
 5
      7pw.clr-namespace:SQLServerCompanion.HelperClasses 
 5      5TypeConverters clr-namespace:SQLServerCompanion 
 5      0sys&clr-namespace:System;assembly=mscorlib 
 5      ismo_clr-namespace:Microsoft.SqlServer.Management.Common;assembly=Microsoft.SqlServer.ConnectionInfo 
 5      -   5          � 	Resources  5      2  ,SQLServerCompanion.BoolToVisibilityConverter    BooleanToVisibilityConverter S� 
MethodName S� 
ObjectType  System.Enum  odp S� MethodParameters M� TypeName��%�   &	        &	        5   
   63   S� 5   
   $ 	GetValues��6   "  64    5      M� 5      $ smo:NetworkProtocol��6   5      5      .��5      � -   5         �Name$
 root��5      $��5q�6   .+�5   
   ��  �� CornerRadius$ 10��6   $��5q�6#   $��10q�67   
���   ���5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5       � 	 � Color$	 	#FF8E8C5E��6#   � 5!      $	 White��6#   
 � Offset$
 1Q�61   5"      ._�5$   
   � -   5        $
 main��5$      $��20q�6    � RowDefinitions 5%      �� 5&      $��30 �6$   �� 5'      $��30 �6$   �� 5(      $��30 �6$   �� 5)      $��30 �6$   �� 5*      $��30 �6$   �� 5+      $��50 �6$   �� 5,      $
��Auto �6$    � ColumnDefinitions 5/      �� 50      $
��Auto �6'   �� 51      $
��Auto �6'   .+�55      �� $��Server Name / IP ��6   $��0��65   $��0��6B   $��Center=�6R   �� 56      -   5         ��Name$ txtServerName��56      $��0��6O   $��1��6\   $	��200��6l   ��61   �� *DBServerName+6l   �� 59      $ ��Use Windows Authentication��6   $��1��6>   $��0��6K   $��Center=�6[   �� 5:      $��1��6P   $��1��6]   $��5,0,5,0q�6m   $��Center=�6~    d� 	IsChecked 6   �� * UseSQLIntegratedAuthentication+6~   �� 5=      $��Network Protocol��6   $��2��64   $��0��6A   $��Center=�6Q   �� 5>      -   5        $��cboNetworkProtocol��5>      $��2��65   $��1��6B   ��6R   ��  �� Source# [  �� SelectedItem 6�   ��  �� Path$ SelectedNetworkProtocol��� 5A      $��Username��6   $��3��6,   $��0��69   $��Center=�6I   �� 5B      $��3��64   $��1��6A   $	��200��6Q   ��6   �� *
Username+6Q   �� 5E      $��Password��6   $��4��6,   $��0��69   $��Center=�6I   G� 5F      $��4��6   $��1��6+   5  /SQLServerCompanion.HelperClasses.PasswordHelper   Attach . $	��200��6�      Password 6[   �� $ Password� �� Mode$ TwoWay=�6�   � 5I      -   5        $��ProgressBar1��5J      $��5��5I      $��2��6+   $��34��6?   $��Center=�6K   $��	10,30,0,0q�6h   $	��Top=�5J   2   $	��299��6J    � Orientation$ 
Horizontal=�5K       � IsIndeterminate . 
��� � �y�5M      �� $ 	IsLoading� �� 	Converter# [  �� 5Q      $��6��6   $��2��6*    �� Orientation$ 
Horizontal=�6>   $��Center=�6W   $��10,50,10,10q�6t   .+�5R      �� $��5q�6A   $��2q�6L    �� 	IsDefault . $��Center=�5S        NormalButtonStyle#���  67   ��5R      �� *DoLogonCommand+{�6i   �� $ ShowServerConnectionPopup�.��5S   c   	Connect6l   �� 5X      $��5q�6J   $��2q�6U   $��Center=�5Y      #���  66   ��5X      �� *DoCloseLogonPopupCommand+.��5Y   b   Close6i   5Z      5[      5\      5]      5^      