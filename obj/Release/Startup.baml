   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  C ?myRouter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication4WpfApplication4 #clr-namespace:myRoutermyRouter    WpfApplication4.Startup   HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication4     $lclr-namespace:myRouter       � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=�(   "MahApps.Metro.Controls.MetroWindow    NonActiveWindowTitleBrush
 �����   WindowTitleBrush
 �����   CleanCloseWindowButtonStyle   WindowCloseButtonStyle# �      WindowMinButtonStyle# �   
���   �$��1q�$	��340��$	��300�� � 	Resources  �� 
TargetType  MetroWindowButtonStyle �� BasedOn	 �� Property
 �� Value �� Triggers P� Property P� Value  
WhiteBrush  restartButton  reconnectButton  RouterStyle  statusStyle  
valueStyle  
titleStyle �� 
TargetType 	 
blueButton 
 windowButton  
grayButton  settingButton  greenButton  	redButton  orangeButton  noConnection 	 title 
 values 
 titles  info 	 error  transition_download g� 	BeginTime �� 
TargetName �� TargetProperty R� KeyTime R� Value �� 	UriSource  transition_find  transition_connect  transition_refresh ��Name  12 g� Duration g� FillBehavior t� From	 t� To  TestStoryboard	 W� To W� From  gridAnimation��%{  &	        7  &	 �     7 �&	 +    7 �&	 �    &	     &	 �    &	     '�� �    &		 �    7 �&	
 �    7 �&	     7 �&	 #    7 �&	 �    7 �&	 �    7 �&	 �	    7 �&	 �
    &	 m    &	 �    &	 o    &	 �    &	 �    &	 '    &	 �    &	 %    &	 �    &	 %    &	 �    &	     �� " ��8   .��� 	 � ��

 �   � P�  �@J�IsMouseOver . . ��� 	 � ��
 �	#FFBFBFBF�� 	 � ��#
 �  P�  � �� . . ��� 	 � ��
 �	#FF8D8D8D�� 8   " ��.��� 	 � ��$	
 120���� 	 � ��$
 30���� 	 � ��
 �#4598aa�� 	 � ��

 ������� 8   " ��.��� 	 � ��$
 80���� 	 � ��$
 30���� 	 � ��
 �#06a319�� 	 � ��

 ������� " ��.��� 	 � ��$
 Regular"��� 	 � ��$
 Myriad Pro Regular)��� 	 � ��$
 20(��� 	 � ��
 �#858080�� " ��.��� 	 � ��$
 Regular"��� 	 � ��$
 Myriad Pro Regular)��� 	 � ��$
 19(��� 	 � ��
 �#858080�� " ��.��� 	 � ��$
 Regular"��� 	 � ��$
 Myriad Pro Regular)��� 	 � ��$
 18(��� 	 � ��
 �#b1b1b1�� " ��.��� 	 � ��$
 Regular"��� 	 � ��$
 Myriad Pro Regular)��� 	 � ��$
 18(��� 	 � ��
 �#1FA3FF�� " ��.��� 	 � ��
 �� " ��.R��� #��z��
��������� 8   " ��.��� 	 � ��$	
 120���� 	 � ��$
 30���� 	 � ��
 �	#FF29AFFF�� 	 � ��

 ������� 	 � ��
 �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� 	 � ��
 �	#FF1D8DD1�� 8   " ��.��� 	 � ��$	
 120���� 	 � ��$
 30���� 	 � ��

 ������� 	 � ��

 ������� 	 � ��
 �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� 	 � ��
 �	#FFCECED4�� 8   " ��.��� 	 � ��$
 80���� 	 � ��$
 30���� 	 � ��
 �	#FF9C9C9C�� 	 � ��

 ������� 	 � ��
 �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� 	 � ��
 �	#FF8B8B8B�� 8   " ��.��� 	 � ��$
 80���� 	 � ��$
 30���� 	 � ��

 ���� �� 	 � ��

 �   ��� 8   " ��.��� 	 � ��$
 80���� 	 � ��$
 30���� 	 � ��
 �	#FF00B800�� 	 � ��

 ������� 	 � ��
 �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� 	 � ��
 �	#FF009700�� 8   " ��.��� 	 � ��$
 80���� 	 � ��$
 30���� 	 � ��
 �	#FFFF4646�� 	 � ��

 ������� 	 � ��
 �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� 	 � ��
 �	#FFFF2D2D�� 8   " ��.��� 	 � ��$
 80���� 	 � ��$
 30���� 	 � ��
 �	#FFF1B761�� 	 � ��

 ������� 	 � ��
 �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� 	 � ��
 �	#FFEEA02E�� " ��.��� 	 � ��$
 Regular"��� 	 � ��$
 Myriad Pro Regular)��� 	 � ��$
 18(��� 	 � ��

 ������� 	 � ��

 ������� " ��.��� 	 � ��$
 Regular"��� 	 � ��$
 Myriad Pro Regular)��� 	 � ��$
 12(��� 	 � ��
 �#1FA3FF�� " ��.��� 	 � ��$
 Regular"��� 	 � ��$
 Myriad Pro Regular)��� 	 � ��$
 14(��� 	 � ��
 �	#FFA6A6A6�� " ��.��� 	 � ��$
 Regular"��� 	 � ��$
 Myriad Pro Regular)��� 	 � ��$
 14(��� 	 � ��
 �#1FA3FF�� " ��.��� 	 � ��$
 Normal"��� 	 � ��$
 Myriad Pro Regular)��� 	 � ��$
 15(��� 	 �@J�Opacity$	
 0.5Q��� 	 � ��
 �#1FA3FF�� " ��.��� 	 � ��$
 Normal"��� 	 � ��$
 Myriad Pro Regular)��� 	 � ��$
 15(��� 	 � ��

 �  ���� 	 �@J�Opacity$	
 0.5Q��� .��T� $ 00:00:00X�$ image��$ (Image.Source)�..�i� $ 00:00:00�� �� $# Resources/router_download.png?��� .��T� $ 00:00:00X�$ image��$ (Image.Source)�..�i� $ 00:00:00�� �� $ Resources/router_find.png?��� .��T� $ 00:00:00X�$ image��$ (Image.Source)�..�i� $ 00:00:00�� �� $" Resources/router_connect.png?��� .��T� $ 00:00:00X�$ image��$ (Image.Source)�..�i� $ 00:00:00�� �� $" Resources/router_refresh.png?��� $ MyCoolStoryboard��.��t� $ BorderThickness�$ 0:0:1.5D�$ HoldEnd=�$ 
4,60,-2,-8X�$ 
4,24,-2,28X��� .��W� $, &RenderTransform.(TranslateTransform.X)�$	 -50X�W� $ Opacity�$ 0X�$ 1X��� .��W� $ Opacity�$ 1X�$ 0X�$ 0:1:0D�.����  �� Orientation$ Vertical=�.+��� $ Vertical=�$��Center=�$��17,0,17,-31q�.+�� -    �Name$ 
secondGrid��$��Center=�$y�Visible=� � ColumnDefinitions �� $
��Auto � � RowDefinitions �� $��50 ��� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -     ��Name$  
imgRouterr��$"��Resources/router_connect.png��$��Center=�! J� Opacity$	! 100Q�$	��100��$	��100��$��1��" �� EdgeMode$" Aliased=�# �� BitmapScalingMode$
# Fant=�$ J� Effect$ 3  -System.Windows.Media.Effects.DropShadowEffect  %   	Direction$% 0Q�-   routerEffect��&   ShadowDepth$& 1Q�'   Color$' 	LightGray��(   
BlurRadius$( 5Q�)   Opacity$) 1Q��� -   * ��Name$
* info��$��info  ��#��[ $��2��$��Center=��� -   + ��Name$+ retry��$��Retry��#��[ $��3��$��50��$y�	Collapsed=��� -   , ��Name$, authenticationStack��$ Vertical=�$y�	Collapsed=�$��0,5,0,0q�$��Center=�$��4��.+��� $ Vertical=�.+��� $��Authentication��$��Center=�#��[ �� $!��Enter username and password��$��	0,-15,0,0q�$��Center=�#��[ �� -   $* error��$y�	Collapsed=�$��Center=�#��[ �  �� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto �.+��� $��Username��$��0��#��[ �� -   - ��Name$- txtUsername��$��0��$��1��$	��120���� $��4��$! 0Q�$��1���� $��	Password ��$��2��#��[ �� -	   $- txtPassword��$��2��$��1��$	��120���� $ Vertical=�.+��� $ 
Horizontal=�$��Center=��� -
   $��Connect��$��0,10,0,0q�#��[	 $��6��$��80��� -   $ 	firstGrid��$��0,25,0,0q�$	��270��$��Center=�$! 1Q�$y�	Collapsed=�$��Center=� �� $
��Auto � �� $��90 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $  	imgRouter��$#��Resources/router_settings.png��$��Center=�$	! 100Q�$��83��$	��110��$��0��$" Aliased=�$
# Fant=�$   $% 0Q�$& 1Q�$' 	LightGray��$( 5Q�$) 1Q��� $��Router Setup��$��1��$��Center=�#��[ �� $-��'select your router from the list bellow��$��Center=�$��1��$��0,20,0,0q�#��[ $��2���� $ 
Horizontal=�$��2��$��	26,0,55,0q�$��3��$��Center=�.+��� $��Router Model��#��[ �� -   . ��Name$. comboBox��$	��135������ .R��� ��`� / �� StringFormat$/ {0}:{1}��.1��� 0 �� Path$0 	BrandName��� $0 Model��� -   $+ button��$��Confirm��$��75��#��[	 $��Center=�$��4��$��0,18,0,0q�