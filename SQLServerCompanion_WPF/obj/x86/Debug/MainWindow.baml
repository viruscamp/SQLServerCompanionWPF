   M S B A M L   `   `   `  ����A  =Fluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:Fluent;assembly=FluentFluent  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   D @Cinch.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null0&clr-namespace:Cinch;assembly=Cinch.WPFCinch 5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
   	   M ISQLServerCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SQLServerCompanion.ControlsSQLServerCompanion.Controls 5   	   C&clr-namespace:SQLServerCompanion.ViewsSQLServerCompanion.Views 5   	   A*clr-namespace:SQLServerCompanion;assembly=SQLServerCompanion 5   	   S.clr-namespace:SQLServerCompanion.HelperClasses SQLServerCompanion.HelperClasses 5   	   P LCodeplex.Dashboarding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:Codeplex.Dashboarding;assembly=Codeplex.DashboardingCodeplex.Dashboarding 5   	   #   SQLServerCompanion.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  	   5   	   @d2http://schemas.microsoft.com/expression/blend/2008  	   5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	   5   	   9myRibbon$clr-namespace:Fluent;assembly=Fluent  	   5   	   6sys&clr-namespace:System;assembly=mscorlib  	   5   	   :CinchV2&clr-namespace:Cinch;assembly=Cinch.WPF  	   5   	   T
 PMEFedMVVM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b6db3dc4f5fba1e3.meffed!http:\\www.codeplex.com\MEFedMVVM 
 5	   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 
 5
   	   3ctl)clr-namespace:SQLServerCompanion.Controls 
 5   	   2views&clr-namespace:SQLServerCompanion.Views 
 5   	   6local*clr-namespace:SQLServerCompanion;assembly= 
 5   	   BhelperClasses.clr-namespace:SQLServerCompanion.HelperClasses 
 5   	   KdbBclr-namespace:Codeplex.Dashboarding;assembly=Codeplex.Dashboarding 
 5   	     � Title$  SQL Server Companion��5   	   $	��700��6&   $	��800��66   1 
 +MEFedMVVM.ViewModelLocator.ViewModelLocator   	ViewModel$ MainWindowViewModel��5   	    � WindowState$ 	Maximized=�6A    � 	Resources 5       �� DataType  Cinch.WorkspaceData  Cinch.NavProps   ViewCreator �� 
TargetType �� Property �� Value	 �� Triggers
 �� Binding �� Value��%�  (��       5      *, +)'� �     �� 6
   "  6   .R�5      �� .u�5      �� $��Stretch=�6   $��Stretch=�5       5      �� 5      5      �� 5   
   " �6   .�5      ��  �@J�Opacity$ 1Q�6(   	 5      �� 5      
 6   �� *ShowServerConnectionPopup+ True6L   .a�5       ��  � {� . 62   �� 5!       �@J�Opacity$
 0.65Q�60   5"      5$      5%      .��5)   
   � -   5         �Name$ 
layoutRoot��5)       � RowDefinitions 5*      �� 5+      $
��Auto �6$   �� 5,      $��* �6$   .+�5/         Fluent.Ribbon  -   5          Name$ myRibbon��5/      $��0��60      Tabs. 51         Fluent.RibbonTabItem  -   5          Name$ mainTab��51   )      Header$
 Main��6:      Groups. 53         Fluent.RibbonGroupBox     Header$ DB Connection��6.   .@�54         Fluent.Button  -   5        $��
btnConnect��54   �      Header$ Connect��6*      Icon$ Images/Connect_x32.png��6o      	LargeIcon$ Images/Connect_x32.png��6�   ��6;   �� *!ViewConnectionPropertiesCommand+6�     55      -   5        $��btnDisconnect��55   �   $ 
Disconnect��6*   $ Images/Disconnect_x32.png��6h   ��6>   �� *DoDisconnectDBCommand+6�   57        59      $ 	Scripting��6.   .@�5:        $ 
Everything��6*    � ToolTip$! Script all database objects��6f   $ Images/Script_All.png��6�   >  8SQLServerCompanion.HelperClasses.enumDatabaseObjectTypes   
Everything#��Z 6�    J� SnapsToDevicePixels . {�6>   ��  �� Path$ IsDBSelected���6�   �� *ScriptEverythingCommand+6)    5;      $ Indexes��6*   $ Script indexes��6^   $ Images/Script_Indexes.png��6w    .    Indexes#��Z 6�   {�6;   �� *IsDBSelected+��6�   �� *ScriptEverythingCommand+6�     5<      $ Stored Procs��6*   $ Stored Procs��6c   $ Images/Script_SP.png��6z      StoredProcedure#��Z 6�   {�6@   �� *IsDBSelected+��6�   �� *ScriptEverythingCommand+6�     5=      $ Foreign Keys��6*   $ Script foreign keys��6c   $ Images/Script_FK.png��6�   {�6@   �� *IsDBSelected+��6�   �� *ScriptEverythingCommand+��5>       5?   "   
ForeignKey=�6T   5A      5B        5D      $ 	SQL Pulse��6.   .@�5E      .	  (Codeplex.Dashboarding.PerformanceMonitor	  -   5         	 Name$ performanceMonitor��5E   S   $��50��5G   ,   $	��150��68   $3 -SQL Pulse - Currently displays random values.��5H   ,   %
  Codeplex.Dashboarding.Dashboard 
  Maximum$ 49464800Q�5I   ,   {�5E   0   �� *IsDBSelected+ 
  Value 5F   ,   �� $ PerformanceMonitorValue�5I   ,   5K        5Q      $  ��6.   $��Right=�68   .@�5S      �� $��0,0,0,0q�6%   $	��110��66   $��Center=�6B   .+�5T   "   �� $��/Images/Calendar.png��6(   $��70��6F   $	��100��6R   6`   �� 5U   "   -   5        $��LblDayOfWeek��5U   I     �� Left$  10��6)   
! �� Top$! 4��6:   $��14(�6]   $
��Bold"�6k   $
��Auto��6}   $��Center=�6�   �� 5V   "   -   5        $��LblDayNumber��5V   I   $  10��6(   $! 14��69   $��25(�6]   $
��Bold"�6k   
���  ��$
��Auto��6�   $��Center=�6�   �� 5W   "   -	   5        $��LblMonth��5W   I   $  10��6(   $! 40��69   $��14(�6Y   $
��Bold"�6g   $
��Auto��6z   $��Center=�6�   5X      5Y      5[        5]      -
   5        $ helpTab��5]   %   $
 Help��66   . 5^        $ Documentation��6*   .@�5_        $ About��6&   $ About this application��66   $ Images/Info.png��6W    . ��6s   �� *ShowHelpPageCommand+6�   5`      5a      5c      �� 5e         LoadingStyle#��[  6   .+�5f      .  (SQLServerCompanion.Controls.WorkingImage  "   	ImageSize$" 50Q�6'   #   ImageVisibility$# Visible=�66   5g      � 5i      -   5        $ grdHost��5i      $��2q�6(   $��1��63   $ � ShowGridLines$ .  ��. % J� Opacity$% 1Q�6{    5k      �� 5l      $
��Auto �6(   �� 5m      $��* �6(   �� 5n      $��25 �6(   & � ColumnDefinitions& 5q      �� 5r      $	��250 �6+   �� 5s      $��5 �6+   �� 5t      $��* �6+   �� 5u      $��5 �6+   �� 5v      $	��130 �6+   .+�5~      �� $��1��6#   $��0��60   $��Visible=�6@   .��5      ]� ��. .+�5�      9� $	��Top=�6'   $��0,0,0,10q�6<   $	��Top=�6N   $��	Databases��6f   ' 9� 
IsExpanded' 6y   �� $ DBListExpanded�.��5�   "   �� -   5        ( ��Name$( 	lstDbList��5�   +   $) �� IsSynchronizedWithCurrentItem$
) TrueY�6]   ��6>   �� *DBList+.  (System.Windows.Interactivity.Interaction*   	Behaviors* 5�   &   .  (Cinch.SelectorDoubleClickCommandBehavior  5�   *   +   Command+ 6U   �� *DBSelectedCommand+,   CommandParameter, 6{   �� - �� View- 5�   &   �� 5�   *    " MyListViewHeaderContainerStyle!. �� ColumnHeaderContainerStyle#. �  63   .P�5�   .   �� / �� Width$	/ 240��6=   $��DB Name��6I   0 �� CellTemplate0 5�   2   �� 5�   6   .R�5�   :   �� 1 �� TextAlignment$
1 Left=�6_   $��Center=�6t   ��6D   �� $
 Name�6t   5�   7   5�   /   5�   +   5�   #   5�      �� 5�      -   5        $��cmbDBObjects��5�   '   $	��Top=�6;   $��4q�5�      $��25��63   
����ح�$��Center=�5�      {�5�   P   �� *IsDBSelected+��5�      �� *DBObjectTypesList+2 �� SelectedItem2 5�      �� $ SelectedDBObjectType�3 �� Mode$3 TwoWay=�5�      �� 5�      -   5        $( lstTableList��5�   '   $��Bottom=�6h   ��6=   �� *ListViewObjectList+* 5�   &     5�   *   + 6U   �� *$"SelectedObjectDoubleClickedCommand+4 � ContextMenu4 5�         Fluent.ContextMenu  5�      5 �� IsOpen5 63   �� *ShowContextMenu+$3 OneWay=�.@�5�   "   o� -   5        6 o�Name$
6 menu��5�   '   $��0,0,0,0q�65   $
��Auto��6F   
���   �  ContextMenuItemStyle#��[ 5�      
������ $	��Top=�5�      
������ ��5�      �� *MainWindowOptions+5�   /   5�      - 5�   "   �� 5�   &   #. �  6/   .P�5�   .   �� $	/ 240��6=   ��6I   �� *SelectedDBObjectType+0 5�   2   �� 5�   6   .R�5�   :   �� 7 �� Orientation$7 
Horizontal=�6E   $ Double click me.��6^   .+�5�   >   �� $1 Right=�6H   $��Center=�6^   ��6y   �� $ Schema��� 5�   >   $1 Right=�6H   $��Center=�6^   $��.��6y   �� 5�   >   $
1 Left=�6H   $��Center=�6]   ��6x   �� $
 Name�5�   ;   5�   7   5�   /   5�   +   5�   #   5�      5�      �� 5�      $��Right=�6   $��Stretch=�5�      $��1��5�      $��1��6)   8 �� ResizeBehavior$8 PreviousAndNext=�66   $��5��5�      ���	#FFBCBCBC6#   � 5�      $��Center=�6   9 � 	StaysOpen9 .  : � AllowsTransparency: . ; � UseLayoutRounding; . $��Center=�5�      $��Center=�62   ��5�   +   �� *ShowServerConnectionPopup+< � PlacementTarget< 5�      �� = �� ElementName$= 
layoutRoot��.��5�      )  #SQLServerCompanion.Controls.DBLogon  > +� IsFocusScope> . ? � DataContext? 6"   �� 6;   5�      � 5�      -   5        $ grdMain��5�      $��1��6(   $��2��65   $��3��6E    5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   .+�5�      �� $7 
Horizontal=�6!   $��0��6:   5�      .  (SQLServerCompanion.Controls.TabControlEx  5�      -   5        @  Name$
@ tab1��5�   4   $��1��6'   A �� TabStripPlacement$	A Top=�5�   8    B   ShouldHideHostWhenNoItemsB . $
) TrueY�5�        TabItemStyleHorizontalTabs#��[ 5�       ! TabControlStyleHorizontalTabs#���  5�      C �� DisplayMemberPath$C DisplayText��5�      ��5�      �� *Views+5�      5�      �� 5�      $��2��6   $��2q�6&   
�������$��5��6Q   ._�5�      ]� .+�5�      �� $
��Left=�6    $
��Left=�66   $��Center=�6Q   	Version :6x   �� 5�      $
��Left=�6    $
��Left=�66   $��Center=�6Q   ��6l   �� $ ApplicationVersionNumber��� 5�      $��Right=�6    $��Right=�67   $��Center=�6S   Written by M Punglia6�   5�      5�      5�      5     5     