   M S B A M L   `   `   `  ���� A  =Fluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:Fluent;assembly=FluentFluent  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem D @Cinch.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null0&clr-namespace:Cinch;assembly=Cinch.WPFCinch c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity M ISQLServerCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SQLServerCompanion.ControlsSQLServerCompanion.Controls C&clr-namespace:SQLServerCompanion.ViewsSQLServerCompanion.Views A*clr-namespace:SQLServerCompanion;assembly=SQLServerCompanion S.clr-namespace:SQLServerCompanion.HelperClasses SQLServerCompanion.HelperClasses P LCodeplex.Dashboarding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:Codeplex.Dashboarding;assembly=Codeplex.DashboardingCodeplex.Dashboarding #   SQLServerCompanion.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  	   @d2http://schemas.microsoft.com/expression/blend/2008  	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	   9myRibbon$clr-namespace:Fluent;assembly=Fluent  	   6sys&clr-namespace:System;assembly=mscorlib  	   :CinchV2&clr-namespace:Cinch;assembly=Cinch.WPF  	   T
 PMEFedMVVM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b6db3dc4f5fba1e3.meffed!http:\\www.codeplex.com\MEFedMVVM 
 XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 
 3ctl)clr-namespace:SQLServerCompanion.Controls 
 2views&clr-namespace:SQLServerCompanion.Views 
 6local*clr-namespace:SQLServerCompanion;assembly= 
 BhelperClasses.clr-namespace:SQLServerCompanion.HelperClasses 
 KdbBclr-namespace:Codeplex.Dashboarding;assembly=Codeplex.Dashboarding 
   � Title$  SQL Server Companion��$	��700��$	��800��1 
 +MEFedMVVM.ViewModelLocator.ViewModelLocator   	ViewModel$ MainWindowViewModel�� � WindowState$ 	Maximized=� � 	Resources  �� DataType  Cinch.WorkspaceData  Cinch.NavProps   ViewCreator �� 
TargetType �� Property �� Value	 �� Triggers
 �� Binding �� Value��%�   (��       *, +)'� ?     �� "  .R��� .u��� $��Stretch=�$��Stretch=� �� �� " �.���  �@J�Opacity$ 1Q�	 �� 
 �� *ShowServerConnectionPopup+ True.a���  � {� . ��  �@J�Opacity$
 0.65Q�.��� -    �Name$ 
layoutRoot�� � RowDefinitions �� $
��Auto ��� $��* �.+�   Fluent.Ribbon  -     Name$ myRibbon��$��0��   Tabs.    Fluent.RibbonTabItem  -     Name$ mainTab��   Header$
 Main��   Groups.    Fluent.RibbonGroupBox     Header$ DB Connection��.@�   Fluent.Button  -   $��
btnConnect��   Header$ Connect��   Icon$ Images/Connect_x32.png��   	LargeIcon$ Images/Connect_x32.png������ *!ViewConnectionPropertiesCommand+  -   $��btnDisconnect��$ 
Disconnect��$ Images/Disconnect_x32.png������ *DoDisconnectDBCommand+  $ 	Scripting��.@�  $ 
Everything�� � ToolTip$! Script all database objects��$ Images/Script_All.png��>  8SQLServerCompanion.HelperClasses.enumDatabaseObjectTypes   
Everything#��Z  J� SnapsToDevicePixels . {���  �� Path$ IsDBSelected����� *ScriptEverythingCommand+  $ Indexes��$ Script indexes��$ Images/Script_Indexes.png�� .    Indexes#��Z {��� *IsDBSelected+���� *ScriptEverythingCommand+  $ Stored Procs��$ Stored Procs��$ Images/Script_SP.png��   StoredProcedure#��Z {��� *IsDBSelected+���� *ScriptEverythingCommand+  $ Foreign Keys��$ Script foreign keys��$ Images/Script_FK.png��{��� *IsDBSelected+���� *ScriptEverythingCommand+�� 
ForeignKey=�  $ 	SQL Pulse��.@�.	  (Codeplex.Dashboarding.PerformanceMonitor	  -    	 Name$ performanceMonitor��$��50��$	��150��$3 -SQL Pulse - Currently displays random values.��%
  Codeplex.Dashboarding.Dashboard 
  Maximum$ 49464800Q�{��� *IsDBSelected+ 
  Value �� $ PerformanceMonitorValue�  $  ��$��Right=�.@��� $��0,0,0,0q�$	��110��$��Center=�.+��� $��/Images/Calendar.png��$��70��$	��100���� -   $��LblDayOfWeek��  �� Left$  10��
! �� Top$! 4��$��14(�$
��Bold"�$
��Auto��$��Center=��� -   $��LblDayNumber��$  10��$! 14��$��25(�$
��Bold"�
���  ��$
��Auto��$��Center=��� -	   $��LblMonth��$  10��$! 40��$��14(�$
��Bold"�$
��Auto��$��Center=�  -
   $ helpTab��$
 Help��.   $ Documentation��.@�  $ About��$ About this application��$ Images/Info.png�� . ���� *ShowHelpPageCommand+��    LoadingStyle#��[  .+�.  (SQLServerCompanion.Controls.WorkingImage  "   	ImageSize$" 50Q�#   ImageVisibility$# Visible=�� -   $ grdHost��$��2q�$��1��$ � ShowGridLines$ .  ��. % J� Opacity$% 1Q� �� $
��Auto ��� $��* ��� $��25 �& � ColumnDefinitions& �� $	��250 ��� $��5 ��� $��* ��� $��5 ��� $	��130 �.+��� $��1��$��0��$��Visible=�.��]� ��. .+�9� $	��Top=�$��0,0,0,10q�$	��Top=�$��	Databases��' 9� 
IsExpanded' �� $ DBListExpanded�.���� -   ( ��Name$( 	lstDbList��$) �� IsSynchronizedWithCurrentItem$
) TrueY����� *DBList+.  (System.Windows.Interactivity.Interaction*   	Behaviors* .  (Cinch.SelectorDoubleClickCommandBehavior  +   Command+ �� *DBSelectedCommand+,   CommandParameter, �� - �� View- ��  " MyListViewHeaderContainerStyle!. �� ColumnHeaderContainerStyle#. �  .P��� / �� Width$	/ 240��$��DB Name��0 �� CellTemplate0 �� .R��� 1 �� TextAlignment$
1 Left=�$��Center=����� $
 Name��� -   $��cmbDBObjects��$	��Top=�$��4q�$��25��
����ح�$��Center=�{��� *IsDBSelected+���� *DBObjectTypesList+2 �� SelectedItem2 �� $ SelectedDBObjectType�3 �� Mode$3 TwoWay=��� -   $( lstTableList��$��Bottom=����� *ListViewObjectList+*   + �� *$"SelectedObjectDoubleClickedCommand+4 � ContextMenu4    Fluent.ContextMenu  5 �� IsOpen5 �� *ShowContextMenu+$3 OneWay=�.@�o� -   6 o�Name$
6 menu��$��0,0,0,0q�$
��Auto��
���   �  ContextMenuItemStyle#��[ 
������ $	��Top=�
������ ���� *MainWindowOptions+- �� #. �  .P��� $	/ 240������ *SelectedDBObjectType+0 �� .R��� 7 �� Orientation$7 
Horizontal=�$ Double click me.��.+��� $1 Right=�$��Center=����� $ Schema��� $1 Right=�$��Center=�$��.���� $
1 Left=�$��Center=����� $
 Name��� $��Right=�$��Stretch=�$��1��$��1��8 �� ResizeBehavior$8 PreviousAndNext=�$��5�����	#FFBCBCBC� $��Center=�9 � 	StaysOpen9 .  : � AllowsTransparency: . ; � UseLayoutRounding; . $��Center=�$��Center=����� *ShowServerConnectionPopup+< � PlacementTarget< �� = �� ElementName$= 
layoutRoot��.��)  #SQLServerCompanion.Controls.DBLogon  > +� IsFocusScope> . ? � DataContext? �� � -   $ grdMain��$��1��$��2��$��3�� �� $
��Auto ��� $��* �.+��� $7 
Horizontal=�$��0��.  (SQLServerCompanion.Controls.TabControlEx  -   @  Name$
@ tab1��$��1��A �� TabStripPlacement$	A Top=� B   ShouldHideHostWhenNoItemsB . $
) TrueY�  TabItemStyleHorizontalTabs#��[  ! TabControlStyleHorizontalTabs#���  C �� DisplayMemberPath$C DisplayText������ *Views+�� $��2��$��2q�
�������$��5��._�]� .+��� $
��Left=�$
��Left=�$��Center=�	Version :�� $
��Left=�$
��Left=�$��Center=����� $ ApplicationVersionNumber��� $��Right=�$��Right=�$��Center=�Written by M Punglia